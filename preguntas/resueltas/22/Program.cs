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

