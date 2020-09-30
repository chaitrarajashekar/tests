using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsPremiumCustomer { get; set; }

        public List<Address> Addresses { get; set; }
    }


    public class Address
    {
        public string Street { get; set; }

        public int PostCode { get; set; }

        public string City { get; set; }
    }
}
