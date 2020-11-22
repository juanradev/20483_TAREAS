using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
namespace _274
{
 public class Products
    {
       public string Category { get; set; }
       public string Name { get; set; }
        public override String ToString()
        {
                  return ($" {Category} , {Name}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
             List<Products> products = new List<Products>();
            products.Add(new Products() {Category = "MTB 29", Name= "BH Ultimate RC 7.0"}) ;
             products.Add(new Products() {Category = "BMX", Name= "Monty Bikes 139 Race"}) ;
            products.Add(new Products() {Category = "MTB 29", Name= "Merida Big Nine SLX Edition << Este Nombre es muy largo>>"}) ;
            products.Add(new Products() {Category = "MTB 29", Name= "Fuji SLM 29 2.7"}) ;
            products.Add(new Products() {Category = "Urbanas", Name= "Quer Milano 28  << Este Nombre es muy largo>>"}) ;
            products.Add(new Products() {Category = "BMX", Name= "Monty Bikes Deymos  << Este Nombre es muy largo>>"}) ;
            products.Add(new Products() {Category = "Urbanas", Name= "Quer London 28"}) ;
            products.Add(new Products() {Category = "BMX", Name= "Monty Bikes Fobos"}) ;
            foreach (var c in products) WriteLine(c.ToString());
            WriteLine("        ");

            var LongestNameByCategory = products.GroupBy(p => p.Category)
            .Select(g => new {Category = g.Key, LongestName =g.Select
            (p => p.Name).Aggregate ((s,w) => w.Length > s.Length ? w : s  )});
            
            foreach (var c in LongestNameByCategory) WriteLine(c.ToString());
        
        }
    }


}