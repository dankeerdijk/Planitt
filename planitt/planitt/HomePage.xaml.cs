using UIKit;
using Xamarin.Forms;





namespace planitt
{
    public partial class HomePage : ContentPage

    {
        public HomePage()
        {
            InitializeComponent();
            var assembly = typeof(LoginPage);
            appLogo.Source = ImageSource.FromResource("planitt.Media.AppLogo.png", assembly);
            welkomtext.Source = ImageSource.FromResource("planitt.Media.welkomText.png", assembly);
            addHouseholdImage.Source = ImageSource.FromResource("planitt.Media.addHousehold.png", assembly);
            addUserImage.Source = ImageSource.FromResource("planitt.Media.addUser.png", assembly);
            inboxImage.Source = ImageSource.FromResource("planitt.Media.inbox.png", assembly);
            BackgroundColor = Color.FromHex("#cce5ff");
            NavigateToPage();
           
            
        }

        private void NavigateToPage()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) =>
            {
                Image image = (Image)sender;
                if (image.StyleId == "createHousehold")
                    Navigation.PushAsync(new CreateHouseHoldPage());
                if (image.StyleId == "invite")
                    Navigation.PushAsync(new InboxPage());
                if (image.StyleId == "addUser")
                    Navigation.PushAsync(new AddPeoplePage());

            };
            addHouseholdImage.GestureRecognizers.Add(tapGestureRecognizer);
            inboxImage.GestureRecognizers.Add(tapGestureRecognizer);
            addUserImage.GestureRecognizers.Add(tapGestureRecognizer);
            
        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HomeTabbedPage());
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
