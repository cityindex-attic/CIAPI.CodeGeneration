using System;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CIAPI.CodeGenerator
{
    public class CSharpSchemaParser : SchemaParser
    {
        public CSharpSchemaParser(string schemaJson,string[] imports,string nspace)
            : base(schemaJson)
        {
            _imports = imports;
            _namespace = nspace;
        }

        private readonly string[] _imports;
        private readonly string _namespace;

        public override void BeginCodeFile(Stream output)
        {
            foreach(var import in _imports)
            {
                AppendLine(output,string.Format("using {0};",import));    
            }

            AppendLine(output, string.Format("namespace {0}", _namespace));
            AppendLine(output, "{");
        }

        public override void EndCodeFile(Stream output)
        {
            AppendLine(output, "}");
        }

        public override void EmitEnumeration(Stream output, JObject typeObj)
        {
            AppendLine(output, string.Format("\tpublic enum {0}", typeObj["id"]));
            AppendLine(output, "\t{");

            var values = (JArray)typeObj["options"];
            foreach (JObject item in values)
            {
                AppendLine(output, string.Format("\t\t{0} = {1},", item["label"], item["value"]));
            }
            AppendLine(output, "\t}");
            AppendLine(output, "");
        }


        public override void EmitType(Stream output, JObject typeObject, bool flattenHierarchy)
        {

            string baseTypename = "";

            if (flattenHierarchy)
            {
                RecurseHierarchyAndAppendProperties(typeObject);
            }
            else
            {
                JObject baseTypeObject = GetBaseType(typeObject);
                baseTypename = (baseTypeObject == null) ? "" : ":" + baseTypeObject["id"];
            }



            AppendLine(output, string.Format("\tpublic class {0}{1}", typeObject["id"], baseTypename));
            AppendLine(output, "\t{");

            foreach (var typeProperty in (JObject)typeObject["properties"])
            {
                string propertyTypename;

                bool isArray = false;
                bool isNullable = false;


                var typePropObj = (JObject)typeProperty.Value;

                if (typePropObj["type"].Type == JTokenType.String)
                {

                    if (typePropObj["type"].Value<string>() == "array")
                    {
                        isArray = true;

                        var items = (JArray)typePropObj["items"];

                        if (items.Count != 1)
                        {
                            throw new Exception("we are not expecting more than one element in an 'items' array");
                        }

                        if (items[0].Type == JTokenType.String)
                        {
                            propertyTypename = ResolvePrimitiveTypeName((string)items[0], typePropObj);
                        }
                        else if (items[0].Type == JTokenType.Object)
                        {
                            if (items[0]["$ref"] == null)
                            {
                                throw new Exception("we are expecting a $ref");
                            }

                            propertyTypename = ((string)items[0]["$ref"]).Substring(2);
                        }
                        else
                        {
                            throw new Exception("we are expecting a single string or object in 'items' array");
                        }
                    }
                    else
                    {
                        propertyTypename = (string)typePropObj["type"];
                        propertyTypename = ResolvePrimitiveTypeName(propertyTypename, typePropObj);
                    }
                }
                else if (typePropObj["type"].Type == JTokenType.Array)
                {
                    // the only time we emit an array as a type is to describe nullable primitives
                    var typeArray = (JArray)typePropObj["type"];
                    if ((typeArray.Count != 2) || ((string)typeArray[0] != "null" && (string)typeArray[1] != "null"))
                    {
                        throw new Exception(
                            "array value for 'type' is expected to have 2 string values; 'null' and the primitive type");
                    }

                    propertyTypename = (string)typeArray[0];
                    if (propertyTypename == "null")
                    {
                        propertyTypename = (string)typeArray[1];
                    }

                    propertyTypename = ResolvePrimitiveTypeName(propertyTypename, typePropObj);

                    isNullable = true;
                }
                else if (typePropObj["type"].Type == JTokenType.Object)
                {
                    // if it is an object it should be a schema reference
                    if (typePropObj["type"]["$ref"] == null)
                    {
                        throw new Exception("expected schema $ref");
                    }

                    propertyTypename = ((string)typePropObj["type"]["$ref"]).Substring(2);
                }
                else
                {
                    throw new Exception("unrecognized property type");
                }


                // now emit the property declaration
                AppendLine(output, string.Format("\t\tpublic {0}{1}{2} {3} {{get; set;}}", propertyTypename,
                                                isArray ? "[]" : "", isNullable ? "?" : "", typeProperty.Key));
            }
            AppendLine(output, "\t}");
            AppendLine(output, "");
        }



        public override string ResolvePrimitiveTypeName(string typename, JObject property)
        {
            string format = "";
            if (property["format"] != null)
            {
                format = (string)property["format"];
            }
            switch (typename)
            {
                case "string":
                    switch (format)
                    {
                        case "":
                            typename = "string";
                            break;
                        case "wcf-date":
                            typename = "DateTime";
                            break;
                        default:
                            throw new Exception("unrecognized string format type");
                    }
                    break;
                case "number":
                    switch (format)
                    {
                        case "":
                            typename = "float";
                            break;
                        case "decimal":
                            typename = "decimal";
                            break;
                        default:
                            throw new Exception("unrecognized number format type");
                    }
                    break;
                case "integer":
                    typename = "int";
                    break;
                case "boolean":
                    typename = "bool";
                    break;
                    //case "object":
                    //case "null":
                    //case "any":
                default:
                    throw new Exception("expecting primitive type");
            }

            return typename;
        }
    }
}