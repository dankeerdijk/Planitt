using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;
using planitt.model;

namespace planitt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupSendRequest
    {
        public string nameToSend { get; set; }
        public string user_one_id { get; set; }
        public string user_two_id { get; set; }
        public string action_user_name { get; set;}
        private bool found { get; set; }

        public PopupSendRequest()
        {
            InitializeComponent();
           
        }

        public void setname()
        {
            namePlace.Text = nameToSend;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {

            Relationship relationship = new Relationship
            {
                user_1_id = App.user.Id,
                user_2_id = user_two_id,
                status = 0,
                action_user_name = App.user.Username,
                action_user_id = App.user.Id

            };

            var relation = await App.MobileService.GetTable<Relationship>().ToListAsync();
            foreach (var item in relation)
            {
                if (item.user_1_id.Equals(relationship.user_1_id) && item.user_2_id.Equals(relationship.user_2_id)
                    && item.status.Equals(relationship.status))
                {
                    found = true;
                    break;
                }
                else if(item.user_1_id.Equals(relationship.user_1_id) && item.user_2_id.Equals(relationship.user_2_id) && item.status.Equals(1))
                {
                    found = true;
                    break;
                }
                    
                if(item.user_2_id.Equals(relationship.user_1_id) && item.status.Equals(1) && item.user_1_id.Equals(relationship.user_2_id))
                {
                    found = true;
                    break;
                }
                if (item.user_2_id.Equals(relationship.user_1_id) && item.status.Equals(0) && item.user_1_id.Equals(relationship.user_2_id))
                {
                    found = true;
                    break;
                }

                found = false;
            }
            if (found == true)
            {
              
                await DisplayAlert("sorry", "er is al een verzoek gestuurd", "oke");
            } 
            else
            {
              
                await App.MobileService.GetTable<Relationship>().InsertAsync(relationship);
            }
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
