using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Elyse.Languagetool
{
    internal class Console
    {
        static string str;

        static void Main()
        {
            Prompt();
            Sandbox();
            System.Console.ReadLine();
        }

        static void Prompt()
        {
            System.Console.WriteLine("Type something:");
            str = System.Console.ReadLine();
            System.Console.WriteLine("\n");
            str = str ?? "My answe is good.";
        }
        
        async static void Sandbox()
        {
            Languagetool lg = new Languagetool("http://localhost:8081/");
            try
            {
                var errors = await lg.GetErrors(str);
                foreach (var e in errors)
                {
                    System.Console.WriteLine(" - " + e.msg);
                }
                System.Console.WriteLine("End with " + errors.Count + " error(s)");
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("!!!!!!!! ERROR: " + ex.Message);
            }
            
        }
    }
}
