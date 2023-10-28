using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Classes
{
    internal class FrequencyCounter
    {
        public static Dictionary<int, int> CountFrequency(int[] entries)
        {
            var frequencyDictionary = new Dictionary<int, int>();
            foreach (var symbol in entries)
            {
                frequencyDictionary[symbol] = frequencyDictionary.TryGetValue(symbol, out var frequency)
                                              ? frequency + 1
                                              : 1;
            }

            return frequencyDictionary;
        }
    }
}
