using System;
using System.Collections.Generic;
using System.IO;

namespace ToC
{
    public static class EntropyCounter
    {
        
        public static List<string> lines;

        public static Dictionary<char, long> h1CountMap;
        public static long sym;

        public static void ReadFile() {
            lines = new List<string>();

            
            string path = @"C:\temp\AnnaKarenina.txt";
            Console.WriteLine("Reading   "+path);
            try
            {
                using (StreamReader sr = new StreamReader(path))

                {
                    while (sr.Peek() >= 0)
                    {
                        lines.Add(sr.ReadLine());

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
        
        public static double getH1()
        {

            long size = 0;
            h1CountMap = new Dictionary<char, long>();

            char current;
            long value;
            foreach (String line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    size++;

                    current = line[i];
                    
                    if (!h1CountMap.TryGetValue(current, out value))
                    {
                        h1CountMap.Add(current, 1L);
                        
                    }
                    else
                    {
                        h1CountMap.Remove(current);
                        h1CountMap.Add(current, value + 1);
                    }
                }
            }

            double p, logP;
            double result = 0;

            foreach (KeyValuePair<char,long> entry in h1CountMap) 
            {
                p = (double)entry.Value / size;
                Symbol sym = new Symbol(entry.Key, p);
                HuffmanAndShenon.addSymbol(sym);
                logP = (double)getLog2(p);

                result += p * logP;
            }
            sym = size;

            return Math.Abs(result);
        }

        public static double getH2()
        {
            double result = 0;

            char previous = '\0';
            char current;
            long size = 0;

            Dictionary<char, TwoCharacters> map = new Dictionary<char, TwoCharacters>();

            foreach (String line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    current = line.Substring(i, 1).ToCharArray()[0];
                    size++;

                    if (previous == '\0')
                    {
                        previous = current;
                    }
                    else
                    {

                        TwoCharacters twoCharacters;
                        map.TryGetValue(current, out twoCharacters); 
                        if (twoCharacters == null)
                        {
                            twoCharacters = new TwoCharacters(current);
                            map.Add(current, twoCharacters);
                        }
                        twoCharacters.putCharacter(previous);

                        previous = current;
                    }
                }
            }

            double mainP, temp, p, logP;

            string first, para = "";
            foreach (KeyValuePair<char, TwoCharacters> entry in map)
            {

                first = "" +entry.Key;
                Dictionary<char, long> characterLongMap = entry.Value.getCharacterLongMap();
                temp = 0;
                long tc;
                h1CountMap.TryGetValue(entry.Value.getCurrent(), out tc);
                mainP = (double)tc / size;

                String key;
                foreach (KeyValuePair<char, long> longEntry in characterLongMap)
                {
                    para = longEntry.Key + first;
                    //para = first + longEntry.Key ;
                    p = ((double)longEntry.Value / (size-1)) / mainP;
                    Symbol pair = new Symbol(para,p);
                    HuffmanAndShenon.addSymbol(pair);
                    logP = getLog2(p);
                    temp += Math.Abs(logP * p);
                }


                result += mainP * temp;
            }

            return Math.Abs(result);
        }


        public static double getH3()
        {

            double result = 0;
            Dictionary<string, ThreeCharacters> map = new Dictionary<string, ThreeCharacters>();

            char current, previous = '\0', beforePrevious = '\0';

            long size = 0;

            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    current =  line.Substring(i, 1).ToCharArray()[0];
                    size++;
                    if (beforePrevious == '\0')
                    {
                        beforePrevious = current;
                    }
                    else if (previous == '\0')
                    {
                        previous = current;
                    }
                    else
                    {
                        String key = "" + previous + current;
                        ThreeCharacters threeCharacters;
                        map.TryGetValue(key, out threeCharacters);
                        if (threeCharacters == null)
                        {
                            threeCharacters = new ThreeCharacters(key);
                            map.Add(key, threeCharacters);
                        }
                        threeCharacters.putCharacter(beforePrevious);

                        beforePrevious = previous;
                        previous = current;
                    }

                }
            }

            double p, logP, temp, mainP;
            foreach (KeyValuePair<String, ThreeCharacters> entry in map)
            {

                Dictionary<char, long> characterLongMap = entry.Value.getCharacterLongMap();
                temp = 0;
                mainP = (double)entry.Value.getCount() / size;

                String key;
                foreach (KeyValuePair<char, long> longEntry in characterLongMap)
                {
                    p = ((double)longEntry.Value / (size-2)) / mainP;

                    logP = getLog2(p);
                    temp += Math.Abs(logP * p);
                }
                result += mainP * temp;
            }

            return result;
        }

       
        public static double getLog2(double number)
        {
            return Math.Log(number) / Math.Log(2);
        }
    }
}