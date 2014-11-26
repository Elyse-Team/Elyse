using System;
using Languagetool;
using Languagetool.Languagetool;
using System.Diagnostics;

namespace Main
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			string str = "We all enjoy beeing aat school";
			var CommandLine = new CommandLineApi ();

			var Checker = new Languagetool (str, CommandLine);

			//Console.WriteLine (Checker.GetCorrectedText());
			Console.WriteLine (CommandLine.CorrectText(str));
		}
	}
}
