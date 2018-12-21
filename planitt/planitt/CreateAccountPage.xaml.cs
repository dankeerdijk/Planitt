using System;
using System.Collections.Generic;
using System.Linq;
using planitt.model;
using Xamarin.Forms;

namespace planitt
{
    public partial class CreateAccountPage : ContentPage
    {
        User user;

        public CreateAccountPage()
        {
            InitializeComponent();
            user = new User();
            containerStack.BindingContext = user;

        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (wachtwoord.Text == wachtwoord2.Text)
            {
                await App.MobileService.GetTable<User>().InsertAsync(user);
                var currentUser = (await App.MobileService.GetTable<User>().Where(u => u.Username == gebruikersnaam.Text).ToListAsync()).FirstOrDefault();
                App.user = currentUser;
                TaskBank taskBank = new TaskBank();
                taskBank.insertDefaultTask();
                await DisplayAlert("succes", "account aangemaakt", "ok");
            }
            else
            {
                await DisplayAlert("error", "wachtwoord is niet gelijk", "ok");
            }
        }
    }
}
