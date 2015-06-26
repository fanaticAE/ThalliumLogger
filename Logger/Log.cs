using System;

namespace fanaticae.Logger
{
	
	public static class Log
	{	
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="fanaticae.Logger.Log"/> uses cache.
		/// </summary>
		/// <value><c>true</c> if use cache; otherwise, <c>false</c>.</value>
		public static bool UseCache { get { return logger.UseCache; } set { logger.UseCache = value; } }
		/// <summary>
		/// Gets or sets the lowest cached level. If  the level is Lower than Lowest Cached Level the writing Process will be trigger'd. 
		/// </summary>
		/// <value>The lowest cached level.</value>
		public static LogLevel LowestCachedLevel { get{ return logger.LowestCachedLevel; } set{ logger.LowestCachedLevel = value; } }
		/// <summary>
		/// Gets or sets the size of the cache. As soon as the cache holds more items than this property indicates, the writing process will be trigger'd.
		/// </summary>
		/// <value>The size of the cache.</value>
		public static int CacheSize { get{ return logger.CacheSize; } set{ logger.CacheSize =value; } }

		/// <summary>
		/// Gets a value indicating whether this <see cref="fanaticae.Logger.Log"/> is running.
		/// </summary>
		/// <value><c>true</c> if running; otherwise, <c>false</c>.</value>
		public static bool Running{ get { return logger.Running; } }

		static Logger logger = new Logger(new LoggerSettings()); 

		/// <summary>
		/// Starts the Logger. If already started an Exception will be Thrown
		/// </summary>
		public static void Start(){ 
			logger.Start (); 
		}
		/// <summary>
		/// Stop the Logger. Mulitple calls will be ignored.
		/// Warning: This may take up to 2 seconds.  
		/// </summary>
		public static void Stop(){
			logger.Stop (); 
		}

		/// <summary>
		/// Applies the settings.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public static void ApplySettings(LoggerSettings settings){
			logger.applySettings (settings);
		}

		/// <summary>
		/// Adds a target. If a target with the same identifier is already added an exception will be thrown. 
		/// </summary>
		/// <param name="target">Target.</param>
		public static void AddTarget(LogTarget target)
		{
			logger.AddTarget (target);
		}

		/// <summary>
		/// Removes the target with the given Identifier. If no target with this identifier is given, the call will have no effect. 
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		public static void RemoveTarget(string identifier)
		{
			logger.RemoveTarget (identifier); 
		}

		#region Public Logging Methods

		#region Emergency
		/// <summary>
		/// Logs an Message at Emergency Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Emergency(string tag, string message, params object[] args){
			addLogEntry (LogLevel.EMERGENCY, tag, message, args); 
		}
		/// <summary>
		/// Logs an Message and Exception at Emergency Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="exception">Exception.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Emergency(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.EMERGENCY, tag, message, args, exception); 
		}
		#endregion

		#region Alert

		/// <summary>
		/// Logs an Message at Alert Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Alert(string tag, string message, params object[] args){
			addLogEntry (LogLevel.ALERT, tag, message, args); 
		}
		/// <summary>
		/// Logs an Message and Exception at Alert Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="exception">Exception.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Alert(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.ALERT, tag, message, args, exception); 
		}
		#endregion

		#region Critical

		/// <summary>
		/// Logs an Message at Critical Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Critical(string tag, string message, params object[] args){
			addLogEntry (LogLevel.CRITICAL, tag, message, args); 
		}
		/// <summary>
		/// Logs an Message and Exception at Critical Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="exception">Exception.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Critical(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.CRITICAL, tag, message, args, exception); 
		}
		#endregion

		#region Error

		/// <summary>
		/// Logs an Message at Error Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Error(string tag, string message, params object[] args){
			addLogEntry (LogLevel.ERROR, tag, message, args); 
		}
		/// <summary>
		/// Logs an Message and Exception at Error Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="exception">Exception.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Error(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.ERROR, tag, message, args, exception); 
		}
		#endregion

		#region Warning

		/// <summary>
		/// Logs an Message at Warning Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Warning(string tag, string message, params object[] args){
			addLogEntry (LogLevel.WARNING, tag, message, args); 
		}
		/// <summary>
		/// Logs an Message and Exception at Warning Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="exception">Exception.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Warning(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.WARNING, tag, message, args, exception); 
		}
		#endregion

		#region Notice

		/// <summary>
		/// Logs an Message at Notice Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Notice(string tag, string message, params object[] args){
			addLogEntry (LogLevel.NOTICE, tag, message, args); 
		}

		/// <summary>
		/// Logs an Message and Exception at Notice Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="exception">Exception.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Notice(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.NOTICE, tag, message, args, exception); 
		}
		#endregion

		#region Info

		/// <summary>
		/// Logs an Message at Informational Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Info(string tag, string message, params object[] args){
			addLogEntry (LogLevel.INFORMATIONAL, tag, message, args); 
		}

		/// <summary>
		/// Logs an Message and Exception at Informational Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="exception">Exception.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Info(string tag, Exception exception, string message, params object[] args){
			addLogEntry (LogLevel.INFORMATIONAL, tag, message, args, exception); 
		}
		#endregion

		#region Debug

		/// <summary>
		/// Logs an Message at Debug Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Debug(string tag, string message, params object[] args){
			addLogEntry (LogLevel.DEBUG, tag, message, args); 
		}

		/// <summary>
		/// Logs an Message and Exception at Debug Level 
		/// Message and Args work like String.Format. 
		/// </summary>
		/// <param name="tag">Tag.</param>
		/// <param name="exception">Exception.</param>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public static void Debug(string tag, Exception exception, string message, params object[] args){
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

