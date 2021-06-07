using System;
using System.IO;
using System.Collections.Generic;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SDL Trisoft Assignment");
            var reader = new SDLXmlReader();

            string[] files = Directory.GetFiles(Environment.CurrentDirectory, "*.xml", 
                SearchOption.AllDirectories);

            reader.UpdateFiles(files);
            Console.WriteLine("End of the application");
        }
    }
}
