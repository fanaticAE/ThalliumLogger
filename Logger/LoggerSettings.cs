using System;

namespace fanaticae.Logger
{
	public class LoggerSettings
	{
		public bool UseCache {get; set;}
		public LogLevel LowestCachedLevel { get; set; }
		public int CacheSize { get; set; }
		/// <summary>
		/// Gets or sets the max cache time in milliseconds.
		/// The max cache time might not be 0! Set UseCache to false instead!
		/// This is 5000 (5 seconds) per default. 
		/// </summary>
		/// <value>The max cache time.</value>
		public int MaxCacheTime { get; set;}

		public LoggerSettings(){
			this.UseCache = true; 
			this.LowestCachedLevel = LogLevel.WARNING; 
			this.CacheSize = 10; 
			this.MaxCacheTime = 5000; 
		}
	}
}

