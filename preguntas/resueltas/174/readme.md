### QUESTION 174 

##### CancellationToken

You are implementing a method named ProcessData that performs a long-running task. The ProcessData()
method has the following method signature:
```` c#
public void ProcessData(List<decimal> values, CancellationTokenSource source, CancellationToken token)
````

If the calling code requests cancellation, the method must perform the following actions:  
. Cancel the long-running task.   
. Set the task status to TaskStatus.Canceled.    
You need to ensure that the ProcessData() method performs the required actions.    

Which code segment should you use in the method body?
  
A. if (token.IsCancellationRequested)return;  
B. throw new AggregateException();  
C. token.ThrowIfCancellationRequested();  
D. source.Cancel();  





Respuesta correcta C) token.ThrowIfCancellationRequested();  

Explicación:  

B) la descratamos directamente....   
D) source.Cancel() ===> Estvale para cancelar la tarea, pero lo envia el hilo principal, no está en el method body.   
A) if (token.IsCancellationRequested)return;  sale del metodo por el return pero no generar la excepcion para controlar el TaskStatus   
C) repuesta correcta : token.ThrowIfCancellationRequested();      


un modelo de cancleación funciona así:  


1. Cuando crea una tarea, también crea un token de cancelación.
2. Pasas el token de cancelación como argumento a tu método de delegado.
```
		CancellationTokenSource cts = new CancellationTokenSource();
		CancellationToken ct = cts.Token;
		var task1 = Task.Run(() => doWork(ct), ct);
```


3. En el hilo que creó la tarea, solicitas la cancelación llamando al método Cancel del token de cancelación.
```
cts.Cancel();
```


4.- en el cuerpo de la tarea se comprueba si ha recibido la orden de cancelar. si la ha recibido lanza la excepcion
```
  if (ct.IsCancellationRequested)
                    {
                         WriteLine("Lanzando la excepcion..");
                        ct.ThrowIfCancellationRequested();
                    }
```					
4. En su método de princial, puede verificar el estado del token de cancelación en cualquier momento. (preguntando a la excepcion  is TaskCanceledException)
```

            catch (OperationCanceledException e) // Cuando sea asyncrono
            {
                WriteLine("final");
                WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");
            }
            catch (AggregateException e)  //Syncrono -> Será generado si el método no es definido como async wait
            {
                WriteLine($"Message: {e.InnerException}"); // Message: System.Threading.Tasks.TaskCanceledException: A task was canceled.
            }
```





```` c#
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
````