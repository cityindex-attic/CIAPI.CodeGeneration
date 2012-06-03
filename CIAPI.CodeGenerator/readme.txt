

-l (string)[CS|??]  Language to emit
-i (string) path to json schema file
-o (string) path to output file. will be overwritten
-n (string) namespace (optional)
-u (string) imports. comma separated. e.g. System,System.Text  (optional)
-f [true|false] flatten hierarchy



example: 
CIAPI.DTOGenerator -n "CIAPI.DTO" -u "System" -l CS -i "..\..\..\MetaData\schema.js" -o "..\..\..\Generated\dto.cs" -f true


For debugging, Properties>Debug>Start Options>Command Line Arguments:
-n "CIAPI.DTO" -u "System" -l CS -i "..\\..\\..\\MetaData\\schema.js" -o "..\\..\\..\\Generated\dto.cs" -f true