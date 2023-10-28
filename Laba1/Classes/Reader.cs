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
        public int[] ReadIntArrayFromFile(string filePath)
        {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                    // Read all lines from the file

                    // Initialize a list to store integers
                    List<int> integers = new List<int>();


                    // Parse each line as an integer and add it to the list
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string part in parts)
                        {
                            if (int.TryParse(part, out int intValue))
                            {
                                integers.Add(intValue);
                            }
                        }
                    }
                    // Convert the list to an array
                    int[] intArray = integers.ToArray();

                    return intArray;

                }
                else
                {
                throw new Exception("Wrong path");
                }
        }
    }
}
