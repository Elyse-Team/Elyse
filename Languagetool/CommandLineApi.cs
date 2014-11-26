using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Elyse.Languagetool
{
	public class CommandLineApi : ILanguagetoolApi
	{
		private const string BaseCmd = "-c \"echo '{0}' | /usr/bin/java -jar /home/lighta/projects/LanguageTool-2.7/languagetool-commandline.jar -l en {1}\"";

		public CommandLineApi ()
		{

		}

		public List<MisspeledWord> GetMisspeledWords(string text) {
			string result = RunCommand(text, "-t");

			return new List<MisspeledWord> ();
		}

		private string RunCommand(string text, string arguments = "")
		{

			var command = String.Format (BaseCmd, text, arguments);
			ProcessStartInfo procStartInfo = new ProcessStartInfo("/bin/bash", command);

			procStartInfo.RedirectStandardOutput = true;
			procStartInfo.UseShellExecute = false;
			procStartInfo.CreateNoWindow = true;

			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			proc.StartInfo = procStartInfo;
			proc.StartInfo.UseShellExecute = false;
			proc.Start();
			proc.WaitForExit ();


			string result = proc.StandardOutput.ReadToEnd();

			return result;
		}
	}
}

