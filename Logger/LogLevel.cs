using System;

namespace fanaticae.Logger
{
	/// <summary>
	/// The Priority-Level of the Log Message, adjusted to Syslog Priority Selector
	/// </summary>
	public enum LogLevel
	{
		EMERGENCY = 0, 
		ALERT = 1, 
		CRITICAL = 2, 
		ERROR = 3, 
		WARNING = 4, 
		NOTICE = 5, 
		INFORMATIONAL = 6, 
		DEBUG = 7
	}
}

