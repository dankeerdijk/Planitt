using System;
using System.Collections.Generic;
using planitt.model;
using Xamarin.Forms;

namespace planitt
{
    public partial class InboxPage : ContentPage
    {
        public InboxPage()
        {
            InitializeComponent();
            UpdateListview();
            BackgroundColor = Color.FromHex("#cce5ff");
            inboxListview.BackgroundColor = Color.FromHex("#cce5ff");
        }

        async public void UpdateListview()
        {
            var pendingList = await App.MobileService.GetTable<Relationship>().Where(r => r.user_2_id == App.user.Id && r.status == 0).ToListAsync();
            inboxListview.ItemsSource = pendingList;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var button = (Button)sender;
            var username = button.CommandParameter as Relationship;

            if (button.StyleId == "acc")
            {
                DisplayAlert("hey", "je accepteert " + username.action_user_name, "ok");
                updateData(username.user_1_id, username.user_2_id, username.Id);

            }
            else if (button.StyleId == "neg")
            {
                DisplayAlert("hey", "je negeert " + username.action_user_name, "ok");
               
            }
        }

        private async void updateData(string user1, string user2, string updateID)
        {
         
            Relationship update = new Relationship
            {
                Id = updateID,
                user_1_id = user1,
                user_2_id = user2,
                status = 1,
                action_user_name = App.user.Username,
                action_user_id = App.user.Id

            };

            await App.MobileService.GetTable<Relationship>().UpdateAsync(update);
        }
    }
}
