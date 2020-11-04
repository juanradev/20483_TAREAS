

 
    using System;
        using System.IO;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.Serialization;
    using System.Xml;
using System.Xml.Serialization;

namespace _167_b
{


    // You must apply a DataContractAttribute or SerializableAttribute
    // to a class to have it serialized by the DataContractSerializer.
    [Serializable]
    [DataContract(Name = "Order")]
    public class Order : IExtensibleDataObject
    {
        [DataMember()]
        public Int32 OrderID { get; set; }
        [DataMember(Name = "Customer")]
        public String CustomerName { get; set; }
        [DataMember()]
        public Int32 CustomerID { get; set; }
        [DataMember()]
        public DateTime OrderDate { get; set; }

        public Order()
        {
            OrderID = 42;
            CustomerName = "Ben Smith";
            CustomerID = 206;
            OrderDate = DateTime.Now;
        }
        private ExtensionDataObject extensionDataObjectValue;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataObjectValue;
            }
            set
            {
                extensionDataObjectValue = value;
            }
        }
    }




    public sealed class Test
    {
        private Test() { }

        public static void Main()
        {
            try
            {

                Serializar();
                WriteObject("salida.xml");
                ReadObject("salida.xml");
            }

            catch (SerializationException serExc)
            {
                Console.WriteLine("Serialization Failed");
                Console.WriteLine(serExc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(
                "The serialization operation failed: {0} StackTrace: {1}",
                exc.Message, exc.StackTrace);
            }

            finally
            {
                Console.WriteLine("Press <Enter> to exit....");
                Console.ReadLine();
            }
        }


 public static void Serializar()
        {
            // Create a new instance of the Person class.
            Order order = new Order();
            
            
            XmlSerializer s = new XmlSerializer(typeof(Order));
            FileStream buffer = File.Create(@".\salida1.xml");
            XmlSerializer ss = new XmlSerializer(order.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            s.Serialize(buffer, order, ns);
            buffer.Close();
        }


        public static void WriteObject(string fileName)
        {
            Console.WriteLine(
                "Creating a new Order  object and serializing it.");
            Order p1 = new Order();
            FileStream writer = new FileStream(fileName, FileMode.Create);

            DataContractSerializer ser =
                new DataContractSerializer(typeof(Order));
            ser.WriteObject(writer, p1);
            writer.Close();
        }

        public static void ReadObject(string fileName)
        {
            Console.WriteLine("Deserializing an instance of the object.");
            FileStream fs = new FileStream(fileName,
            FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(Order));

            // Deserialize the data and read it from the instance.
            Order deserializedPerson =
                (Order)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
            Console.WriteLine($" {deserializedPerson.OrderID} , {deserializedPerson.CustomerName}, {deserializedPerson.CustomerID} , {((DateTime)deserializedPerson.OrderDate).ToString("o")} ");
        }
        }
    }