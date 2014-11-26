using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Elyse.Languagetool
{
	public class ServerApi : ILanguagetoolApi
	{
		private Process _proc;
		private string _startServerCmd = "/usr/bin/java -cp /home/lighta/projects/LanguageTool-2.7/languagetool-server.jar org.languagetool.server.HTTPServer";
		public string startServerCmd {
			set { _startServerCmd = value; }
		}

		public ServerApi()
		{

		}
		public List<MisspeledWord> GetMisspeledWords(string str)
		{
			return new List<MisspeledWord> ();
		}
			
		public void Start(out string output)
		{
			output = "";

			if (!IsRunning)
			{
				ProcessStartInfo procStartInfo = new ProcessStartInfo("/bin/bash", "-c \""+_startServerCmd+"\"");

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
			
		public void Stop()
		{
			if (_proc == null) {
				throw new Exception ("Server has to be started");
			}

			if (!_proc.HasExited) {
				_proc.Close ();
			}
		}

		public bool IsRunning
		{
			get {
				bool running = true;
				using (System.Net.Sockets.TcpClient client = new TcpClient ()) {
					try
					{
						client.Connect("127.0.0.1", 8081);
					} catch (SocketException ex)
					{
						running = false;
					}
				}

				return running;
			}
		}
	}
}

