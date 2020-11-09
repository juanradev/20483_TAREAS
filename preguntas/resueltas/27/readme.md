### QUESTION 27 

##### lock


You are adding a public method named UpdateScore to a public class named ScoreCard.  
The code region that updates the score field must meet the following requirements:  
It must be accessed by only one thread at a time.  
It must not be vulnerable to a deadlock situation.  
You need to implement the UpdateScore() method.  
What should you do?   


Opcion A  
Place the code region inside the following lock stament  
```c#
lock (this)
{ ....................
}
````
Opcion B  
Add a __private__ object named lockObject to he ScoredCard class. Place the code region insedi the follwing lock stament:  
```c#
lock (lockObject)
{ ....................
}
````
Opcion C   
Apply the following attribute to the UpdateScore() method signature
```c#
[MethodImp (MethodImpOptions.Synchronized)]
````
Opcion D   
Add a **public** static object name lockObject to the SocreCard class. Place the code region insede the following lock stament:
```c#
lock (typeof(SocreCard))
````

Respuesta: B 


nota:
Para prevenir bloqueos y que solo pueda acceder un proceso utilizamos lock  
 la sintaxis de lock es:
lock ( object ) { statement block }   donde el objeto debe ser **privado** y **no** debe tener **más lógica**.

ejemplo de sintaxis
````c#
class Coffee
{
   private object coffeeLock = new object();
   int stock;
   public Coffee(int initialStock)
   {
      stock = initialStock;
   }
   public bool MakeCoffees(int coffeesRequired)
   {
      lock (coffeeLock)
      {
         if (stock >= coffeesRequired)
         {            
            Console.WriteLine(String.Format("Stock level before making coffees: {0}", stock));
            stock = stock – coffeesRequired;
            Console.WriteLine(String.Format("{0} coffees made", coffeesRequired));
            Console.WriteLine(String.Format("Stock level after making coffees: {0}", stock));
            return true;
         }
         else
         {
            Console.WriteLine("Insufficient stock to make coffees");
            return false;
         }
      }
   }
}
``````````````






