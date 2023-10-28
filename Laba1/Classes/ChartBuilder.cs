using SkiaSharp;
using Microcharts;

namespace Laba1.Classes
{
    internal class ChartBuilder
    {
        private List<ChartEntry> _entries = new List<ChartEntry>();

        public void FillEntriesUsingText(int[] entries)
        {
            var frequencyDictionary = FrequencyCounter.CountFrequency(entries);

            foreach (var frequencyPair in frequencyDictionary)
            {
                _entries.Add(new ChartEntry(frequencyPair.Value)
                {
                    Label = frequencyPair.Key.ToString(),
                    ValueLabel = frequencyPair.Value.ToString(),
                    Color = SKColor.Parse("#266489")
                });
            }
        }

        public Chart Build()
        {
            var chart = new BarChart()
            {
                Entries = _entries,
                LabelTextSize = 15,
            };

            return chart;
        }
    }
}
