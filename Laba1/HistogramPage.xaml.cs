using System;
using System.Collections.Generic;
using System.Linq;
using Laba1.Classes;
using Microsoft.Maui.Controls;

namespace Laba1
{
    public partial  class HistogramPage : ContentPage
    {
        private readonly int[] dataArray;

        public HistogramPage(int[] dataArray)
        {
            InitializeComponent();
            this.dataArray = dataArray;
            Title = "Histogram";
            BuildChart();
        }
        private void BuildChart()
        {
            var builder = new ChartBuilder();
            builder.FillEntriesUsingText(dataArray);
            ChartView.Chart = builder.Build();
        }


    }
}
