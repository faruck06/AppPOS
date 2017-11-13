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
    [RoutePrefix("api/Purchase")]
    public class PurchaseController : ApiController
    {
        private Models.newDatabaseEntities myDBEntities = new newDatabaseEntities();

        /// <summary>
        /// Default insert single product in order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage create(POrder order)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                myDBEntities.POrder.Add(order);
                myDBEntities.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Method who Iterates through products in product bundle to create each product in an order record
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createBundle")]
        public HttpResponseMessage createBundle(POrder order)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                Bundle bundle = myDBEntities.Bundle.Where(r => r.Id == myDBEntities.Bundle.Where(p => p.Product == order.ProductId).Max(p => p.Parent)).ToArray()[0];
              
                List<Bundle> lista = new List<Bundle>();
                lista = myDBEntities.Bundle.Where(p => p.Parent == bundle.Id).ToList();
                Random rnd = new Random();
    
                foreach (Bundle itera in lista)
                {
                    POrder orden = new POrder();
                    //We dont set the orden ID because is auto-generated
                    //orden.Id = order.Id;
                    orden.orderId = order.orderId;
                    orden.ProductId = (int)itera.Product;
                    myDBEntities.POrder.Add(orden);
                    myDBEntities.SaveChanges();
                }
                
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

    }
}
