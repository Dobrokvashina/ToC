using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ToC
{
    public static class BinWriter
    {
        public static void writeLines(List<Symbol> list)
        {
            
            BinaryWriter writer = new BinaryWriter(File.Open(@"c:\temp\output.bin",FileMode.Create));
            
            foreach (string line in EntropyCounter.lines)
            {
                foreach (char c in line)
                {
                    foreach (char c1 in findCode(c, list))
                    {
                        if (c1.Equals('0'))
                        {
                            writer.Write(false);
                        }
                        else
                        {
                            writer.Write(true);
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
    }
}