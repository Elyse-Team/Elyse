using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;

namespace Elyse.Languagetool
{
	public class ServerApi : ILanguagetoolApi
	{
		private Process _proc;

		public ServerApi()
		{

		}
		public List<MisspeledWord> GetMisspeledWords(string str)
		{
			return new List<MisspeledWord> ();
		}
			
		public void start(out string output)
		{
			if (!IsServerRunning)
			{
				ProcessStartInfo procStartInfo = new ProcessStartInfo("/bin/bash", "");

				procStartInfo.RedirectStandardOutput = true;
				procStartInfo.UseShellExecute = false;
				procStartInfo.CreateNoWindow = true;

				System.Diagnostics.Process _proc = new System.Diagnostics.Process();
				_proc.StartInfo = procStartInfo;
				_proc.StartInfo.UseShellExecute = false;
				_proc.Start();
				//proc.WaitForExit ();
				Thread.Sleep(500);
				output = _proc.StandardOutput.ReadToEnd();

				if (!output.Contains ("Server started")) {
					throw new Exception("Server fail to start");
				}
			}
		}
			
		public void stop()
		{
			if (_proc == null) {
				throw new Exception ("Server has to be started");
			}

			if (!_proc.HasExited) {
				_proc.Close ();
			}
		}

		public bool IsServerRunning
		{
			get {
				using (var ping = new Ping ()) {
					var pingResult = ping.Send ("localhost:8081");

					return (pingResult.Status == IPStatus.Success);
				}
			}
		}
	}
}

