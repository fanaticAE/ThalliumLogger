# ThalliumLogger
Thallium Logger is the descendant of Mercury Logger (which is deprecated by now). 
It provides an Singleton which allows you to Log from every point in your application. 

It offers: 
 - Threaded Logging  
  To keep the time it takes in your mainthread low, you just put the message into a cache and the logging thread will take care of the rest. 
 - Multiple Log Levels in Syslog-Style  
  The syslog priority selectors are in place.
  Each Output can have it's own maximum level to log. 
  You can, for example, choose, that only Emergency-Messages are logged to STDERR.  
 - Tagging  
  Each Message can be given it's own tag. 
 - Caching  
  Cachesize and maximum time can be choosen.
  Caching can be disabled for each Output.
  You can set a lowest level to be cached, so that a message with a level lower than this one flushes the cache and writes immediately to all outputs. 
 - Custom Output Format  
  Allows you to change output format to individual needs (very simple currently, to be improved)
 - Multiple onfigurable Outputs (which can be changed during runtime)  
  Simply overload one Class to create another output posibility. You can add and remove them at any time during runtime, using a string identifier. 

##Example 

    Log.Start (); 
Starts the logging thread. If called multiple times it will throw an Exception.

    Log.LowestCachedLevel = LogLevel.EMERGENCY; 
Sets the lowest cached Level to emergency, so all messages will be cached.  
This should not be used in reality, is just used in this example.  
If there would be a log message with a level < Emergency it would flush the whole buffer when it appears.  

    Log.addTarget (new StdOutTarget ("ImmediateSTDOUT", true, LogLevel.CRITICAL)); 
 This adds a target that logs to STDOUT. It has the identifier _ImmediateSTDOUT_ and will log immediately. Everything below or equal to LogLevel.Critical will be logged. 
 
    Log.addTarget (new StdOutTarget ("StdOutTarget", false, LogLevel.DEBUG)); 
This also adds a target which will log everything to STDOUT but cached.


    Log.debug ("TAG", "Debug"); 
This will log the message "Debug" with the tag "TAG" at level _debug_. Since the level is higher than _critical_ _ImmediateSTDOUT_ will ignore that message, and logged by _StdOutTarget_ as soon as the cache gets flushed.  
Until now there is no output produced.  

    Log.info ("TAG", "message");
The same as above but with a different level and message. 

    Log.critical ("TAG", "Critical"); 
Here the Level is at critical, so _ImmediateSTDOUT_ logs the message. 
The following output is produced:
     CRITICAL - 2015-06-26T21:55:36.5230160Z [TAG]: Critical

    	Thread.Sleep (5000); 
After waiting for the maximum cache time the rest is also logged. The generated output is:

     DEBUG - 2015-06-26T21:55:36.5208440Z [TAG]: Debug
     INFORMATIONAL - 2015-06-26T21:55:36.5229770Z [TAG]: message
     CRITICAL - 2015-06-26T21:55:36.5230160Z [TAG]: Critical

So the complete output will be: 

     CRITICAL - 2015-06-26T21:55:36.5230160Z [TAG]: Critical
     DEBUG - 2015-06-26T21:55:36.5208440Z [TAG]: Debug
     INFORMATIONAL - 2015-06-26T21:55:36.5229770Z [TAG]: message
     CRITICAL - 2015-06-26T21:55:36.5230160Z [TAG]: Critical

    Log.Stop(); 
Is finally called to completely stop the logger. 
