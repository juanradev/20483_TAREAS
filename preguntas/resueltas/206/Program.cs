using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml;

namespace _206
{

    public class Rate
    {
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public override string  ToString() 
        {
             return $"Category : {Category} Date {Date.ToLongDateString()} Value { Value.ToString()}";  
        }
    }


    class Program
    {


        public static void Main()
        {
            Collection<Rate> rateCollection = new Collection<Rate>();

            string path = @"entrada.xml";

            using var reader = XmlReader.Create(path);
            {
                while (reader.ReadToFollowing("rate"))
                {
                    Rate rate = new Rate();
                    reader.MoveToFirstAttribute();
                    rate.Category = reader.Value;

                    reader.MoveToNextAttribute();
                    DateTime ratetime;
                    if (DateTime.TryParse(reader.Value, out ratetime))
                    {
                        rate.Date = ratetime;
                    }
                     /// reader.MoveToElement();    'Element' is an invalid XmlNodeType.
                    decimal value;
                    reader.ReadToFollowing("value");
                    if (decimal.TryParse(reader.ReadElementContentAsString(), out value))
                        rate.Value = value;
                    rateCollection.Add(rate);
                }
            }
            foreach (var r in rateCollection)
                System.Console.WriteLine(r);
        }
    }
}



