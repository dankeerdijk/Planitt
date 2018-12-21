using System;
using System.Collections.Generic;
using planitt.model;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace planitt
{
    public partial class ChooseTask : ContentPage
    {
        public ChooseTask()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var tasks = await App.MobileService.GetTable<Task>().Where(t => t.userId == App.user.Id).ToListAsync();
            taskViewList.ItemsSource = tasks;

        }
        
        
    }
    
}
