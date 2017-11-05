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
        public static List<Symbol> result;

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
            BinWriter.writeLines(result);
            
        }

        public static void ShowAllStart(Symbol root)
        {
            result = new List<Symbol>();
            if (root != null)
            {
                root.code = "";
                ShowAll(root.Son1, 1, root.code + 0);

                ShowAll(root.Son2, 1, root.code + 1);
            }
        }
        
        
        public static void ShowAll(Symbol root, int level, string code) {
            if (root != null)
            {

                root.code = code;
                
                ShowAll(root.Son1, level + 1,root.code + 0);

                for (int i = 0; i < level; i++) {
                    Console.Write("---");
                }

                if (!root.Character.Equals(null) && !root.Character.Equals('\0'))
                {
                    Console.WriteLine(root.Character + "    " + root.code);
                    result.Add(root);
                } else if (root.Pair != null && !root.Pair.Equals(""))
                {
                    Console.WriteLine(root.Pair + "    " + root.code);
                    result.Add(root);
                }
                else
                {
                    Console.WriteLine();
                }

                ShowAll(root.Son2, level + 1, root.code +1);
            }
        }

        public static void FindOneShennon()
        {
            ShennonList = new List<Symbol>();
            ShennonList.AddRange(symbols);
            Symbol root = Shennon(ShennonList);
            ShowAllStart(root);
            BinWriter.writeLines(result);
        }

        public static Symbol Shennon(List<Symbol> list)
        {
            if (list.Count > 1)
            {
                List<Symbol> first = new List<Symbol>();
                List<Symbol> second = new List<Symbol>();
                double sum1 = 0, sum2 = 0;
                foreach (Symbol s in list)
                {
                    if (sum1 == sum2 || sum1 < sum2)
                    {
                        first.Add(s);
                        sum1 += s.Enthropy;
                    }
                    else
                    {
                        second.Add(s);
                        sum2 += s.Enthropy;
                    }
                }

                return new Symbol(Shennon(first), Shennon(second));
            }
            else
            {
                return new Symbol(list[0].Character, list[0].Enthropy);
            }
        }
        
        
    }
}