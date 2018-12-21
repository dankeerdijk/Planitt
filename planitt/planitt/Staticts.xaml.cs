using System;
using Entry = Microcharts.Entry;
using System.Collections.Generic;
using Microcharts;
using planitt.model;

using Xamarin.Forms;

namespace planitt
{
    public partial class Staticts : ContentPage
    {
      
        public Staticts()
        {
            InitializeComponent();
            BarStats barStats = new BarStats();
            var entries = barStats.GetEntries();
            chartRank.Chart = new BarChart{Entries = entries};
            
        }
    }
}
