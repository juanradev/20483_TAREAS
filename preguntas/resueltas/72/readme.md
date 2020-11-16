### QUESTION 72

#### 

You are developing an application by using C#.  
The application includes an object that performs a long running process.  
You need to ensure that the garbage collector does not release the object's resources until the process
completes.  
Which garbage collector method should you use?  

A. RemoveMemoryPressure()  
B. ReRegisterForFinalize()  
C. WaitForFullGCComplete()  
D. **KeepAlive()**    
E. Collect()  

Correct Answer: D

https://docs.microsoft.com/es-es/dotnet/api/system.gc.keepalive?view=net-5.0  


**public static void KeepAlive (object obj);**  


El propósito del **KeepAlive** método es garantizar la existencia de una referencia a un objeto en riesgo de que el recolector de elementos no utilizados pueda reclamar prematuramente. Un escenario común en el que esto puede ocurrir es cuando no hay ninguna referencia al objeto en el código o en los datos administrados, pero el objeto todavía se utiliza en código no administrado, como las API de Windows, los archivos dll no administrados o los métodos que utilizan COM.
Este método hace referencia al obj parámetro, lo que hace que ese objeto no sea válido para la recolección de elementos no utilizados desde el inicio de la rutina hasta el punto, en orden de ejecución, donde se llama a este método. Codifique este método al final, no al principio, del intervalo de instrucciones donde obj debe estar disponible.
El KeepAlive método no realiza ninguna operación y no produce ningún efecto secundario que no sea extender la duración del objeto pasado como parámetro.
 
 
a.  RemoveMemoryPressure()  Informa al tiempo de ejecución de que se ha liberado la memoria no administrada y ya no se necesita tener en cuenta al programar la recolección de elementos no utilizados.  

b.  ReRegisterForFinalize()  Solicita que el sistema llame al finalizador del objeto especificado, para el que previamente se ha llamado a SuppressFinalize(Object).  

c.  WaitForFullGCComplete() Devuelve el estado de una notificación registrada para determinar si se ha completado una recolección completa de elementos no utilizados bloqueada por parte de Common Language Runtime.

d.  **KeepAlive**() Hace referencia al objeto especificado, convirtiéndolo en un objeto no válido para la recolección de elementos no utilizados desde el principio de la rutina actual hasta el momento en que se llamó a este método.

e. Collect()  Fuerza a que se lleve a cabo la recolección de elementos no utilizados.