using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Model
{
    public class Address
    {
        public Address(string country, string city, string zip, string street) 
        {
            this.Country = country;
            this.City = city;
            this.ZIP = zip;
            this.Street = street;
        }

        public string Country { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public string Street { get; set; }
    }
}
