using System;
using System.Text;
using System.Text.RegularExpressions; 
using System.Collections.Generic; 

namespace fanaticae.Logger
{
	public class LogEntry
	{
		public LogLevel Level { get; set; }
		public DateTime DateTime {get; set;}
		public string Tag {get; set;}
		public string Message { get; set; }
		public Exception Exception {get; set;}

		private static Dictionary<string, string> RegexFormatStrings = new Dictionary<string, string>{
			{"%l","{0}"},
			{"%t","{1}"}, 
			{"%T","{2}"},
			{"%m","{3}"},
			{"%e","{4}"}
		}; 

		public LogEntry ()
		{
			Level = LogLevel.INFORMATIONAL; 
			DateTime = DateTime.Now; 
			Tag = ""; 
			Message = ""; 
			Exception = null; 
		}

		public LogEntry(LogLevel Level, string Tag, string Message, Exception Exception = null){
			this.Level = Level; 
			this.DateTime = DateTime.UtcNow; 
			this.Tag = Tag; 
			this.Message = Message; 
			this.Exception = Exception; 
		}

		public override string ToString ()
		{
			return String.Format ("{0} - {1} [{2}]: {3} {4}", getLevelText (Level), DateTime.ToString ("O"), Tag, Message, getExceptionString (Exception)); 
		}

		public string ToFormatString(string format){
			/*
			 *  %l Level     -> {0}
			 *  %t Time      -> {1}
			 *	%T Tag       -> {2} 
			 *  %m Message   -> {3}
			 *  %e Exception -> {4}
			 */
			format = (new Regex (String.Join ("|", RegexFormatStrings.Keys))).Replace (format, m => RegexFormatStrings [m.Value]); 
			return String.Format (format, getLevelText (Level), DateTime.ToString ("O"), Tag, Message, getExceptionString (Exception)); 
		}


		private static string getExceptionString(Exception ex){
			if (ex == null)
				return string.Empty;
			else {
				StringBuilder sb = new StringBuilder (); 
				sb.Append (Environment.NewLine);
				Exception formattingException = ex; 
				for (int i = 0; true; i++) {
					for(int x = 0; x<i; x++) sb.Append(" "); 
					sb.AppendFormat("{0}:{1}",formattingException.GetType().Name,formattingException.Message);
					sb.AppendLine (); 
					if(formattingException.InnerException != null) 
						formattingException = formattingException.InnerException; 
					else break; 
				}
				if (ex.StackTrace != null) {
					sb.AppendLine ("Stack Trace:"); 
					foreach (string s in ex.StackTrace.Split('\n')) {
						sb.Append (" ");
						sb.AppendLine (s); 
					}
				}
				return sb.ToString ();
			}
		}



		private static string getLevelText(LogLevel level){
			switch (level) {
			case LogLevel.EMERGENCY:
				return "EMERGENCY"; 
			case LogLevel.ALERT: 
				return "ALERT";
			case LogLevel.CRITICAL:
				return "CRITICAL";
			case LogLevel.ERROR: 
				return "ERROR"; 
			case LogLevel.WARNING: 
				return "WARNING";
			case LogLevel.NOTICE: 
				return "NOTICE";
			case LogLevel.INFORMATIONAL: 
				return "INFORMATIONAL";
			case LogLevel.DEBUG: 
				return "DEBUG"; 
			default: 
				throw new Exception ("Nonexistent LogLevel"); 
			}
		}
	}
}

