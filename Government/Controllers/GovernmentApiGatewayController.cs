using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Aq.ExpressionJsonSerializer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RuleChain.Models;
using RuleChain;
using TransactionPool;
using System.IO;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Text;
using System.Linq;

namespace Government.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernmentApiGatewayController : ControllerBase
    {
        private readonly ITransactionsPool<RuleTransaction> _transactionsPool;

        public GovernmentApiGatewayController(ITransactionsPool<RuleTransaction> transactionsPool)
        {
            _transactionsPool = transactionsPool;
        }

        [HttpPost, Route("addTransaction")]
        public void AddTransaction([FromBody] RuleTransaction transaction)
        {
            RuleTransactionsVerifier.Verify(transaction);
            _transactionsPool.Push(transaction);
        }

//        [HttpGet, Route("kek")]
//        public object Kek()
//        {
//            var settings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Objects};
//            settings.Converters.Add(new ExpressionJsonConverter(Assembly.GetAssembly(typeof(Huy))));
//
//            return JsonConvert.SerializeObject(new Huy(), settings);
//        }



//        [HttpPost, Route("kekPost")]
//        public void Kek([FromBody] string code)
//        {
//            System.IO.File.WriteAllText("source.cs", code);
//
//            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
//
//            var parameters = new CompilerParameters();
//            parameters.GenerateExecutable = false;
//            parameters.GenerateInMemory = true;
//
//            foreach (string assemblyLocation in assemblyLocations)
//            {
//                parameters.ReferencedAssemblies.Add(assemblyLocation);
//            }
//
//            var result = compiler.CompileAssemblyFromSource(parameters, code);
//
//            System.CodeDom.Compiler
//            System.CodeDom.CompilerParameters parms = new CompilerParameters
//            {
//                GenerateExecutable = false,
//                GenerateInMemory = true,
//                IncludeDebugInformation = false
//            };
//
//            parms.ReferencedAssemblies.Add("System.dll");
//            parms.ReferencedAssemblies.Add("System.Data.dll");
//            CodeDomProvider compiler = CSharpCodeProvider.CreateProvider("CSharp");
//
//            return compiler.CompileAssemblyFromSource(parms, source);
//
//            Microsoft.CSharp.RuntimeBinder.Binder.CSharpCodeProvider codeProvider = new CSharpCodeProvider();
//            ICodeCompiler icc = codeProvider.CreateCompiler();
//            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
//            parameters.GenerateExecutable = false;
//            parameters.OutputAssembly = "AutoGen.dll";
//            CompilerResults results = icc.CompileAssemblyFromSource(parameters, yourCodeAsString);
//
//            var assembly = Assembly.Load("assemblyName");
//            var type = assembly.GetType("...Contract");
//            var obj = Activator.CreateInstance(type) as dynamic;
//            obj.Execute();
//
//            object[] @params = new object[2];
//            @params[0] = 'a';
//            @params[1] = 'b';
//
//            /* 2. invoke method MyMethod() which returns object "CustomType" - how do I check if it exists? */
//            /* 3. what's the meaning of 4th parameter (t in this case); MSDN says this is "the Object on which to invoke the specified member", but isn't this already accounted for by using t.InvokeMember()? */
//            var result = type.InvokeMember("MyMethod", BindingFlags.InvokeMethod, null, type, @params);
//            var shit = result;
//
//        }
    }

    internal class Compiler
    {
        public byte[] Compile(string sourceCode) //filepath
        {
//            Console.WriteLine($"Starting compilation of: '{filepath}'");
            
//            var sourceCode = File.ReadAllText(filepath);

            using (var peStream = new MemoryStream())
            {
                var result = GenerateCode(sourceCode).Emit(peStream);

                if (!result.Success)
                {
                    Console.WriteLine("Compilation done with error.");

                    var failures = result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (var diagnostic in failures)
                    {
                        Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
                    }

                    return null;
                }

                Console.WriteLine("Compilation done without any error.");

                peStream.Seek(0, SeekOrigin.Begin);

                return peStream.ToArray();
            }
        }

        private static CSharpCompilation GenerateCode(string sourceCode)
        {
            var codeString = SourceText.From(sourceCode);
            var options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp7_3);

            var parsedSyntaxTree = SyntaxFactory.ParseSyntaxTree(codeString, options);

            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly
                    .Location),
                MetadataReference.CreateFromFile(typeof(Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo).Assembly
                    .Location),
            };

            return CSharpCompilation.Create("Hello.dll",
                new[] {parsedSyntaxTree},
                references: references,
                options: new CSharpCompilationOptions(OutputKind.ConsoleApplication,
                    optimizationLevel: OptimizationLevel.Release,
                    assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default));
        }
    }
}