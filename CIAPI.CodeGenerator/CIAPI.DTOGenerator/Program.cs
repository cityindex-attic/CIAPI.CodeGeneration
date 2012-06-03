using System;
using System.IO;
using CommandLine;


namespace CIAPI.CodeGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var opt = new Options();
            var cmdParser = new CommandLineParser(new CommandLineParserSettings(Console.Error));
            if (!cmdParser.ParseArguments(args, opt))
            {
                // #TODO: usage; if this tool is to be developed further
                Environment.Exit(1);
            }


            string schemaJson = File.ReadAllText(opt.InputFile);
            bool flattenHierarchy = opt.FlattenHierarchy;
            string nspace = opt.NSpace;


            var lang = opt.Language;

            SchemaParser schemaParser;

            switch (lang)
            {
                case Lang.CS:
                    var imports = opt.Imports == null ? new string[] { } : opt.Imports.Split(',');
                    schemaParser = new CSharpSchemaParser(schemaJson, imports, nspace);
                    break;
                case Lang.JS:
                    schemaParser = new JsSchemaParser(schemaJson);
                    break;
                default:
                    throw new Exception("unrecognized language option");
            }


            var output = new FileStream(opt.OutputFile, FileMode.Create, FileAccess.Write);
            
            schemaParser.BeginCodeFile(output);
            schemaParser.EmitTypes(output, flattenHierarchy);
            schemaParser.EndCodeFile(output);

            output.Close();
        }



        #region Nested type: Options

        private sealed class Options : CommandLineOptionsBase
        {
            [Option("f", "flatten", Required = false, DefaultValue = false)]
            public bool FlattenHierarchy { get; set; }

            [Option("n", "nspace", Required = false)]
            public string NSpace { get; set; }

            [Option("u", "using", Required = false)]
            public string Imports { get; set; }

            [Option("i", "input", Required = true)]
            public string InputFile { get; set; }

            [Option("l", "lang", Required = true)]
            public Lang Language { get; set; }

            [Option("o", "output", Required = true)]
            public string OutputFile { get; set; }
        }

        #endregion
    }

    public enum Lang
    {
        CS,
        JS
    }
}