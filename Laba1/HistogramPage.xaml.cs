using System;
using System.Collections.Generic;
using System.Linq;
using Laba1.Classes;
using Microsoft.Maui.Controls;

namespace Laba1
{
    public partial  class HistogramPage : ContentPage
    {
        private readonly int[] _SortedArray;
        private readonly int[] _notSortedArray;

        public HistogramPage(int[] notSortedArray, int[] SortedArray)
        {
            InitializeComponent();
            this._SortedArray = SortedArray;
            _notSortedArray = notSortedArray;
            Title = "Histogram";
            BuildChart();
        }
        private void BuildChart()
        {
            var builder1 = new ChartBuilder();
            builder1.FillEntriesUsingText(_notSortedArray);
            ChartView1.Chart = builder1.Build();
            var builder2 = new ChartBuilder();
            builder2.FillEntriesUsingText(_SortedArray);
            ChartView2.Chart = builder2.Build();
        }


    }
}
