using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace ToC
{
    public static class HuffmanAndShenon
    {
        public static List<Symbol> symbols;
        public static List<Symbol> HuffmanList;
        public static List<Symbol> ShennonList;

        public static void addSymbol(Symbol sym)
        {
            if (symbols == null)
                symbols = new List<Symbol>();
            symbols.Add(sym);
        }

        public static void FindOneHuffman()
        {
            HuffmanList = new List<Symbol>();
            HuffmanList.AddRange(symbols);
            
            
            while (HuffmanList.Count > 1)
            {
                HuffmanList.Sort();
                HuffmanList.Reverse();
                List<Symbol>.Enumerator en = HuffmanList.GetEnumerator();
                en.MoveNext();
                Symbol ch = en.Current;
                en = new List<Symbol>.Enumerator();
                HuffmanList.Remove(ch);
                en = HuffmanList.GetEnumerator();
                en.MoveNext();
                Symbol newOne = new Symbol(en.Current, ch);
                HuffmanList.Remove(en.Current);
                HuffmanList.Add(newOne);
    
            }
            
                ShowAllStart(HuffmanList.ToArray()[0]);
            
        }

        public static void ShowAllStart(Symbol root)
        {
            if (root != null)
            {

                root.code = 0;
                ShowAll(root.Son1, 1, root.code);

                ShowAll(root.Son2, 1, (root.code + 1));
            }
        }
        
        
        public static void ShowAll(Symbol root, int level, long code) {
            if (root != null)
            {

                root.code = code;
                
                ShowAll(root.Son1, level + 1,root.code * 10);

                for (int i = 0; i < level; i++) {
                    Console.Write("---");
                }

                if (!root.Character.Equals(null))
                {
                    Console.WriteLine(root.Character + "    " + root.code);
                } else if (!root.Pair.Equals(null) && !root.Pair.Equals(""))
                {
                    Console.WriteLine(root.Pair + "    " + root.code);
                }
                else
                {
                    Console.WriteLine();
                }

                ShowAll(root.Son2, level + 1, root.code *10 +1);
            }
        }

        public static void FindOneShennon()
        {
            
        }
        
        
    }
}