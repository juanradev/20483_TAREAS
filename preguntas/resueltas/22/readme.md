## QUESTION 22   __ERRATA__ __ERRATA__ 
DRAG DROP  

You have a class named Product that has a property named Name.  
You have the following code.  

![c1.PNG](C1.PNG)

You need to get the Name property of oneProduct.  
How should you complete the code? To answer, drag the appropriate code elements to the correct targets.  
Each code element may be used once, more than once, or not at all. You may need to drag the split bar
between panes or scroll to view content.  
NOTE: Each correct selection is worth one point.  


![c2.PNG](C2.PNG)


SOLUCION  __ERRATA__ __ERRATA__ __ERRATA__ __ERRATA__ __ERRATA__ __ERRATA__ 

![c2.PNG](C3.PNG)


SOLUCION CORRECTA

GetType   
GetProperties  
GetValue  
oneProduct  

string productName = oneProduct.GetType().GetProperties().First(prop=> prop.Name =="Name").GetValue (oneProduct).ToString();


````
using System;
using System.Linq;
using System.Reflection;

namespace _22
{
    class Program
    {
        static void Main(string[] args)
        {
            Product oneProduct = new Product() {Id=1, Name="Cocacola", CategoryId=3};
            string productName = oneProduct.GetType().GetProperties().First(prop=> prop.Name =="Name").GetValue (oneProduct).ToString();
            System.Console.WriteLine(productName);
         }

    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
      
}

`````

Output Cocacola

(Product oneProduct = new Product() {Id=1, Name="Cocacola", CategoryId=3};)