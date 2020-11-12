using System;
using System.Threading;
using System.Threading.Tasks;

namespace _171
{
    class Program
    {
        static async Task Main(string[] args)
        {
           /* Test test = new Test();
            test.Execute();*/
           var t = await GetData();
           Console.WriteLine (t.ToString());
        }
        private static async Task<string> GetData()
        {
        var result = await Task.Run<string>(() =>
            {
                // Simulate a long-running task.
                Thread.Sleep(120);
                return "Operation Complete.";
            });
        return result;
        }

    }

    public class Test
    {
         public void Execute()
         {
                Class1 class1 = new Class1();

                (new ParameterizedThreadStart (class1.Modify)).Invoke(1);
                (new ParameterizedThreadStart (class1.Modify)).Invoke(2);
                (new ParameterizedThreadStart (class1.Modify)).Invoke(3);
                Console.WriteLine (class1.Value);
         }
     
    }

    public class Class1
    {
        private String _value = String.Empty;
        public String Value 
       {
          get { return _value;}
          set {  _value = value;}
       }
      public void Modify (Object newValue) 
       {
          
           Value +=  newValue.ToString();// proxy.Update (newValue.ToString());
      }
    }

    public static class proxy {
       public static async Task<string> Update(string valor)
        {
           var result = await Task.Run<string>(() =>
            {
                // Simulate a long-running task.
                if ( valor == "2"  )   Thread.Sleep(1);
                return "Operation Complete.";
            });
            return (result);
           
        }
         
    }
}
