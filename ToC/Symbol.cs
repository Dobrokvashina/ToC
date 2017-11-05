using System;

namespace ToC
{
    public class Symbol: IComparable<Symbol>
    {
        public Symbol(char character, double enthropy)
        {
            this.Character = character;
            this.Enthropy = enthropy;
        }

        public Symbol(string pair, double enthropy)
        {
            this.Pair = pair;
            this.Enthropy = enthropy;
        }

        public Symbol(Symbol first, Symbol second)
        {
            this.Son1 = first;
            this.Son2 = second;
            this.Enthropy = first.Enthropy + second.Enthropy;
        }

        public bool hasParent()
        {
            return Parent != null;
        }
        
        public string Pair { get; set; }
        public char Character { get; set; }
        public Symbol Parent { get; set; }
        public Symbol Son1 { get; set; }
        public Symbol Son2 { get; set; }
        public double Enthropy { get; set; }
        public string code { get; set; }
        
        public int CompareTo(Symbol other)
        {
            if (other.Enthropy.Equals(this.Enthropy))
                return 0;
            if (other.Enthropy > this.Enthropy)
                return 1;
            else
                return -1;
        }
    }
}