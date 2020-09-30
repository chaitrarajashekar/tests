using System;
using System.Collections.Generic;
using System.Linq;
using Web.API.Models;

namespace Web.API.Services
{
    public class CustomerData : ICustomerData
    {   
        //Delete Customer Data
        public int DeleteCustomerData(int id)
        {
            var data = GetMockData().Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                GetMockData().Where(x => x.Id == id).ToList().Remove(data);
                return 0;
            }
            return -1;
        }

        //Get CustomerData by Id
        public List<Customer> GetByMockDataId(int id)
        {
            return GetMockData().Where(x => x.Id == id).ToList();
        }

        //Get all customer data
        public List<Customer> GetAllMockData()
        {
            var customers = GetMockData();
            foreach (var customer in customers)
            {
                foreach (var address in customer.Addresses)
                {
                    if (address.City.ToLower().Equals("chatwood"))
                    {
                        customer.IsPremiumCustomer = true;
                    }
                }
            }
            return customers;
        }

        //Get all customer data
        public List<Customer> GetMockData()
        {
            List<Customer> customer = new List<Customer>{
            new Customer{
                Id=1,
                FirstName="John",
                LastName="Tinker",
                DateOfBirth=Convert.ToDateTime("21-10-1998"),
                IsPremiumCustomer=false,
                Addresses=new List<Address>(){
                    new Address{
                    Street="Waitara Avenue",
                    PostCode=2077,
                    City="Waitra"},
                    new Address{
                    Street="Muriel Street",
                    PostCode=2077,
                    City="Hornsby" } } },

             new Customer{
                Id=2,
                FirstName="Tim",LastName="Hale",
                DateOfBirth=Convert.ToDateTime("21-10-1988"),
                IsPremiumCustomer=false,
                Addresses=new List<Address>(){
                            new Address{
                            Street="Victoria Ave",
                            PostCode=2067,
                            City="ChatWood"}, }},};

            return customer;
        }

        //insert customer data
        public int InsertCustomerData(Customer customer)
        {
            GetMockData().Add(customer);
            return customer.Id;
        }
    }
}
