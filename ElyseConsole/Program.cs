using System;
using StanfordParser;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.stanford.nlp.pipeline;

namespace ElyseConsole
{
    public class Program
    {

        static void Main(string[] args)
        {
            StanfordParser parser = new StanfordParser();
            System.Console.WriteLine("\nParser Loaded ! FUCK YOU PEOPLEEEEEEE\n");

            bool on = true;
            while (on)
            {

                System.Console.WriteLine("Enter your sentence...\n");
                string sentence = System.Console.ReadLine();
                parser.Parse(sentence);
                parser.TestConsole();

                System.Console.WriteLine("\nParse another sentence ? <y>es - <n>o");
                string response = System.Console.ReadLine();
                if (response != "y")
                {
                    on = false;
                }
            }
        }
    }
}
