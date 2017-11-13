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
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private Models.newDatabaseEntities myDBEntities = new newDatabaseEntities();

        /// <summary>
        /// Method who list all current products in Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage findAll() {
            try {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(myDBEntities.Product.ToList()));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return result;
            } catch {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Method who finds product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("find/{id}")]
        public HttpResponseMessage find(int id)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(
                    myDBEntities.Product.Single(p => p.Id == id)));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Method who finds Products by Name
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
                    myDBEntities.Product.Single(p => p.Name == Name)));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Method who finds a bundle for product ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("findWithBundles/{id}")]
        public HttpResponseMessage findWithBundles(int id)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                
                string contenido = JsonConvert.SerializeObject(
                                    myDBEntities.Bundle.Where(r=> r.Id == myDBEntities.Bundle.Where(p => p.Product == id ).Max(p=> p.Parent)));
                

                result.Content = new StringContent(contenido);
                
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

    }
}
