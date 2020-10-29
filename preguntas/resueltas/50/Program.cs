using System;
using System.IO;
using System.Xml.Serialization;
 
namespace _50
{
    class Program
    {
        static void Main(string[] args)
        {
           // se trata de serializar a un xml con el mismo formato que la pregunta
           Customer customer = new Customer("David Jones", DateTime.Parse("1970-06-11"));
           
/* no hace falta porque ya los hemos decorado 
            XmlAttributes attrs = new XmlAttributes();
            XmlElementAttribute attr = new XmlElementAttribute();
            attr.ElementName = "FullName";
            attr.Type = typeof(String);
            attrs.XmlElements.Add(attr);
            attr.ElementName = "DateOfBirth";
            attr.Type = typeof(DateTime);
            attrs.XmlElements.Add(attr);
            attr.ElementName = "ProsPectId";
            attr.Type = typeof(Guid);
            attrs.XmlElements.Add(attr);
            XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();
            attrOverrides.Add(typeof(Customer), "ProsPect", attrs);
            XmlSerializer s =  new XmlSerializer(typeof(Customer), attrOverrides);
*/
  
            XmlSerializer s =  new XmlSerializer(typeof(Customer));
           FileStream buffer = File.Create(@".\salida.xml");
           s.Serialize(buffer,customer);
           buffer.Close();
           Console.WriteLine(@"serializacion efectuada. fichero: .\salida.xml ");

            string readText = File.ReadAllText(@".\salida.xml");
            Console.WriteLine(readText);
            Console.ReadKey();

        }
    }

    [XmlRoot("ProsPect", Namespace="http://prospect")]
    public class Customer {
        [XmlAttribute("ProsPectId")]
        public Guid Id {get;set;}
        [XmlElement("FullName")]
        public string Name {get;set;}
        public DateTime DateOfBirth {get;set;}
        [XmlIgnore]
         public int tin {get;set;}
    
        public Customer () {}  

        public Customer (string name, DateTime dateofbirth){
            this.Name = name;
            this.DateOfBirth = dateofbirth;
            this.tin = 0;
            this.Id = Guid.NewGuid();
        }
    
    }

}
