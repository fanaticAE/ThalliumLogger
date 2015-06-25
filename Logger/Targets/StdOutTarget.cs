using System;

namespace fanaticae.Logger
{
	public class StdOutTarget:LogTarget
	{
		public override string Identifier{ get; set; }
		public override bool LogImmediate{ get; set; }
		public override LogLevel HighestLevel { get; set; }

		public override bool UseCustomFormat { get; set; }
		public override string CustomFormat { get; set; }
		
		public StdOutTarget (string identifier = "StdOutTarget", bool logImmediate = false, 
			                 LogLevel highestLevel = LogLevel.WARNING, bool useCustomFormat = false, 
			                 string customFormat = "%l - %t [%T]: %m %e")
			:base(identifier,logImmediate, highestLevel, useCustomFormat, customFormat)
		{}

		public override void log (LogEntry entry)
		{
			if (entry.Level <= HighestLevel)
				if (this.UseCustomFormat)
					Console.WriteLine (entry.toFormatString (this.CustomFormat));
				else
					Console.WriteLine (entry.ToString ()); 
		}
		public override void log (System.Collections.Generic.List<LogEntry> entrys)
		{
			foreach (LogEntry entry in entrys)
				log (entry); 
		}


	}
}

