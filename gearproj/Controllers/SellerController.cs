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
        
        public IHttpActionResult Get(int id)
        {
            var c = db.Companies.FirstOrDefault(a => a.CompanyId == id);
            if (c == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(c);
            }

        }
        
        [HttpGet, Route("api/seller/products/{companyid:int}")]
        public IHttpActionResult GetProds(int companyid)
        {
            var _var = db.products.Where(a => a.CompanyId == companyid);

            if (_var != null)
            {
                return Ok(_var);
            }
            else
                return BadRequest();
        }
        
        // POST: api/Seller
        [Authorize(Roles = "Seller")]
        [HttpPost, Route("api/seller/product")]
        public IHttpActionResult Post([FromBody]Product product)
        {
           
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return Ok(db.products);
            }
            else
                return BadRequest();

        }

        // PUT: api/Seller/5
        [Authorize(Roles = "Seller")]
        [HttpPut, Route("api/seller/product")]
        public IHttpActionResult Put([FromBody]Product value)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(value).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Ok(db.products);
            }
            else
                return BadRequest();
        }

        [Authorize(Roles = "Seller")]
        [HttpDelete, Route("api/seller/{Companyid:int}/product/{Productid:int}")]
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
