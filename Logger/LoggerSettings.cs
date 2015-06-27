using System;

namespace fanaticae.Logger
{
	public class LoggerSettings
	{
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="fanaticae.Logger.Log"/> uses cache.
		/// </summary>
		/// <value><c>true</c> if use cache; otherwise, <c>false</c>.</value>
		public bool UseCache {get; set;}
		/// <summary>
		/// Gets or sets the lowest cached level. If  the level is Lower than Lowest Cached Level the writing Process will be trigger'd. 
		/// </summary>
		/// <value>The lowest cached level.</value>
		public LogLevel LowestCachedLevel { get; set; }
		/// <summary>
		/// Gets or sets the size of the cache. As soon as the cache holds more items than this property indicates, the writing process will be trigger'd.
		/// </summary>
		/// <value>The size of the cache.</value>
		public int CacheSize { get; set; }
		/// <summary>
		/// Gets or sets the max cache time in milliseconds.
		/// The max cache time might not be 0! Set UseCache to false instead!
		/// This is 5000 (5 seconds) per default. 
		/// </summary>
		/// <value>The max cache time.</value>
		public int MaxCacheTime { get; set;}

		public LoggerSettings(bool UseCache = true, LogLevel lowestCachedLevel = LogLevel.WARNING, int cacheSize = 10, int maxCacheTime = 5000){
			this.UseCache = UseCache; 
			this.LowestCachedLevel = lowestCachedLevel; 
			this.CacheSize = cacheSize; 
			this.MaxCacheTime = maxCacheTime; 
		}
	}
}

