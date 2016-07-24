using LogCustomerAPi.Filters;
using LogCustomerAPi.Logger;
using LogCustomerAPi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogCustomerAPi.Controllers
{
    [LogFilter]
    public class CustomersController : ApiController
    {
        private readonly ICoreLogger _coreLogger;
        public CustomersController(ICoreLogger coreLogger)
        {
            _coreLogger = coreLogger;
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
    }
}
