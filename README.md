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
  Cachesize can be choosen. (Maximal Cache time is in development) 
  Caching can be disabled for each Output.
  You can set a lowest level to be cached, so that a message with a level lower than this one flushes the cache and writes immediately to all outputs. 
 - Custom Output Format  
  Allows you to change output format to individual needs (very simple currently, to be improved)
 - Multiple onfigurable Outputs (which can be changed during runtime)  
  Simply overload one Class to create another output posibility. You can add and remove them at any time during runtime, using a string identifier. 
