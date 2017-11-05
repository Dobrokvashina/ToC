using System;


namespace ToC
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            EntropyCounter.ReadFile();

            double h1 = EntropyCounter.getH1();
            
            Console.WriteLine("Symbols   = " + EntropyCounter.sym);
            
            Console.WriteLine("H1: " + h1);
            HuffmanAndShenon.FindOneHuffman();
            Console.WriteLine("_______-----------________________-----------_______________");
            Console.ReadKey();
            HuffmanAndShenon.FindOneShennon();
            Console.WriteLine("H2: " + EntropyCounter.getH2());
            Console.WriteLine("H3: " + EntropyCounter.getH3());


            }



    }
    }
