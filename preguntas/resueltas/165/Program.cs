using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _165
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the source, if it does not already exist.
            if (!EventLog.SourceExists("MySource"))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("MySource", "MyNewLog");
                Console.WriteLine("CreatedEventSource");
                Console.WriteLine("Exiting, execute the application a second time to use the source.");
                // The source is created.  Exit the application to allow it to be registered.
                return;
            }

            WriteToEventLog("mensaje1", EventLogEntryType.Information);

            Console.ReadKey();

        }


        public static void WriteToEventLog(string message, EventLogEntryType eventlogeventtype)
        {
            EventLog eventlog = new EventLog() { Source = "MySource", EnableRaisingEvents = true };
            eventlog.WriteEntry(message, eventlogeventtype);
        }

    }
}
