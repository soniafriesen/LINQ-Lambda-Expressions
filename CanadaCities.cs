using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Final_Practical
{
    public class CanadaCities
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityAscii { get; set; }
        public int Population { get; set; }
        public string Country { get; set; }
        public string Capital { get; set; }
        public string Province { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static List<CanadaCities> PopulateCities()
        {
            List<CanadaCities> cities = new List<CanadaCities>();
            try
            {
                //create an XmlDocument
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("canadacities.xml"); //load the file 
                XmlNodeList xmlNodeList = xmlDoc.DocumentElement.ChildNodes;
                
                foreach (XmlNode node in xmlNodeList)
                {
                    XmlNodeList child = node.ChildNodes;
                    //create a city object
                    CanadaCities city = new CanadaCities();
                    city.CityName = child.Item(0).InnerText;
                    city.CityAscii = child.Item(1).InnerText;
                    city.Latitude = double.Parse(child.Item(2).InnerText);
                    city.Longitude = double.Parse(child.Item(3).InnerText);
                    city.Country = child.Item(4).InnerText;
                    city.Province = child.Item(5).InnerText;
                    if (child.Item(6).InnerText == null)
                        city.Capital = "";
                    city.Capital = child.Item(6).InnerText;
                    city.Population = int.Parse(child.Item(7).InnerText);
                    city.CityId = int.Parse(child.Item(8).InnerText);
                    //add teh city to the City Catalogue 
                    cities.Add(city);
                }
                return cities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }          
        }

        public override string ToString()
        {
            return CityName;
        }
    }
}
