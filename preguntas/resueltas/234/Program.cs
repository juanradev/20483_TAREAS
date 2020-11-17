using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;

namespace _234
{

    public class Customer
    {
        String FirstName { get; set; }
        public String LastName { get; set; }
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override String ToString()
        {
            return ($" {LastName} , {FirstName}");
        }
    }


    class Program
    {


        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Vicente", "Dorado Moreno"));
            customers.Add(new Customer("Angel", "Gil Fernández"));
            customers.Add(new Customer("Juan Ramón", "Díaz Fernández"));
            customers.Add(new Customer("Alberto", "Delgado Rubio"));
            customers.Add(new Customer("Fernando", "Garcia"));
            customers.Add(new Customer("Fernando", "Velazquez"));
            customers.Add(new Customer("Luis Miguel", "Arkonada"));
            foreach (Customer c in customers) WriteLine(c.ToString());
            WriteLine("        ");
            var queryqroup = (from c in customers
                              group c by
                              new { FirstLetter = c.LastName[0] }
                into customerGroup
                              orderby customerGroup.Key.FirstLetter,
            select customerGroup);
            foreach (var customergroup in queryqroup)
            {
                Console.WriteLine($"Grupo : {customergroup.Key}  Total: {customergroup.Count().ToString()}");
                foreach (Customer c in customergroup)
                {
                    Console.WriteLine(c.ToString());
                }
            }
        }
    }


}
