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
    [RoutePrefix("api/Bundle")]
    public class BundleController : ApiController
    {
        private Models.newDatabaseEntities myDBEntities = new newDatabaseEntities();
        /// <summary>
        /// Method for getting all bundles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage findAll()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(myDBEntities.Bundle.ToList()));
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
