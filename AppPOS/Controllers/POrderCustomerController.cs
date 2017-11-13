using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppPOS.Models;

using System.Net.Http.Handlers;
using Newtonsoft.Json;

/// <summary>
/// Created by Faruck 
/// 13/11/2017
/// </summary>


namespace AppPOS.Controllers
{
    [RoutePrefix("api/POrderCustomer")]
    public class POrderCustomerController : ApiController
    {
        private Models.newDatabaseEntities myDBEntities = new newDatabaseEntities();

        /// <summary>
        /// Method who list all current OrdersWithCustomers in Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage findAll()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(myDBEntities.POrderCustomer.ToList()));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Default insert relation between order and customer
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage create(POrderCustomer Pcustomer)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                myDBEntities.POrderCustomer.Add(Pcustomer);
                myDBEntities.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
