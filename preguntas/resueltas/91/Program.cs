using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Xml;
using System.IO;

namespace _91
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Contact(int id, string f, string l)
        {
            ContactId = id;
            FirstName = f;
            LastName = l;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Contact> list = new List<Contact>();
            list.Add(new Contact(1, "ana", "diaz"));
            list.Add(new Contact(2, "miguel", "diaz"));
            list.Add(new Contact(3, "juan", "diaz"));
            list.Add(new Contact(4, "alberto", "diaz"));
            list.Add(new Contact(5, "chiqui", "diaz"));


            XNamespace ew = "ContactList";
           XElement root = new XElement(ew + "Root");


// XElement root = new XElement("{ContactList}contacts","contact");

            Console.WriteLine(root);


           XElement contacts = new XElement("contacts",
             from c in list
             orderby c.ContactId
             select new XElement("contact",
                new XAttribute("contactID", c.ContactId),
                new XAttribute("firstname", c.FirstName),
                new XAttribute("lastname", c.LastName)
             ));
            System.Console.WriteLine(contacts);

            root.Add(contacts);
            using (MemoryStream ms = new MemoryStream())
            {
                using (XmlWriter xw = XmlWriter.Create(ms))
                {
                    root.WriteTo(xw);
                }
                StreamReader sr = new StreamReader(ms);
                String mystring = sr.ReadToEnd();
                System.Console.WriteLine(mystring);
            }
            
   

        }


    }
}