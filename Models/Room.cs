using System;

namespace chat.Models
{
    public class Room
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
    }
}