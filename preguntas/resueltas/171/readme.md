### QUESTION 171 

##### lock(object)

You have the following class (line numbers are included for reference only):

```` c#

01    public class Class1
02    {
03        private String value = String.Empty;
04        private ServiceProxy proxy = new ServiceProxy();
05  
06        public String Value 
07        {
08            get { return Value;}
09        }
10        public void Modify (Object newValue) 
11        {
12
13            Value += proxy.Update (newValue.ToString());
14        }
15    }
16    public class Test 
17    {
18        public void Execute()
19        {
20        Class1 class1 = new Class1();
21        (new ParameterizedThreadStart (class1.Modify)).Invoke(1);
22        (new ParameterizedThreadStart (class1.Modify)).Invoke(2);
23        (new ParameterizedThreadStart (class1.Modify)).Invoke(3);
24        Console.WriteLine (class1.Value);
25        }
26    }

````
ServiceProxy is a proxy for a web service. Calls to the Update method can take up to five seconds. The Test
class is the only class the uses Class1.  
You run the Execute method three times, and you receive the following results:  
213  
312  
231  

You need to ensure that each value is appended to the Value property in the order that the Modify methods are
invoked.   
What should you do?

Opcion A  
```` 
    Insert the following at line 5  
            Object obj = new Object();
    Insert the following at line 12    
            Monitoring.Enter(obj1);
```` 

Opcion B 
```c# 
    Insert the following at line 5  
            Object obj = new Object();
    Insert the following at line 12 
            lock(obj1)
````  

Opcion C  
```c#
    Insert the following at line 12 
            Monitoring.Enter(this);
````  
Opcion D
```c#
    Insert the following at line 12 
             lock(Value)
````  



Respuesta correcta B:

siempre que hablemos de bloqueo recordemos que la sintaxis es lock(Objeto) { ..... }
y que el objeto debe ser privado y no tener ningún tipo de lógica asociado

Monitor: tambien proporciona un mecanismo de bloqueo mediante 
Monitor.Enter (objetobloqueado);
  codigo que usa objetobloqueado de forma exclusiva
Monitor.Exit (objetobloqueado);





