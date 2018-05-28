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


        // GET: api/Feedbacks/5
        [HttpGet, Route("api/product/{prodid:int}")]
        public IHttpActionResult Get(int prodid)
        {
           var p = db.products.FirstOrDefault(a => a.productId == prodid);
            var f = db.Feedbacks.Where(a => a.Productid == prodid);
            var others = db.products.Where(a => a.CategoryId == p.CategoryId && a.productId != p.productId).Take(3);
            if (p == null)
            {
                return BadRequest();
            }else
            return Ok(new { p, others,f });


        }
        
    }
}
