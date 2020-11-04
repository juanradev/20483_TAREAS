## Module 5: Creating a Class Hierarchy by Using Inheritance

### Lesson 1: Creating Class Hierarchies


##### Demonstration: Calling Base Class Constructors


Revisión de la clase Beverage .

```` c#

public class Beverage
{
    public string Name { get; set; }
    public bool IsFairTrade { get; set; }

    protected int servingTemperature;

    public Beverage()  // Construcción predeterminado
    {
        IsFairTrade = false;
        servingTemperature = 175;
        Name = "Not known";
    }
    public Beverage(string name, bool isFairTrade, int servingTemp) // constructor alternativo
    {
        this.Name = name;
        this.IsFairTrade = isFairTrade;
        this.servingTemperature = servingTemp;
    }
    public virtual int GetServingTemperature()
    {
        return servingTemperature;
    }
}
````

Revisión de la clase Coffee 

```` c#
 class Coffee : Beverage // hereda de Beverage
    {
        public string Bean { get; set; }
        public string Roast { get; set; }
        public string CountryOfOrigin { get; set; }

        public Coffee()
        {
            Bean = "Not known";
            Roast = "Medium";
            CountryOfOrigin = "Not known";
        }

        public Coffee(string name, bool isFairTrade, int servingTemp, string bean, string roast, string countryOfOrigin)
            : base(name, isFairTrade, servingTemp)
        {
            Bean = bean;
            Roast = roast;
            CountryOfOrigin = countryOfOrigin;
        }                                   //    : base(name, isFairTrade, servingTemp) llama al constructor de Beverage 
    }
````

ejecución del programa

coffe = new Coffee() llama al constructor por defecto de su clase base  
nota: primero ejectuta el constructor de la clase base    
![coffe = new Coffee())](./captura1.PNG)

 Coffee coffee2 = new Coffee("Fourth Espresso", true, 170, "Arabica", "Dark", "Columbia");   
Coffee(string name, bool isFairTrade, int servingTemp, string bean, string roast, string countryOfOrigin)
            : base(name, isFairTrade, servingTemp) llama al constructor alternativo de la clase base   
![coffe = new Coffee())](./captura2.PNG)



### Lesson 2: Extending .NET Framework Classes


##### Demonstration: Refactoring Common Functionality into the User Class Lab


Revisión de la clase abstracta User   
![clase User (abstracta](./captura3.PNG)


Revisión de la clase Student wue hereda de User  
 Observa el override de SetPassword
![clase Student (:User](./captura4.PNG)
![clase Student (:User](./captura5.PNG)
 
 
 
 Revisión de la clase ClassFullException   
 ![clase ClassFullException](./captura6.PNG)   
 
  Revisión de la clase Teacher
  
 ![clase Teacher (:User](./captura7.PNG)  
 
 
 Ejecución del programa 
 
  ![captura8](./captura8.PNG)    

  ![captura9](./captura9.PNG)  

  ![captura10](./captura10.PNG)  

  ![captura11](./captura11.PNG)  

 
 
 


