using gearproj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gearproj.Controllers
{
    public class ClientProductsController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/ClientProducts
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IHttpActionResult Get(int id)
        {
            List<Product> prods = new List<Product>();
            var bestproducts = db.OrderDetails.GroupBy(i => i.productId).Select(g => new
            {

                count = g.Count(),
                id = g.Key
            }).OrderByDescending(k => k.count).Take(4);
            if (bestproducts == null)
            {
                return BadRequest();
            }
            else
                foreach (var item in bestproducts)
                {
                    prods.Add(db.products.FirstOrDefault(a => a.productId == item.id));
                }

            return Ok(prods);
        }

        // POST: api/ClientProducts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ClientProducts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ClientProducts/5
        public void Delete(int id)
        {
        }
    }
}
