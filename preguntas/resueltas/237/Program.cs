using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace _237
{
  


       
    public class DeserializingArbitraryJsonObjects  
    {  

        static string json = "{\"p1\": [123, \"Estrella\" ,  \"SOL\"], \"p2\":[456, false]}";  
 
        public class Item
        {
            public int ID {get;set;}
            public bool isActive {get;set;}
        }
        static void Main(string[] args)  
                {  
                    DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(MyCustomDict));  
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));  
                    MyCustomDict dict = (MyCustomDict)dcjs.ReadObject(ms);  
            

                    foreach (var elemento in dict.dict)
                    {
                        Console.WriteLine ($" key{elemento.Key}  ID= {elemento.Value[0]} valor = {elemento.Value[1] }");
                       
                    }
                }  


        [Serializable]  
        public class MyCustomDict : ISerializable  
        {  
            public Dictionary<string, object[]> dict;  
            public MyCustomDict()  
            {  
                dict = new Dictionary<string, object[]>();  
            }  
            protected MyCustomDict(SerializationInfo info, StreamingContext context)  
            {  
                dict = new Dictionary<string, object[]>();  
                foreach (var entry in info)  
                {  
                    Debug.Assert(entry.ObjectType.IsArray);  
                    object[] array = entry.Value as object[];  
                    dict.Add(entry.Name, array);  
                }  
            }  
            public void GetObjectData(SerializationInfo info, StreamingContext context)  
            {  
                foreach (string key in dict.Keys)  
                {  
                    info.AddValue(key, dict[key]);  
                }  
            }  
        } 

    }
}
