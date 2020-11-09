using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace _174
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().CancellingTask();
        }

        private void CancellingTask()
        {
            var tokenSource2 = new CancellationTokenSource();
            CancellationToken ct = tokenSource2.Token;
            var task = Task.Run(() =>
            {
                // Were we already canceled?
                ct.ThrowIfCancellationRequested();
                Write("Trabajando.");
                bool moreToDo = true;
                while (moreToDo)
                {
                    Thread.Sleep(10);
                    Write("..");
                    if (ct.IsCancellationRequested)
                    {
                         WriteLine("Lanzando la excepcion..");
                        ct.ThrowIfCancellationRequested();
                    }
                }
            }, tokenSource2.Token); // Pass same token to Task.Run.

           

            try
            {
                
               
                  Thread.Sleep(100);
                   WriteLine("");
                  WriteLine("cancel");
                   tokenSource2.Cancel();
                    task.Wait();
            }
            catch (OperationCanceledException e) // Cuando sea asyncrono
            {
                WriteLine("final");
                WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");
            }
            catch (AggregateException e)  //Syncrono -> Será generado si el método no es definido como async wait
            {
                WriteLine($"Message: {e.InnerException}");
            }
            catch (SystemException e)
            {
                WriteLine($"Message: {e.Message}");
            }
            finally
            {
                tokenSource2.Dispose();
            }
            WriteLine("Press Any Key to continue...");
            ReadKey();
        }
    }
}
