using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Practical
{
    public static class CityQueries
    {
        public static List<string> PopulationQuery(List<CanadaCities> citites)
        {
            var cityQuery = from c in citites
                            where c.Population > 1000000000
                            orderby c.CityName ascending
                            select c.CityName;
            return cityQuery.ToList();
        }

        public static IEnumerable<IGrouping<string, CanadaCities>> CityInPrvQuery(List<CanadaCities> citites)
        {
            var provinceGroup = from c in citites
                                orderby c.CityName
                                group c by c.Province into cityProvGroup
                                orderby cityProvGroup.Key 
                                select cityProvGroup;

            return provinceGroup;
           
        }

        public static List<string> CityCapitalQuery(List<CanadaCities> cities)
        {
            var captialCity = from c in cities
                              where (c.Capital == "admin" || c.Capital == "primary") && (c.Population >= 50000 || c.Population <= 100000000)
                              orderby c.Population descending
                              select c.CityName;
            return captialCity.ToList();
        }
    }
}
