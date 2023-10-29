using Microsoft.UI.Composition.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Classes
{
    public class Reader
    {
        private async Task<string> GetTextFromFile(FileResult file)
        {
            var stream = await file.OpenReadAsync();
            var reader = new StreamReader(stream);
            var text = await reader.ReadToEndAsync();
            return text;
        }

        public async Task<int[]> ReadIntArrayFromFileAsync(FileResult file)
        {
                if (file != null)
                {
                    var text = await GetTextFromFile(file);
                // Read all lines from the file

                // Split the text by newlines to get individual lines
                string[] integers_input = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                // Initialize a list to store integers
                List<int> integers = new List<int>();
                foreach (string integer in integers_input)
                {
                    if (int.TryParse(integer, out int number))
                    {
                        // Parse each line as an integer and add it to the list
                        integers.Add(number);
                    }
                    else
                    {
                        throw new Exception("Invalid data in the file. Not all lines contain valid integers.");
                    }
                }

                // Convert the list of integers to an array and return it
                return integers.ToArray();

            }
                else
                {
                throw new Exception("Wrong path");
                }
        }
    }
}
