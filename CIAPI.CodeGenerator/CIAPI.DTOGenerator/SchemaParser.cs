using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CIAPI.CodeGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SchemaParser
    {
        /// <summary>
        /// 
        /// </summary>
        public JObject Schema;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schemaJson"></param>
        public SchemaParser(string schemaJson)
        {
            Schema = (JObject)JsonConvert.DeserializeObject(schemaJson);
        }

        public void RecurseHierarchyAndAppendProperties(JObject typeObject)
        {
            var propertiesOfThisType = (JObject)typeObject["properties"];

            JObject baseTypeObject = GetBaseType(typeObject);
            while (baseTypeObject != null)
            {
                // merge properties from basetype here. you should ignore duplicate (overriden) properties as you dive into the inheritance chain

                var propertiesOfBaseType = (JObject)baseTypeObject["properties"];

                foreach (var kvp2 in propertiesOfBaseType)
                {
                    string baseTypePropertyName = kvp2.Key;
                    var baseTypePropertyObject = (JObject)kvp2.Value;

                    if (propertiesOfThisType[baseTypePropertyName] == null)
                    {
                        propertiesOfThisType[baseTypePropertyName] = baseTypePropertyObject;
                    }
                }

                // get next ancestor, if any
                baseTypeObject = GetBaseType(baseTypeObject);
            }
        }


        public void EmitTypes(Stream output, bool flattenHierarchy)
        {

            


            Dictionary<string, JObject> types = GetTypes();

            foreach (var kvp in types)
            {
                JObject typeObj = kvp.Value;

                // can be a class or an enum

                if (typeObj["enum"] != null)
                {
                    EmitEnumeration(output, typeObj);
                }
                else
                {
                    EmitType(output, typeObj, flattenHierarchy);
                }
            }


            
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, JObject> GetTypes()
        {
            var types = new Dictionary<string, JObject>();
            var typeList = (JObject)Schema["properties"];
            foreach (var tPair in typeList)
            {
                string typeName = tPair.Key;
                var typeObj = (JObject)tPair.Value;
                types.Add(typeName, typeObj);
            }
            return types;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeObj"></param>
        /// <returns></returns>
        public JObject GetBaseType(JObject typeObj)
        {
            JObject baseType = null;
            if (typeObj["extends"] != null)
            {
                string baseTypeName = typeObj["extends"].Value<string>().Substring(2);
                baseType = (JObject)Schema["properties"][baseTypeName];
            }
            return baseType;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="typename"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public abstract string ResolvePrimitiveTypeName(string typename, JObject property);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        /// <param name="typeObj"></param>
        public abstract void EmitEnumeration(Stream output, JObject typeObj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        /// <param name="typeObject"></param>
        /// <param name="flattenHierarchy"></param>
        /// <param name="parser"></param>
        public abstract void EmitType(Stream output, JObject typeObject, bool flattenHierarchy);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public abstract void BeginCodeFile(Stream output);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public abstract void EndCodeFile(Stream output);


        public void AppendLine(Stream output, string line)
        {
            var bytes = Encoding.UTF8.GetBytes(line + Environment.NewLine);
            output.Write(bytes,0,bytes.Length);
        }
    }
}