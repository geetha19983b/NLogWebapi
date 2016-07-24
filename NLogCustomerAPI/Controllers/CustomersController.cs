using NLogCustomerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NLogCustomerAPI.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
       
        public CustomersController()
        {
            
        }
        public IHttpActionResult Get()
        {
            // _coreLogger.Debug("our log messate");
            IList<Customer> customers = new List<Customer>();
            customers.Add(new Customer() { Name = "Nice customer", Address = "USA", Telephone = "123345456" });
            customers.Add(new Customer() { Name = "Good customer", Address = "UK", Telephone = "9878757654" });
            customers.Add(new Customer() { Name = "Awesome customer", Address = "France", Telephone = "34546456" });
            //throw new NotImplementedException();
            return Ok<IList<Customer>>(customers);
        }
        [Route("CheckId/{id}")]
        [HttpGet]
        public IHttpActionResult CheckId(int id)
        {
            if (id > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Ok(id);
        }
    }
}
