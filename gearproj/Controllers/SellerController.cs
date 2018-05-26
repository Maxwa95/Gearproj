using gearproj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gearproj.Controllers
{
    public class SellerController : ApiController
    {

        ApplicationDbContext db = new ApplicationDbContext();
       

        // GET: api/Seller/5
        public IHttpActionResult Get(int compid)
        {
            var c = db.Companies.FirstOrDefault(a => a.CompanyId == compid);
            if (c == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(c);
            }

        }

        // POST: api/Seller
        public IHttpActionResult Post([FromBody]Product product)
        {
            db.products.Add(product);
            int i = db.SaveChanges();
            if (i == 1)
            {
                return Ok(db.products);
            }
            else
                return BadRequest();

        }

        // PUT: api/Seller/5
        public IHttpActionResult Put([FromBody]Product value)
        {
            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            int i = db.SaveChanges();
            if (i == 1)
            {
                return Ok(db.products);
            }
            else
                return BadRequest();
        }

        // DELETE: api/Seller/5
        public IHttpActionResult DeleteProd(int Companyid,int Productid)
        {
            var c = db.products.FirstOrDefault(a =>a.CompanyId == Companyid && a.productId == Productid);
            if (c == null)
            {
                return StatusCode(HttpStatusCode.BadRequest);

            }
            else
            {
                db.products.Remove(c);
                db.SaveChanges();
                return Ok(c);
            }

        }
    }
}
