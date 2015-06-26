using System;
using System.IO; 
using System.Collections.Generic; 
using System.Threading; 

namespace fanaticae.Logger
{
	class Logger
	{
		#region Settings 
		public bool UseCache { get { return this.settings.UseCache; } set { this.settings.UseCache = value; } }
		public LogLevel LowestCachedLevel { get { return this.settings.LowestCachedLevel; } set { this.settings.LowestCachedLevel = value; } }
		public int CacheSize { 
			get { return this.settings.CacheSize; } 
			set { 
				this.settings.CacheSize = value;
				this.cache.Size = value; 
			} 
		}
		public int MaxCacheTime { get { return this.settings.MaxCacheTime; } set { this.settings.MaxCacheTime = value; } }

		private LoggerSettings settings = new LoggerSettings (); 

		public void applySettings(LoggerSettings settings){
			this.settings = settings; 
			this.cache.Size = settings.CacheSize; 
		}
		#endregion

		public bool Running {get{return this.running;}}

		private EntryCache cache; 
		private Thread loggingThread; 
		private bool running = false; //Thread
		private bool active = false;  //Execution
		private AutoResetEvent doLog = new AutoResetEvent(false); 

		private Dictionary<string, LogTarget> targets = new Dictionary<string, LogTarget> (); 

		public Logger (LoggerSettings settings = null)
		{
			this.cache = new EntryCache (this.settings.CacheSize); 
			this.loggingThread = new Thread (executeLogging); 
			if(settings != null)	
				this.applySettings (settings); 
		}

		public void Start(){
			if (!running) {
				loggingThread.Start (); 
				running = true; 
			}
			else throw new Exception ("Already Running");
		}

		public void Stop(){
			if (running) {
				Flush (); 
				running = false; 
				if (!loggingThread.Join (1000)) { 
					loggingThread.Abort ();
					loggingThread.Join (100); 
				}
				writeLog (); 
			}
		}

		public void AddTarget(LogTarget target){
			if (targets.ContainsKey (target.Identifier))
				throw new Exception ("Identifier is already in use"); 

			targets.Add (target.Identifier, target); 
		}

		public void RemoveTarget(string identifier, bool flushBeforeRemoval = true){
			if (flushBeforeRemoval)
				Flush (); 
			if (targets.ContainsKey (identifier))
				targets.Remove (identifier); 
		}

		public void Log(LogEntry entry){
			foreach (LogTarget t in targets.Values)
				if (t.LogImmediate)
					t.Log (entry); 

			cache.Enqueue (entry); 

			if (this.running && this.active && (!this.settings.UseCache ||cache.NeedsStoring || (entry.Level > this.settings.LowestCachedLevel)))
				doLog.Set (); 
		}

		public void Flush(){
			if (running && !active) {
				doLog.Set (); 
			}
		}

		private void writeLog(){
			foreach (LogTarget t in targets.Values) 
				if (!t.LogImmediate)
					t.Log (cache.ToList ()); 
			cache.Drop (); 
		}
		private void executeLogging(){
			do {
				doLog.WaitOne(this.settings.MaxCacheTime); 
				this.active = true; 

				//...
				writeLog(); 
				//...

				this.active = false; 
			} while(running); 
		}

	}
}

