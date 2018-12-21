using System;
namespace planitt.model
{
    public class CardviewDataModel
    {
        public string username { get; set; }
        public string cardText { get; set;}
        public bool update { get; set;}
        public bool invite { get; set; }

        public CardviewDataModel()
        {
        }
    }
}
