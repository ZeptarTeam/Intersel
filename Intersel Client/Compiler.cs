using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidLLC_client
{
    public class Compiler
    {
        public Compiler(string sourceCode, string savePath)
        {
            string[] referencedAssemblies = new string[] { "System.dll", "System.Linq.dll", "System.IO.dll", "System.Net.dll", "System.Security.dll", "System.Security.Permissions.dll", "System.Collections.dll", "Newtonsoft.Json.dll", "System.Core.dll" };

            Dictionary<string, string> providerOptions = new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } };

            string compilerOptions = "/target:winexe /platform:anycpu /optimize+";

            using (CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider(providerOptions))
            {
                CompilerParameters compilerParameters = new CompilerParameters(referencedAssemblies)
                {
                    GenerateExecutable = true,
                    GenerateInMemory = false,
                    OutputAssembly = savePath, // Path for Output
                    CompilerOptions = compilerOptions,
                    TreatWarningsAsErrors = false,
                    IncludeDebugInformation = false,
                };

                CompilerResults compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, sourceCode); // Stub.cs
                if (compilerResults.Errors.Count > 0)
                {
                    foreach (CompilerError compilerError in compilerResults.Errors)
                    {
                        MessageBox.Show(string.Format("{0}\nLine: {1} - Column: {2}\nFile: {3}", compilerError.ErrorText,
                            compilerError.Line, compilerError.Column, compilerError.FileName));
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("Stub has compiled successfully!", "Intersel - version 1.0");
                }
            }
        }
    }
}
