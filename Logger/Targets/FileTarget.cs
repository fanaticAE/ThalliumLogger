using System;
using System.IO; 
using System.Collections.Generic; 

namespace fanaticae.Logger
{
	public class FileTarget:LogTarget
	{

		public override string Identifier{ get; set; }
		public override bool LogImmediate{ get; set; }
		public override LogLevel HighestLevel { get; set; }

		public override bool UseCustomFormat { get; set; }
		public override string CustomFormat { get; set; }



		public string Filepath{ get; set;}

		public FileTarget (string filepath, string identifier = "FileTarget", bool logImmediate = false, 
						   LogLevel highestLevel = LogLevel.INFORMATIONAL, bool useCustomFormat = false,
			               string customFormat = "%l - %t [%T]: %m %e")
			:base(identifier,logImmediate,highestLevel,useCustomFormat,customFormat)
		{
			this.Filepath = filepath; 
		}

		public override void log (LogEntry entry) {
			checkFile (); 

			if (entry.Level <= HighestLevel) {
				if (this.UseCustomFormat)
					File.AppendAllLines (this.Filepath, new string[]{ entry.ToString () });
				else
					File.AppendAllLines (this.Filepath, new string[]{ entry.toFormatString (this.CustomFormat) }); 
			}
		}

		public override void log (List<LogEntry> entrys){
			checkFile (); 

			List<string> lineBuffer = new List<string> (); 
			foreach (LogEntry e in entrys) {
				if (e.Level <= HighestLevel) {
					if (this.UseCustomFormat)
						lineBuffer.Add (e.toFormatString (this.CustomFormat));
					else
						lineBuffer.Add (e.toFormatString (this.CustomFormat)); 
				}
			}
			File.AppendAllLines (this.Filepath, lineBuffer); 
		}

		private void checkFile(){
			if (!File.Exists (this.Filepath))
				File.Create (this.Filepath); 
		}

		

	}
}

