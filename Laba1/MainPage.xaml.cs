using Laba1.Classes;
using System.Diagnostics;
using System.Text;

namespace Laba1
{
    public partial class MainPage : ContentPage
    {
        string path = "";
        int[] notSortedArray;
        int[] SortedArray;
        int iterations = 0;
        double minTime = double.MaxValue;
        string fastestAlgorithm = "";

        Stopwatch stopwatch;

        public MainPage()
        {
            InitializeComponent();
            Result.IsVisible = false;
            ShowHistogramPage.IsVisible = false;
            stopwatch = new Stopwatch();
        }

        private void EnterPathClick(object sender, EventArgs e)
        {
            path = PathEntry.Text;
            Reader reader = new Reader();
            try
            {
                notSortedArray = reader.ReadIntArrayFromFile(path);
                EnterPathComponent.IsVisible = false;
                Result.IsVisible= true;
                ShowHistogramPage.IsVisible= true;
                SortArray5Ways();
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void CreateFileClick(object sender, EventArgs e)
        {
            // Get the user input as a string
            string input = NewArrayToFile.Text;

            // Split the input string into individual numbers by whitespace
            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Try to parse each part into an integer and store them in a list
            var integersList = new System.Collections.Generic.List<int>();
            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    integersList.Add(number);
                }
                else
                {
                    DisplayAlert("Error", $"Invalid input: '{part}' is not a valid integer.", "OK");
                    return;
                }
            }

            // Create a file path (you can customize this)
            string filePath = "C:\\Users\\Юлия\\Desktop\\Шева\\4 курс\\мобілки\\Laba1\\Laba1\\Resources\\TestFiles\\integers.txt";

            // Create a StringBuilder to store the integers as a string
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int num in integersList)
            {
                stringBuilder.Append(num.ToString());
                stringBuilder.Append(Environment.NewLine); // Add a newline separator
            }

            string content = stringBuilder.ToString();

            try
            {
                // Write the content to the specified file path
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.WriteAsync(content);
                }

                DisplayAlert("Success", $"File '{filePath}' created and data written successfully.", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    

        private async void ShowHistogramPageClick(object sender, EventArgs e)
        {
            var histogramPage = new HistogramPage(SortedArray);
            await Navigation.PushAsync(histogramPage);

        }
        private void SortArray5Ways()
        {
            int[] SortArrayCopy = (int[])notSortedArray.Clone();
            
            stopwatch.Restart();
            iterations = SelectionSortArray.SelectionSort(SortArrayCopy, SortArrayCopy.Length);
            stopwatch.Stop();
            Result.Text += $"\nSelection Sort Time: {stopwatch.ElapsedMilliseconds} ms; Iterations: {iterations}";
            double selectionSortTime = stopwatch.ElapsedMilliseconds;
            if (selectionSortTime < minTime)
            {
                minTime = selectionSortTime;
                fastestAlgorithm = "Selection Sort";
            }

            stopwatch.Restart();
            SortArrayCopy = (int[])notSortedArray.Clone();
            iterations = QuickSortArray.Quicksort(SortArrayCopy, 0, SortArrayCopy.Length-1);
            stopwatch.Stop();
            Result.Text += $"\n\nQuick Sort Time: {stopwatch.ElapsedMilliseconds} ms; Iterations: {iterations}";
            double quickSortTime = stopwatch.ElapsedMilliseconds;
            if (quickSortTime < minTime)
            {
                minTime = quickSortTime;
                fastestAlgorithm = "Quick Sort";
            }

            

            stopwatch.Restart();
            SortArrayCopy = (int[])notSortedArray.Clone();
            iterations = MergeSortArray.MergeSort(SortArrayCopy);
            stopwatch.Stop();
            Result.Text += $"\n\nMerge Sort Time: {stopwatch.ElapsedMilliseconds} ms; Iterations: {iterations}";
            double mergeSortTime = stopwatch.ElapsedMilliseconds;
            if (mergeSortTime < minTime)
            {
                minTime = mergeSortTime;
                fastestAlgorithm = "Merge Sort";
            }

            stopwatch.Restart();
            SortArrayCopy = (int[])notSortedArray.Clone();
            iterations = BubbleSortArray.BubbleSort(SortArrayCopy);
            stopwatch.Stop();
            Result.Text += $"\n\nBubble Sort Time: {stopwatch.ElapsedMilliseconds} ms; Iterations: {iterations}";
            double bubbleSortTime = stopwatch.ElapsedMilliseconds;
            if (bubbleSortTime < minTime)
            {
                minTime = bubbleSortTime;
                fastestAlgorithm = "Bubble Sort";
            }

            stopwatch.Restart();
            SortArrayCopy = (int[])notSortedArray.Clone();
            iterations = InsertionSortArray.InsertionSort(SortArrayCopy);
            stopwatch.Stop();
            Result.Text += $"\n\nInsertion Sort Time: {stopwatch.ElapsedMilliseconds} ms; Iterations: {iterations}";
            double insertionSortTime = stopwatch.ElapsedMilliseconds;
            if (insertionSortTime < minTime)
            {
                minTime = insertionSortTime;
                fastestAlgorithm = "Insertion Sort";
            }


            SortedArray = (int[])SortArrayCopy.Clone();
            string resultMessage = $"Fastest Algorithm: {fastestAlgorithm}\nTime: {minTime} ms;";
            DisplayAlert("Sorting Result", resultMessage, "OK");

        }
    }
}