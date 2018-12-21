using System;
namespace planitt.model
{
    public class Relationship
    {
        public string user_1_id { get; set; }
        public string Id { get; set; }
        public string user_2_id { get; set; }
        public int status { get; set; }
        public string action_user_id { get; set; }
        public string action_user_name { get; set; }

        public Relationship()
        {

        }
        public Relationship(string user_1_id, string user_2_id, int status, string action_user_id, string action_user_name)
        {
            this.user_1_id = user_1_id;
            this.user_2_id = user_2_id;
            this.status = status;
            this.action_user_id = action_user_id;
            this.action_user_name = action_user_name;
        }
    }

}
