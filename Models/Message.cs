using System;

namespace chat.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long IdUser { get; set; }
        public long IdRoom { get; set; }
        public DateTime Date { get; set; }
    }
}