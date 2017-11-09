using System;
using System.Collections.Generic;


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
            /*HuffmanAndShenon.FindOneHuffman();
            Console.WriteLine("_______-----------________________-----------_______________");
            Console.WriteLine("H1: " + h1);
            Console.ReadKey();
           HuffmanAndShenon.FindOneShennon();
            HuffmanAndShenon.symbols = new List<Symbol>();*/
            double h2 = EntropyCounter.getH2();
            //Console.WriteLine("H1: " + h1);
            Console.WriteLine("H2: " + h2);
            /*Console.WriteLine("_______-----------________________-----------_______________");
            Console.ReadKey();
            HuffmanAndShenon.FindOneHuffman();
            Console.WriteLine("_______-----------________________-----------_______________");
            Console.WriteLine("H2: " + h2);
            Console.ReadKey();
            HuffmanAndShenon.FindOneShennon();
            Console.WriteLine("H2: " + h2);*/
            Console.WriteLine("H3: " + EntropyCounter.getH3());


            }



    }
    }
