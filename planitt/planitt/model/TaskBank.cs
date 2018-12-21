using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace planitt.model
{
    public class TaskBank
    {
         public TaskBank()
        {

        }

        async public void insertDefaultTask()
        {
            int count;
            int index;
            var mainTaskList = new List<Task>();
            mainTaskList.Add(new Task("kamer opruimen", false, "",App.user.Id));
            mainTaskList.Add(new Task("keuken opruimen", false, "",App.user.Id));
            mainTaskList.Add(new Task("vuilnis buiten zetten", false, "",App.user.Id));
            mainTaskList.Add(new Task("woonkamer opruimen", false, "",App.user.Id));
            mainTaskList.Add(new Task("de was doen", false, "",App.user.Id));
            mainTaskList.Add(new Task("de afwas doen", false, "",App.user.Id));
            mainTaskList.Add(new Task("boodschappen doen", false, "",App.user.Id));
            mainTaskList.Add(new Task("badkamer poetsen", false, "",App.user.Id));
            mainTaskList.Add(new Task("wc poetsen", false, "",App.user.Id));

            count = mainTaskList.Count;
            index = 0;
            while (count != index)
            {
                await App.MobileService.GetTable<Task>().InsertAsync(mainTaskList[index]);
                index++;
            }
        }

    }
}
