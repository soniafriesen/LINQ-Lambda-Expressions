using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Final_Practical
{
    static class WordOperations
    {
        //loads any txt file into a list
        public static List<string> LoadWordsFromFile(string filename)
        {            
            List<string> wordsList = new List<string>();  
            List<string> lines = new List<string>();
            try
            {
                StreamReader reader = new StreamReader(filename);
                string line;          
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                reader.Close();
                foreach(string s in lines)
                {
                    string[] word = s.Split(new char[] { '.', '!', '?', ',', '(', ')', '\t', '\n', '\r', ' ',':',';','-','/','_' }) ;
                    foreach(string w in word)
                    {                        
                        wordsList.Add(w);
                    }
                }
                for (int i = 0; i < wordsList.Count; i++)
                {
                    if (wordsList[i] == " ")
                    {
                        wordsList.RemoveAt(i);
                    }
                }
                return wordsList;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            } 
        }

        //returns the total frequency of a province in each list
        public static int CountPrvFrequency(string province, List<string> list1, List<string> list2, List<string> list3)
        {
            //case insensitive everything tolower();
            var countlist1 = from c in list1
                             where c.ToLower() == province.ToLower()
                             select c;
            int list1count = countlist1.Count();
            var countlist2 = from c in list2
                             where c.ToLower() == province.ToLower()
                             select c;
            int list2count = countlist2.Count();
            var countlist3 = from c in list3
                             where c.ToLower() == province.ToLower()
                             select c;
            int list3count = countlist3.Count();

            int totalFrequency = list1count + list2count + list3count;
            return totalFrequency;

        }

        public static Dictionary<string, int> LongestWord(List<string> list1, List<string> list2, List<string> list3)
        {
            Dictionary<string, int> longestwords = new Dictionary<string, int>();
            int longestCount = list1.Select(w => w.Length).Max();
            var strLongest = list1.Where(w => w.Length == longestCount).ToList().Aggregate((w1, w2) => w1 + "," + w2);
            longestwords.Add(strLongest, longestCount);
            longestCount = list2.Select(w => w.Length).Max();
            strLongest = list2.Where(w => w.Length == longestCount).ToList().Aggregate((w1, w2) => w1 + "," + w2);
            longestwords.Add(strLongest, longestCount);
            longestCount = list3.Select(w => w.Length).Max();
            strLongest = list3.Where(w => w.Length == longestCount).ToList().Aggregate((w1, w2) => w1 + "," + w2);
            longestwords.Add(strLongest, longestCount);

            return longestwords;
        }
    }
}
