using System.Collections.Generic;

namespace ToC
{
    public class TwoCharacters
    {

        private Dictionary<char, long> characterLongMap = new Dictionary<char, long>();
        private char current;

        public TwoCharacters(char current)
        {
            this.current = current;
        }

        public void putCharacter(char c)
        {
            long value;
            if (!characterLongMap.TryGetValue(c, out value))
            {
                characterLongMap.Add(c, 1L);
            }
            else { 
                characterLongMap.Remove(c);
                characterLongMap.Add(c, value + 1);
            }
        }

        public char getCurrent()
        {
            return current;
        }

        public Dictionary<char, long> getCharacterLongMap()
        {
            return characterLongMap;
        }
    }
}