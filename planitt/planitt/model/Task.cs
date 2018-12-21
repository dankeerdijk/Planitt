using System;

namespace planitt.model
{
    public class Task
    {
        public string name { get; set; }
        public bool completed { get; set; }
        public  string note { get; set;}
        public string userId { get; set;}
        public string id { get; set; }

        public Task()
        {

        }

        public Task(string name, bool completed)
        {
            this.name = name;
            this.completed = completed;
        }
        public Task(string name, bool completed, string note, string userId)
        {
            this.name = name;
            this.completed = completed;
            this.note = note;
            this.userId = userId;
        }

    }
}
