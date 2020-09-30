using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Models;

namespace Web.API.Services
{
    public interface ICustomerData
    {
        List<Customer> GetMockData();

        List<Customer> GetAllMockData();

        List<Customer> GetByMockDataId( int Id);

        int InsertCustomerData(Customer customer);

        int DeleteCustomerData(int Id);
    }
}
