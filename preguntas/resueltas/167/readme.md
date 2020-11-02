### QUESTION 167 

##### DataContractSerializer / XMLSerializer. DataMember , XMlAttribute, Datimeoffset

You have an existing order processing system that accepts .xml files,

The following code shows an example of a properly formatted order in XML: 



```xml
<Order OrderID = "42">
    <Customer>Ben Smith</Customer>
    <CustomerID>206</CustomerID>
    <OrderDate>2013-01-19T09:13:14.7265994-05:00</OrderDate>
<Order>
````

You create the following class that will be serialized:

```c#

[DataContract()]
public class Order
{
    [DataMember()]
    public Int32 OrderID {get;set;}
    [DataMember(Name=Customer)]
    public String CustomerName
     [DataMember()]
    public Int32 CustomerID {get;set;}
     [DataMember()]
    public DateTime OrderDate {get;set;}
}
`````

For each of the following properties, select Yes if the property is serialized according to the defined schema.
Otherwise, select No.

![opciones text](opciones.PNG)

 



![respuesta text](respuesta.PNG)


Explicación
````xml
<Order>
    <Customer>Ben Smith</Customer>
    <CustomerID>206</CustomerID>
     <OrderID>42</OrderID>
    <OrderDate>2013-01-19T09:13:14</OrderDate>
<Order>
````

Efectivamente OrderID Fallaría ya que está etiquetado solo como [Datameber], haría falta al menos un [Datamember,XmlAttribute] y OrderDate puede llegar a presentar milisegundos pero no el ofsste repecto a la UTC (-05:00)




Una posible solución es la que presento en el programa es envez de utilizar un Datetime utilizar un DateTimeOffset , lo pongocomo no serializable y utilizo una propiedad string intermedia que si serializamos. Para un mejor control del xml utilizo XMlSerializer
````xml
<?xml version="1.0"?>
<Order OrderID="26">
  <Customer>Ben Smith</Customer>
  <CustomerID>206</CustomerID>
  <OrderDate>1970-06-11T00:00:00</OrderDate>
  <OrderDate_TimeOffset>11/03/2020 12:16:00.770+01:00</OrderDate_TimeOffset>
</Order>
````

```c#
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
```` 



nota: DataContractSerializer vs XMLSerializer

DataContractSerializer

1. Está destinado a ser utilizado para la serialización / deserialización de clases en el servicio WCF hacia y desde JSON o XML.  
2. serializa propiedades y campos.  
3. Es más rápido que XmlSerializer  
4. No controla cómo se genera xml. No debe usarse cuando se requiere un control total sobre la estructura XML generada  
XMLSerializer  

XmlSerializer    
1.- es solo para serialización XML  
2. Admite un control total sobre la estructura XML  
3. Serializa solo propiedades públicas  

