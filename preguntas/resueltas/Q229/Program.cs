using System.Diagnostics;
using System;
namespace Q229
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            new TestClass().RunTestClass();
        }
    }
    public class TestClass
    {
        [Conditional("DEBUG")]
        public void LogData()
        {
            Trace.Write("LogData1\n");
        }
        public void RunTestClass()
        {
            this.LogData();
#if (DEBUG)
            Trace.Write("LogData2\n");
#endif
        }
    }
}
