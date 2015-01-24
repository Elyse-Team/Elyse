using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.stanford.nlp.pipeline;
using ElyseLibrary;

namespace ElyseConsole
{
    public class Program
    {

        static void Main(string[] args)
        {
            string path = "B:/Visual Studio Projects";
            StanfordParserConsole parser = new StanfordParserConsole(path);
            System.Console.WriteLine("\nParser Loaded !\n");

            SceneBuilder sceneBuilder = new SceneBuilder();
            sceneBuilder.AddCharacter("Kevin", Character.Gender.Male, Character.SkinColor.White, Character.ShirtColor.Blue);
            Scene scene = new Scene(sceneBuilder);

            bool on = true;
            while (on)
            {
                System.Console.WriteLine("Enter your sentence...\n");
                string sentence = System.Console.ReadLine();
                parser.Parse(sentence);
                parser.TestConsole();
                parser.MorphAST(scene);

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
