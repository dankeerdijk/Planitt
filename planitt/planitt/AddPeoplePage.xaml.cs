using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using planitt.model;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace planitt
{
    public partial class AddPeoplePage : ContentPage
    {

        public AddPeoplePage()
        {
            InitializeComponent();
            updateListview(null);
            BackgroundColor = Color.FromHex("#cce5ff");
        }

        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            var keyword = searchbar.Text;
            updateListview(keyword);
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var userTapped = e.Item as User;
            PopupSendRequest popupSend = new PopupSendRequest();
            popupSend.nameToSend = userTapped.Username;
            popupSend.user_two_id = userTapped.Id;
            popupSend.action_user_name = userTapped.Username;
            popupSend.setname();
            PopupNavigation.Instance.PushAsync(popupSend);

        }

        async void updateListview(string keyword)
        {

            var name = App.user.Username;
            var namesList = await App.MobileService.GetTable<User>().Where(u => u.Username != name).ToListAsync();
         
            if (keyword == null)
            {
                listview.ItemsSource = namesList;
            } 
               else
            {
                var updatedlist = namesList.Where(u => u.Username.Contains(keyword));
                listview.ItemsSource = updatedlist;
            }
            
        }

    
    }
}
