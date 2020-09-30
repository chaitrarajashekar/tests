using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.API.Filters;
using Web.API.Models;
using Web.API.Services;

namespace Web.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [BasicAuth]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerData _customerRepo;

        public CustomerController(ILogger<CustomerController> logger, ICustomerData customerRepo)
        {
            _logger = logger;
            _customerRepo = customerRepo;
        }

        [HttpGet,Route("getallcustomers")]
        public ActionResult GetAllCustomers()
        
        {
            try
            {
                _logger.Log(LogLevel.Information, "GET:All Customer details API Invoked.");
                return Ok(_customerRepo.GetAllMockData().ToList());
            }
            catch (Exception)
            {
                _logger.Log(LogLevel.Information, "GET:All Customer details API failed.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data");
            }

        }

        [HttpGet, Route("getdetailsbyid/{id}")]
        public ActionResult GetDetailsById(int id)
        {
            try
            {
                _logger.Log(LogLevel.Information,string.Format("GET:Customer details API for id:{0} Invoked.",id));
                var result = _customerRepo.GetByMockDataId(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                _logger.Log(LogLevel.Information, string.Format("GET:Customer details API for id:{0} failed.", id));
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data");
            }

        }
        [HttpPost, Route("insert")]
        public ActionResult Insert([FromBody] Customer customer)
        {
            try
            {
                _logger.Log(LogLevel.Information, "POST:Insert Customer details API Invoked.");
                if (customer == null)
                {
                    return BadRequest();
                }

                int id = _customerRepo.InsertCustomerData(customer);
                return Ok(id);

            }
            catch (Exception)
            {
                _logger.Log(LogLevel.Error, "POST:Insert Customer details API failed.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error sending data");
            }

        }
        [HttpDelete, Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _logger.Log(LogLevel.Information, string.Format("DELETE:delete Customer details API Invoked for Id:{0}", id));
                var customer = _customerRepo.GetByMockDataId(id);

                if (customer == null)
                {
                    return NotFound($"Customer with Id = {id} not found");
                }

                return Ok(_customerRepo.DeleteCustomerData(id));
            }
            catch (Exception)
            {
                _logger.Log(LogLevel.Error,string.Format( "DELETE:delete Customer details API Failed for Id:{0}",id));
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }

        }
    }
}
