using System;
using System.Collections.Generic;
using System.Linq;

using planitt.model;
using Xamarin.Forms;

namespace planitt
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            var assembly = typeof(LoginPage);

            appLogoImage.Source = ImageSource.FromResource("planitt.Media.AppLogo.png", assembly);
        }

        async void  Handle_Clicked(object sender, System.EventArgs e)
        {
            bool isUsernameEmpty = string.IsNullOrEmpty(username.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(password.Text);

            if (isPasswordEmpty || isUsernameEmpty)
            {
                await DisplayAlert("error", "vul aub iets in", "oke");
            }
            else
            {
                var user = (await App.MobileService.GetTable<User>().Where(u => u.Username == username.Text).ToListAsync()).FirstOrDefault();

                if (user != null)
                {
                    App.user = user;
                    if (user.Password == password.Text)
                    {
                        var assembly = typeof(LoginPage);
                        HomePage homePage = new HomePage();
                        NavigationPage.SetHasBackButton(homePage, false);
                        await Navigation.PushAsync(homePage);

                    }
                    else
                    {
                        await DisplayAlert("error", "gebruikersnaam of wachtwoord incorrect", "oke");
                    }
                }
                else
                {
                    await DisplayAlert("error", "probleem met inloggen", "oke");
                }
            }
        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {

            Navigation.PushAsync(new CreateAccountPage());
        }
    }
}
