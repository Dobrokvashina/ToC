using System;
using System.Collections.Generic;

namespace ToC
{
    public class ThreeCharacters
    {

        private Dictionary<char, long> characterLongMap = new Dictionary<char, long>();
        private string current;
        private long count;

        public ThreeCharacters(String current)
        {
            this.current = current;
        }

        public long getCount()
        {
            return count;
        }

        public void putCharacter(char c)
        {
            long value;
            if (!characterLongMap.TryGetValue(c, out value))
            {
                characterLongMap.Add(c, 1L);
            }
            else
            {

                characterLongMap.Remove(c);
                characterLongMap.Add(c, value + 1);
            }
            count++;
        }

        public String getCurrent()
        {
            return current;
        }

        public Dictionary<char, long> getCharacterLongMap()
        {
            return characterLongMap;
        }


    }
}