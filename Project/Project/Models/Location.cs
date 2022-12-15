﻿using Project.Models.Base;

namespace Project.Models
{
    public class Location: BaseEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
    }
}
