using System;

namespace TextWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Wrapper wrapper = new Wrapper();
            Console.Write("Enter path to file: ");
            string path = Console.ReadLine();  
            string[] lines = System.IO.File.ReadAllLines(@path);
            wrapper.wrapText(lines, path);
        }
    }
}
