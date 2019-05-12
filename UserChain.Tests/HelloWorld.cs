using System;

// ReSharper disable once CheckNamespace
namespace First
{
    public class Contract
    {
        private int _counter = 0;
        public void Execute()
        {
            _counter++;
            Console.WriteLine(_counter + " Welcome to C# world");
//            Console.ReadLine();
        }
    }
}
