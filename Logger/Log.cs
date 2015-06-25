using System;

namespace fanaticae.Logger
{
	
	public static class Log
	{	
		public static bool UseCache { get { return logger.UseCache; } set { logger.UseCache = value; } }
		public static LogLevel LowestCachedLevel { get{ return logger.LowestCachedLevel; } set{ logger.LowestCachedLevel = value; } }
		public static int CacheSize { get{ return logger.CacheSize; } set{ logger.CacheSize =value; } }

		public static bool Running{ get { return logger.Running; } }

		static Logger logger = new Logger(new LoggerSettings()); 

		public static void Start(){
			logger.Start (); 
		}
		public static void Stop(){
			logger.Stop (); 
		}

		public static void applySettings(LoggerSettings settings){
			logger.applySettings (settings);
		}

		public static void addTarget(LogTarget target)
		{
			logger.addTarget (target);
		}

		public static void removeTarget(string identifier)
		{
			logger.removeTarget (identifier); 
		}

		#region Public Logging Methods

		#region Emergency
		public static void emergency(string tag, string message, params object[] args){
			addLogEntry (LogLevel.EMERGENCY, tag, message, args); 
		}
		public static void emergency(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.EMERGENCY, tag, message, args, exception); 
		}
		#endregion

		#region Alert
		public static void alert(string tag, string message, params object[] args){
			addLogEntry (LogLevel.ALERT, tag, message, args); 
		}
		public static void alert(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.ALERT, tag, message, args, exception); 
		}
		#endregion

		#region Critical
		public static void critical(string tag, string message, params object[] args){
			addLogEntry (LogLevel.CRITICAL, tag, message, args); 
		}
		public static void critical(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.CRITICAL, tag, message, args, exception); 
		}
		#endregion

		#region Error
		public static void error(string tag, string message, params object[] args){
			addLogEntry (LogLevel.ERROR, tag, message, args); 
		}
		public static void error(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.ERROR, tag, message, args, exception); 
		}
		#endregion

		#region Warning
		public static void warning(string tag, string message, params object[] args){
			addLogEntry (LogLevel.WARNING, tag, message, args); 
		}
		public static void warning(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.WARNING, tag, message, args, exception); 
		}
		#endregion

		#region Notice
		public static void notice(string tag, string message, params object[] args){
			addLogEntry (LogLevel.NOTICE, tag, message, args); 
		}
		public static void notice(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.NOTICE, tag, message, args, exception); 
		}
		#endregion

		#region Info
		public static void info(string tag, string message, params object[] args){
			addLogEntry (LogLevel.INFORMATIONAL, tag, message, args); 
		}
		public static void info(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.INFORMATIONAL, tag, message, args, exception); 
		}
		#endregion

		#region Debug
		public static void debug(string tag, string message, params object[] args){
			addLogEntry (LogLevel.DEBUG, tag, message, args); 
		}
		public static void debug(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.DEBUG, tag, message, args, exception); 
		}
		#endregion

		#endregion

		private static void addLogEntry(LogLevel logLevel, string tag, string message, object[] args, Exception ex = null){
			if (checkArgs (args))
				logger.Log (new LogEntry (logLevel, tag, string.Format (message, args), ex));
			else
				logger.Log (new LogEntry (logLevel, tag, message, ex)); 
		}
		private static bool checkArgs(object[] args){
			return (args != null && args.Length > 0); 
		}

	}
}

