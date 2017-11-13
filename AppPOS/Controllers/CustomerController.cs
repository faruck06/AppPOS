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
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private Models.newDatabaseEntities myDBEntities = new newDatabaseEntities();

        /// <summary>
        /// Method who list all current customers in Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage findAll()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(myDBEntities.Customer.ToList()));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Method who finds Customer by Name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("findByName/{Name}")]
        public HttpResponseMessage findByName(string Name)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(
                    myDBEntities.Customer.Single(p => p.Name == Name)));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Default insert single customer in order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage create(Customer customer)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                myDBEntities.Customer.Add(customer);
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
