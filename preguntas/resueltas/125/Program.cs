using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace _125
{
    public class Patient 
            {
                public bool IsActive {get;set;}
                public string Name {get;set;}
                public int Id {get;set;}
            }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Patient paciente = new Patient { IsActive=true ,Name="Juan Ramón" , Id=3};
            
            Serializar(paciente);
            Console.WriteLine(("").PadRight(60, '-'));
            string p = "{\"Id\":3,\"IsActive\":true,\"Name\":\"Juan Ramón\"}";
           
            DeSerializar(p);
        }

        static void  Serializar(Patient patientformJson )
        {
            Console.WriteLine ("Serializar: WriteObject ==> Pasa el objeto a un json string para que pueda ser enviado");
            DataContractJsonSerializer  jsSerializer = new DataContractJsonSerializer (typeof(Patient));
            MemoryStream stream = new MemoryStream() ;
            jsSerializer.WriteObject(stream, patientformJson);
            byte[] vector = stream.ToArray();

            Console.WriteLine(Encoding.UTF8.GetString(vector));
        }

        static void  DeSerializar(string PatientAsJson)
        {
            Console.WriteLine ("DeSerializar: ReadObject ==> pasa el json string a un objeto");
        

            Patient patientformJson = new Patient();
            DataContractJsonSerializer  jsSerializer = new DataContractJsonSerializer (typeof(Patient));
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(PatientAsJson)))
            {
                patientformJson = (Patient)jsSerializer.ReadObject(stream);
            }
            Console.WriteLine (patientformJson.Name);
            Console.WriteLine (patientformJson.IsActive);
            Console.WriteLine (patientformJson.Id);
        }

    }
       

    }
 
