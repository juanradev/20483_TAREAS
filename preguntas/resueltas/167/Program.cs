using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace _167
{
    class Program
    {
        static void Main(string[] args)
        {

            Serializar();
        }

        public static void Serializar()
        {
            // Create a new instance of the Person class.
            Order order = new Order(26, "Ben Smith", 206, DateTime.Parse("1970-06-11"));
            
            
            XmlSerializer s = new XmlSerializer(typeof(Order));
            FileStream buffer = File.Create(@".\salida.xml");
            XmlSerializer ss = new XmlSerializer(order.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            s.Serialize(buffer, order, ns);
            buffer.Close();
        }
    }

    [DataContract(Name = "Orderd", Namespace = "")]
    [XmlRoot("Order")]
    public class Order
    {
        [DataMember()]
        [XmlAttribute]
        public Int32 OrderID { get; set; }
        [DataMember(Name = "Customer"), XmlElement("Customer")]
        public String CustomerName { get; set; }
        [DataMember()]
        public Int32 CustomerID { get; set; }
        [DataMember()]
        public DateTime OrderDate 
        { get; set; }
 
  

        [XmlElement("OrderDate_TimeOffset")]
        public string OrderDate_TimeOffset // format: 2011-11-11T15:05:46.4733406+01:00
        {
            //  get { return OrderDate_DTO.ToString("o"); } // o = yyyy-MM-ddTHH:mm:ss.fffffffzzz
            
                get { return OrderDate_DTO.ToString("MM/dd/yyyy hh:mm:ss.fffK");}
                set { OrderDate_DTO = DateTimeOffset.Parse(value); } 
        }
      
        private DateTimeOffset  OrderDate_DTO { get; set; }



        public Order() { }
        public Order(Int32 OrderID, String CustomenName, Int32 CustomerID, DateTime OrderDate)
        {
            this.OrderID = OrderID;
            this.CustomerName = CustomenName;
            this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.OrderDate_DTO = DateTimeOffset.Now;
        }
    }
}