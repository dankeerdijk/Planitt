using System;
using System.Collections.Generic;
using System.Linq;
using planitt.model;


using Xamarin.Forms;

namespace planitt
{
    public partial class CreateHouseHoldPage : ContentPage
    {
        public CreateHouseHoldPage()
        {
            InitializeComponent();

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.StyleId == "create")
                Navigation.PushAsync(new CreatePlanning());

            if (btn.StyleId == "edit")
            {
                Navigation.PushAsync(new ChooseTask());
            }

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();



            var users = new List<string>();
            var user = new List<User>();
            var relation = await App.MobileService.GetTable<Relationship>().ToListAsync();

            foreach (var item in relation)
            {
                if((item.user_1_id.Equals(App.user.Id) || item.user_2_id.Equals(App.user.Id)) && (item.status.Equals(1)))
                {
                    if(item.user_1_id.Equals(App.user.Id))
                    {
                        users.Add(item.user_2_id);
                    
                    }else
                    if(item.user_2_id.Equals(App.user.Id))
                    {
                        users.Add(item.user_1_id);
                       
                    }
                }
            }

            foreach (var item in users )
            {
                var User = (await App.MobileService.GetTable<User>().Where(u => u.Id == item).ToListAsync()).FirstOrDefault();
                var us = new User
                {
                    Username = User.Username
                };
                user.Add(us);
            }

            friendsListview.ItemsSource = user;

            var tasks = await App.MobileService.GetTable<Task>().Where(t => t.userId == App.user.Id).ToListAsync();
            taskListview.ItemsSource = tasks;
        }
    }
}
