using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ToC
{
    public static class BinWriter
    {
        public static void writeLines(List<Symbol> list)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(@"c:\temp\output.bin",FileMode.Create),Encoding.UTF32);
            string code = "";
            string left = "";

            if (!list[0].Character.Equals(null) && !list[0].Character.Equals('\0'))
            {
                foreach (string line in EntropyCounter.lines)
                {
                    foreach (char c in line)
                    {

                        if (code.Length < 32)
                        {
                            code += findCode(c, list);
                        }
                        else if (code.Length > 32)
                        {
                            left = code.Substring(32);
                            code = code.Substring(0, 32);
                            WriteIt(code, writer);
                            code = left + findCode(c, list);
                            left = "";
                        }
                        else
                        {
                            WriteIt(code, writer);
                            code = left + findCode(c, list);
                            left = "";

                        }

                    }
                }
            }
            else
            {
                string pair = "";
                foreach (string line in EntropyCounter.lines)
                {
                    foreach (char c in line)
                    {

                        if (pair.Length < 2)
                        {
                            pair += "" + c;
                        }
                        else
                        {
                            if (code.Length < 32)
                            {
                                code += findCode(pair, list);
                            }
                            else if (code.Length > 32)
                            {
                                left = code.Substring(32);
                                code = code.Substring(0, 32);
                                WriteIt(code, writer);
                                code = left + findCode(pair, list);
                                left = "";
                            }
                            else
                            {
                                WriteIt(code, writer);
                                code = left + findCode(pair, list);
                                left = "";

                            }
                            pair = "";

                        }
                    }
                } 
            }
            writer.Close();
            
        }

        public static string findCode(char c, List<Symbol> list)
        {
            foreach (Symbol symbol in list)
            {
                if (symbol.Character.Equals(c))
                    return symbol.code;
                
            }
            return null;
        }
        
        public static string findCode(string c, List<Symbol> list)
        {
            foreach (Symbol symbol in list)
            {
                if (symbol.Pair.Equals(c))
                    return symbol.code;
                
            }
            return null;
        }


        public static void WriteIt(string code, BinaryWriter writer)
        {
            int count = 0;
            int res = 0;
            for (int y = code.Length - 1; y >= 0; y--)
            {
                if (code[y].Equals('1'))
                {
                    res += (int)Math.Pow(2, count);
                }
                count++;
            }
            
            writer.Write(res);
        }

        public static void ReadIt(int mode)
        {
            BinaryReader reader = new BinaryReader(File.Open(@"c:\temp\output.bin",FileMode.Open), Encoding.UTF32);
            if (mode == 2)
            {
                while (!reader.PeekChar().Equals('\0'))
                {
                    int cur = reader.ReadInt32();
                }
            }
        }
        
    }
}