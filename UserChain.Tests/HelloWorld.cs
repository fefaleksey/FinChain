using System;

namespace First
{
    public class Contract
    {
        private int counter = 0;
        public void Execute()
        {
            counter++;
            Console.WriteLine(counter + " Welcome to C# world");
//            Console.ReadLine();
        }
    }
}
