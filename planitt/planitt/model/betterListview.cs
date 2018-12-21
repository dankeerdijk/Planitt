using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace planitt.model
{
    public class BetterListview : ListView
    {

        public static BindableProperty itemClickedCommandProp = BindableProperty.Create(nameof(itemClickedCommand), typeof(ICommand), typeof(BetterListview), null);
        public ICommand itemClickedCommand
        {
            get
            { return (ICommand)this.GetValue(itemClickedCommandProp); }
            set
            {
                this.SetValue(itemClickedCommandProp, value);
            }
        }

        public BetterListview()
        {
            this.ItemTapped += Handle_ItemTapped;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item != null)
            {
                itemClickedCommand?.Execute(e.Item);
                SelectedItem = null;
            }
        }

    }
}
