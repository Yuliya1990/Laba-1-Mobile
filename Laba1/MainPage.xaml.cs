using Laba1.Classes;
using System.Diagnostics;
using System.Text;

namespace Laba1
{
    public partial class MainPage : ContentPage
    {
        int[] notSortedArray;
        int[] SortedArray;
        int _iterations = int.MaxValue;
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

        private async void OpenFileClick(object sender, EventArgs e)
        {
            var fileWithInfo = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Choose file with data (text file)",
                FileTypes = new FilePickerFileType(
            new Dictionary<DevicePlatform, IEnumerable<string>>
            {
              { DevicePlatform.iOS, new[] { "public.txt" } },
              { DevicePlatform.Android, new[] { "text/plain" } },
              { DevicePlatform.UWP, new[] { ".txt" } },
              { DevicePlatform.macOS, new[] { "public.utf8-plain-text" } },
            }),
            });

            Reader reader = new Reader();
            try
            {
                notSortedArray = await reader.ReadIntArrayFromFileAsync(fileWithInfo);
                EnterPathComponent.IsVisible = false;
                Result.IsVisible = true;
                ShowHistogramPage.IsVisible = true;
                SortArray5Ways();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
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

            // Join the integers back into a string
            string content = string.Join(Environment.NewLine, integersList);

            try
            {
                // Get the platform-specific directory for storing files
                string directory = FileSystem.AppDataDirectory;

                // Create a unique file name (you can customize the name)
                string fileName = Guid.NewGuid().ToString() + ".txt";

                // Combine the directory and file name to create the full file path
                string filePath = Path.Combine(directory, fileName);

                // Write the content to the specified file path
                File.WriteAllText(filePath, content);

                DisplayAlert("Success", $"File '{fileName}' created and data written successfully.", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        
    }
    

        private async void ShowHistogramPageClick(object sender, EventArgs e)
        {
            var histogramPage = new HistogramPage(notSortedArray, SortedArray);
            await Navigation.PushAsync(histogramPage);

        }
        private void SortArray5Ways()
        {
            int[] SortArrayCopy = (int[])notSortedArray.Clone();
            int iterations = 0;

            stopwatch.Restart();
            iterations = SelectionSortArray.SelectionSort(SortArrayCopy, SortArrayCopy.Length);
            stopwatch.Stop();
            Result.Text += $"\nSelection Sort Time: {stopwatch.ElapsedMilliseconds} ms; Iterations: {iterations}";
            if (iterations < _iterations)
            {
                _iterations = iterations;
                fastestAlgorithm = "Selection Sort";
            }

            stopwatch.Restart();
            SortArrayCopy = (int[])notSortedArray.Clone();
            iterations = QuickSortArray.Quicksort(SortArrayCopy, 0, SortArrayCopy.Length-1);
            stopwatch.Stop();
            Result.Text += $"\n\nQuick Sort Time: {stopwatch.ElapsedMilliseconds} ms; Iterations: {iterations}";
            double quickSortTime = stopwatch.ElapsedMilliseconds;
            if (iterations < _iterations)
            {
                _iterations = iterations;
                fastestAlgorithm = "Quick Sort";
            }

            

            stopwatch.Restart();
            SortArrayCopy = (int[])notSortedArray.Clone();
            iterations = MergeSortArray.MergeSort(SortArrayCopy);
            stopwatch.Stop();
            Result.Text += $"\n\nMerge Sort Time: {stopwatch.ElapsedMilliseconds} ms; Iterations: {iterations}";
            double mergeSortTime = stopwatch.ElapsedMilliseconds;
            if (iterations < _iterations)
            {
                _iterations = iterations;
                fastestAlgorithm = "Merge Sort";
            }

            stopwatch.Restart();
            SortArrayCopy = (int[])notSortedArray.Clone();
            iterations = BubbleSortArray.BubbleSort(SortArrayCopy);
            stopwatch.Stop();
            Result.Text += $"\n\nBubble Sort Time: {stopwatch.ElapsedMilliseconds} ms; Iterations: {iterations}";
            double bubbleSortTime = stopwatch.ElapsedMilliseconds;
            if (iterations < _iterations)
            {
                _iterations = iterations;
                fastestAlgorithm = "Bubble Sort";
            }

            stopwatch.Restart();
            SortArrayCopy = (int[])notSortedArray.Clone();
            iterations = InsertionSortArray.InsertionSort(SortArrayCopy);
            stopwatch.Stop();
            Result.Text += $"\n\nInsertion Sort Time: {stopwatch.ElapsedMilliseconds} ms; Iterations: {iterations}";
            double insertionSortTime = stopwatch.ElapsedMilliseconds;
            if (iterations < _iterations)
            {
                _iterations = iterations;
                fastestAlgorithm = "Insertion Sort";
            }


            SortedArray = (int[])SortArrayCopy.Clone();
            string resultMessage = $"Fastest Algorithm: {fastestAlgorithm}\nIterations: {_iterations}";
            DisplayAlert("Sorting Result", resultMessage, "OK");

        }
    }
}