using System;
using System.Collections.Generic;
using planitt.model;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Xaml;

namespace planitt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupView
    {
        public PopupView()
        {
            InitializeComponent();
           
        }

      

        async void Handle_Clicked(object sender, System.EventArgs e)
        {

            var taskName = chooseTask.Text;
            var taskNote = chooseNote.Text;

            bool isTaskNameEmpty = string.IsNullOrEmpty(taskName);
            bool isTaskNoteEmpty = string.IsNullOrEmpty(taskNote);

            if (isTaskNameEmpty || isTaskNoteEmpty)
            {
                await DisplayAlert("error","vul aub iets in","ok");
            }
            else
            {
                Task task = new Task
                {
                    name = taskName,
                    note = taskNote,
                    completed = false,
                    userId = App.user.Id
                };
                await App.MobileService.GetTable<Task>().InsertAsync(task);
            }
            await PopupNavigation.Instance.PopAsync();

        }
    }
}
