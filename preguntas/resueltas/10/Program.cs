using System;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.DoWork(new object());
        }
        public interface IDataContainer
        {
            string Data { get; set; }
        }
        public void DoWork(object obj)
        {
            // var dataContainer = (IDataContainer)obj;   /// System.InvalidCastException
            // dynamic dataContainer = obj;  // RuntimeBinderException
            //var dataContainer = obj is IDataContainer; //ERROR E COMPILACION
            var dataContainer = obj as IDataContainer;
            if (dataContainer != null)
            {
                Console.WriteLine(dataContainer.Data);
            }
            else
            {
                Console.WriteLine("dataContainer es null");
            }
        }

    }
}
