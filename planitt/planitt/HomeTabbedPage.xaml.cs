using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace planitt
{
    public partial class HomeTabbedPage : TabbedPage
    {
        public HomeTabbedPage()
        {
            InitializeComponent();
            BarBackgroundColor = (Color)Application.Current.Resources["ButtonBackground"];
            BarTextColor = Color.White;
        }
    }
}
 