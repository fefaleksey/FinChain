using System;
using System.Collections.Generic;
using System.Reflection;
using FinChain.Models.Accounts;
using UserChain.Models;
using UserChain.Models.Enums;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace UserChain
{
    //TODO: internal
    public class State : IState
    {
        private readonly Dictionary<AccountAddress, Account> _accounts = new Dictionary<AccountAddress, Account>();
        private readonly Dictionary<Guid?, object> _contracts = new Dictionary<Guid?, object>();

        public void UpdateState(UserChainBlock userChainBlock)
        {
            foreach (var transaction in userChainBlock.Transactions)
            {
                ApplyTransaction(transaction);
            }
        }

        public bool AddAccount(Account account)
        {
            if (_accounts.ContainsKey(account.AccountAddress))
            {
                return false;
            }
            _accounts.Add(account.AccountAddress, account);
            return true;
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
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(transaction.Code);

            //creating options that tell the compiler to output a .Net module
            var options = new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary,
                optimizationLevel: OptimizationLevel.Debug,
                allowUnsafe: false);

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
            references.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.dll")));
            assemblyPath = typeof(FinChain.Models.Accounts.Account).Assembly.Location;
            references.Add(MetadataReference.CreateFromFile(assemblyPath));

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
                    _contracts.Add(transaction.ContractId, obj);
                }
            }
        }

        private void CallContractFunction_Handler(UserChainTransaction transaction)
        {
            var id = transaction.ContractId;
            var contract = _contracts[id] as dynamic;
            contract.Execute(transaction.Sender, transaction.Params);
        }
    }
}