using System;
using System.Collections.Generic;

namespace TheHubCafe.Models
{
    public class Salad
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string ingredients { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}