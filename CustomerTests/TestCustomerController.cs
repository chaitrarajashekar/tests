using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Web.API.Models;
using Web.API.Services;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CustomerTests
{
    [TestClass]
    public class TestCustomerController:Controller
    { 
      
        public List<Customer> GetTestProducts()
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

        [TestMethod]
        public void GetAllCustomers_ShouldReturnAllProducts()
        {
           
            var testProducts = GetTestProducts();
            CustomerData data = new CustomerData();
            var result = data.GetAllMockData().ToList();
            Assert.AreEqual(testProducts.Count, result.Count);
        }

        [TestMethod]
        public void GetCustomersbyId_ShouldReturnOneProduct()
        {
            CustomerData data = new CustomerData();
            var result = data.GetByMockDataId(1).ToList();
            Assert.AreEqual(1, result.Count);
        }
    }
}
