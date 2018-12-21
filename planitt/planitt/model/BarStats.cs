using System;
using Entry = Microcharts.Entry;
using System.Collections.Generic;
using Microcharts;

namespace planitt.model
{
    public class BarStats
    {
        public List<Entry> GetEntries()
        {
            List<Entry> entries = new List<Entry>
            {
                new Entry(100)
                {
                    Color = SkiaSharp.SKColor.Parse("#892664"),
                    Label = "dan",
                    ValueLabel = "100"
                },
                 new Entry(120)
                {
                    Color = SkiaSharp.SKColor.Parse("#768429"),
                    Label = "dave",
                    ValueLabel = "120"
                },
                 new Entry(80)
                {
                    Color = SkiaSharp.SKColor.Parse("#646389"),
                    Label = "marco",
                    ValueLabel = "80"
                },
                  new Entry(50)
                {
                    Color = SkiaSharp.SKColor.Parse("#266489"),
                    Label = "ele",
                    ValueLabel = "50"
                }
            };

            return entries;
        }

       
    }
}
