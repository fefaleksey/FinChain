using System;
using System.Collections.Generic;
using System.Reflection;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;
using UserChain.Models;
using UserChain.Models.Enums;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Emit;

//using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;

namespace UserChain
{
    //TODO: internal
    public class State : IState
    {
        private readonly Dictionary<AccountAddress, Account> _accounts = new Dictionary<AccountAddress, Account>();
        private readonly Dictionary<Guid?, object> _contracts = new Dictionary<Guid?, object>();

        public void UpdateState(Block block)
        {
            foreach (var transaction in block.Transactions)
            {
                ApplyTransaction(transaction);
            }
        }

        private void ApplyTransaction(UserChainTransaction transaction)
        {
            switch (transaction.Type)
            {
                case UserChainTransactionType.Deploy:
                    Deploy_Handler(transaction);
                    return;
                case UserChainTransactionType.CallContractFunction:
                    CallContractFunction_Handler(transaction);
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Deploy_Handler(UserChainTransaction transaction)
        {
//            transaction.
            var sender = transaction.Sender;
            var action = (IAction) transaction.Params[0];
            foreach (var accountType in action.AccessToDeploy)
            {
                if (sender.Type == accountType)
                {
//                    Deploy(action);
                }
            }
        }

//        [HttpPost, Route("kekPost")]
//        public void Kek([FromBody] string code)
//        {
//            System.IO.File.WriteAllText("source.cs", code);
////          
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
// /* 2. invoke method MyMethod() which returns object "CustomType" - how do I check if it exists? */
// /* 3. what's the meaning of 4th parameter (t in this case); MSDN says this is "the Object on which to
//       invoke the specified member", but isn't this already accounted for by using t.InvokeMember()? */

//            var result = type.InvokeMember("MyMethod", BindingFlags.InvokeMethod, null, type, @params);
//            var shit = result;
//
//        }

        //TODO: private

        public void Deploy(string code)
        {
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters();


            // Reference to System.Drawing library
            parameters.ReferencedAssemblies.Add("System.Drawing.dll");
            // True - memory generation, false - external file generation
            parameters.GenerateInMemory = true;
            // True - exe file generation, false - dll file generation
            parameters.GenerateExecutable = true;

            CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);


            if (results.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in results.Errors)
                {
                    sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                }

                throw new InvalidOperationException(sb.ToString());
            }

            Assembly assembly = results.CompiledAssembly;


            Type program = assembly.GetType("First.Contract");
            var obj = Activator.CreateInstance(program);
            MethodInfo main = program.GetMethod("Main");

            main.Invoke(null, null);
            main.Invoke(obj, null);
            /*
            var assembly = Assembly.Load("assemblyName");
            var type = assembly.GetType("...Contract");
            var obj = Activator.CreateInstance(type) as dynamic;
            obj.Execute();
            */

//            _actions.Add(action.Id, action);
        }

        public void Blyat(string code)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
//            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(@"
//            namespace ns{
//                using System;
//                public class App{
//                    public static void Main(string[] args){
//                        Console.Write(""dada"");
//                    }
//                }
//
//
//            }");

            //creating options that tell the compiler to output a .Net module
            var options = new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary,
                optimizationLevel: OptimizationLevel.Debug,
                allowUnsafe: true);

            //creating the compilation
            var compilation = CSharpCompilation.Create(Path.GetRandomFileName(), options: options);

            //adding the syntax tree
            compilation = compilation.AddSyntaxTrees(syntaxTree);

            //getting the local path of the assemblies
            var assemblyPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
            List<MetadataReference> references = new List<MetadataReference>();
            //adding the core dll containing object and other classes
            references.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.Private.CoreLib.dll")));
            references.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "mscorlib.dll")));
            references.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.Console.dll")));
            references.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.Runtime.dll")));
            //gathering all using directives in the compilation
            var usings = compilation.SyntaxTrees.Select(tree => tree.GetRoot()
                .DescendantNodes().OfType<UsingDirectiveSyntax>()).SelectMany(s => s).ToArray();

            //for each using directive add a metadatareference to it
            foreach (var u in usings)
            {
                references.Add(
                    MetadataReference.CreateFromFile(Path.Combine(assemblyPath, u.Name.ToString() + ".dll")));
            }

            //add the reference list to the compilation
            compilation = compilation.AddReferences(references);

            //compile
            using (var ms = new MemoryStream())
            {
                var result = compilation.Emit(ms);

                if (!result.Success)
                {
                    var failures = result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (var diagnostic in failures)
                    {
                        Console.Error.WriteLine("{0}: {1}, {2}", diagnostic.Id, diagnostic.GetMessage(),
                            diagnostic.Location);
                    }
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    AssemblyLoadContext context = AssemblyLoadContext.Default;
                    Assembly assembly = context.LoadFromStream(ms);
                    
                    var type = assembly.GetType("First.Contract");
                    var obj = Activator.CreateInstance(type) as dynamic;
                    obj.Execute();
                    obj.Execute();
                    obj.Execute();
                    
                    
//                    assembly.EntryPoint.Invoke(null, new object[] {new string[] {"arg1", "arg2", "etc"}});

                }
            }
        }

        private void CallContractFunction_Handler(UserChainTransaction transaction)
        {
            var id = transaction.ContractId;
            _actions[id].Execute(transaction.Sender, transaction.Params);
        }
    }
}