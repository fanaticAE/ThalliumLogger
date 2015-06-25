using System;
using System.Collections.Generic; 

namespace fanaticae.Logger
{
	class EntryCache
	{
		public int Size{get; set;}
		public bool HasEntrys{
			get{
				lock (_lock)
					return (cache.Count > 0); 
			}
		}
		public bool NeedsStoring {
			get {
				lock (_lock)
					return (cache.Count >= Size);
			}
		}


		Queue<LogEntry> cache = new Queue<LogEntry>(); 
		object _lock = new object (); 


		public EntryCache (int size)
		{
			this.Size = size; 
		}

		public void Enqueue(LogEntry entry){
			lock (_lock)
				cache.Enqueue (entry); 
		}

		public LogEntry Dequeue(){
			lock (_lock)
				return cache.Dequeue (); 
		}

		public List<LogEntry> ToList(){
			return new List<LogEntry> (cache.ToArray ()); 
		}
		public void Drop(){
			cache.Clear (); 
		}
	}
}

