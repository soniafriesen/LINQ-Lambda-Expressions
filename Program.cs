using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Practical
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Final Practical Sonia Friesen 0813682");
            //populate the lsit with cicites
            List<CanadaCities> cities = CanadaCities.PopulateCities(); 
            
            //testing PopulationQuery()
            Console.WriteLine("testing PopulationQuery()");
            List<string> population = CityQueries.PopulationQuery(cities);
            Console.WriteLine("Results: \n");
            foreach(string s in population)
            {
                Console.WriteLine(s);
            }

            //testing city in each province
            Console.WriteLine("testing CityInPrvQuery()");
            var Provgroupings = CityQueries.CityInPrvQuery(cities); 
            Console.WriteLine("Results:");
            foreach(var groups in Provgroupings)
            {
                Console.WriteLine($"\nProvince: {groups.Key}");                
                foreach(var city in groups)
                {
                    Console.WriteLine(city.ToString() + " Population: " + city.Population);
                }
            }

            //testing Captical Query
            Console.WriteLine("\ntesting CityCapitalQuery");
            List<string> capital = CityQueries.CityCapitalQuery(cities);
            Console.WriteLine("Results:");
            foreach(string s in capital)
            {
                Console.WriteLine(s);
            }

            //Testing the WordOperations functions
            List<string> aboutCanada = WordOperations.LoadWordsFromFile("AboutCanada.txt");
            List<string> tourismCanada = WordOperations.LoadWordsFromFile("TourismCanada.txt");
            List<string> travelCanada = WordOperations.LoadWordsFromFile("TravelCanada.txt");
            
            //testing CountPrvFrequency()
            Console.WriteLine("\ntesting CountPrvFrequency");           
            int count = WordOperations.CountPrvFrequency("ontario", aboutCanada, tourismCanada, travelCanada);
            Console.WriteLine("Results: Count for 'ontario' is " + count);

            //testing LongestWord()
            Console.WriteLine("\ntesting LongestWord");
            Dictionary<string, int> longestWords = WordOperations.LongestWord(aboutCanada, tourismCanada, travelCanada);
            Console.WriteLine("Results: ");
            foreach(var key in longestWords)
            {
                Console.WriteLine("Word is: " + key.Key + "with count of: " + key.Value);
                
            }

        }
    }
}
