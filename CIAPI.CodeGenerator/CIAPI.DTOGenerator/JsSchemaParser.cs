using System;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CIAPI.CodeGenerator
{
    public class JsSchemaParser:SchemaParser
    {
        public JsSchemaParser(string schemaJson) : base(schemaJson)
        {
        }

        public override string ResolvePrimitiveTypeName(string typename, JObject property)
        {
            throw new NotImplementedException();
        }

        public override void EmitEnumeration(Stream output, JObject typeObj)
        {
            throw new NotImplementedException();
        }

        public override void EmitType(Stream output, JObject typeObject, bool flattenHierarchy)
        {
            throw new NotImplementedException();
        }

        public override void BeginCodeFile(Stream output)
        {
            throw new NotImplementedException();
        }

        public override void EndCodeFile(Stream output)
        {
            throw new NotImplementedException();
        }
    }
}