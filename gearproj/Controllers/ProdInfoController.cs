using gearproj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gearproj.Controllers
{
    public class ProdInfoController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/Feedbacks
       

        // GET: api/Feedbacks/5
        public IHttpActionResult Get(int prodid)
        {
           var p = db.products.FirstOrDefault(a => a.productId == prodid);
            var f =  db.Feedbacks.Where(a => a.Productid == prodid);
            if (p == null)
            {
                return BadRequest();
            }else
            return Ok(new { p, f });


        }

        // POST: api/Feedbacks
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Feedbacks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Feedbacks/5
        public void Delete(int id)
        {
        }
    }
}
