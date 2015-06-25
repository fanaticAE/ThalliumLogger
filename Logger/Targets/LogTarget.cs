using System;
using System.Collections.Generic; 

namespace fanaticae.Logger
{
	public abstract class LogTarget
	{
		public abstract string Identifier{ get; set; }
		public abstract bool LogImmediate{ get; set; }
		public abstract LogLevel HighestLevel { get; set; }

		public abstract bool UseCustomFormat { get; set; }
		public abstract string CustomFormat { get; set; }

		public LogTarget( string identifier = "LogTarget", bool logImmediate = false, LogLevel highestLevel = LogLevel.INFORMATIONAL, bool useCustomFormat = false, string customFormat = "%l - %t [%T]: %m %e")
		{
			this.Identifier = identifier; 
			this.LogImmediate = logImmediate; 
			this.HighestLevel = highestLevel; 
			this.UseCustomFormat = useCustomFormat; 
			this.CustomFormat = customFormat; 
		}

		public abstract void log (LogEntry entry); 
		public abstract void log (List<LogEntry> entrys); 
	}
}

