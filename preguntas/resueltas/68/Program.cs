using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using static System.Console;
namespace _68
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            sw.WriteLine("{\"ComanyName\": \"Microsoft\",  \"Address\": \"1 Microsoft Way, Redmond, WA 98052\", \"CEO\":\"Satya Nadella\"} ");
            sw.Flush();


            StreamReader sr = new StreamReader(ms);
            /* Ojo antes de leerlo siempre   ms.Position = 0;  */
            ms.Position = 0;
            WriteLine($"El valor del stream : {sr.ReadToEnd()}");

            /* Lo vuelvo a ms.Position = 0;  ya que si no me dará un error de no encontrar root al deserialiar*/
            ms.Position = 0;
            DeseriallizeJsonData(ms);
            sr.Dispose();
            sw.Dispose();
            ms.Dispose();

          }

        public static void DeseriallizeJsonData(MemoryStream stream1)
        {
            DataContractJsonSerializer serializer
              = new DataContractJsonSerializer(typeof(CompanyInfo));
            CompanyInfo cn = serializer.ReadObject(stream1) as CompanyInfo;
            WriteLine(cn.ComanyName);
            WriteLine(cn.Address);
            WriteLine(cn.CEO);
        }

    }
    [Serializable]
    public class CompanyInfo : ISerializable
    {
        public string ComanyName { get; set; }
        public string Address { get; set; }
        public string CEO { get; set; }

        public CompanyInfo() { }


        public CompanyInfo(SerializationInfo info, StreamingContext ctxt)
        {
            this.ComanyName
            = info.GetValue("ComanyName", typeof(string)).ToString();
            this.Address
            = info.GetValue("Address", typeof(string)).ToString();
            this.CEO
            = info.GetValue("CEO", typeof(string)).ToString();

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ComanyName", this.ComanyName);
            info.AddValue("Address", this.Address);
            info.AddValue("CEO", this.CEO);
        }
    }
}
