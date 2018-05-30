using gearproj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gearproj.Controllers
{
    public class SearchController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/Search
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Search/5
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet, Route("api/Search/results/{key:alpha}")]
        // GET: api/Search/{key:string}
        public IHttpActionResult GetByCharacter(string key)
        {
            List<Product> ProductsResult = db.products.Where(a=>a.ProductName.Contains(key)).ToList<Product>();
            List<Model> ModelsResult = db.Models.Where(a => a.ModelName.Contains(key)).ToList<Model>();
            List<Brand> BrandsResult = db.Brands.Where(a => a.BrandName.Contains(key)).ToList<Brand>();
            if(BrandsResult !=null)
            {
                foreach(var bd in BrandsResult)
                {
                    List<Product> productsperbrand = db.products.Where(a => a.BrandId == bd.BrandId).ToList<Product>();
                    ProductsResult.AddRange(productsperbrand);
                }
            }
            if (ModelsResult != null)
            {
                foreach (var bm in ModelsResult)
                {
                    List<modelsproducts> Modelproducts = db.modelProducts.Where(a => a.modelId == bm.ModelId).ToList<modelsproducts>();
                    if (Modelproducts != null)
                    {
                        foreach (var mpobj in Modelproducts)
                        {
                            List<Product> productsperModel = db.products.Where(a => a.productId == mpobj.productId).ToList<Product>();
                            ProductsResult.AddRange(productsperModel);
                        }
                    }
                }
            }
            return Ok(ProductsResult);
        }

        // POST: api/Search
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Search/5
        public void Delete(int id)
        {
        }
    }
}
