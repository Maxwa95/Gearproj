using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace gearproj.Models
{
    public class Product
    {

        public int productId { get; set; }
        [Required]
        [StringLength(255,MinimumLength = 2)]   
        public string ProductName { get; set; }
        [Required]
        [StringLength(45, MinimumLength = 2)]
        public string PlaceOfOrigin { get; set; }
        [Required]
        [JsonIgnore]
        public DateTime DateOfPublish { get; set; }
        [JsonIgnore]
        public List<Image> Imgs { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("cpy")]
        public int CompanyId { get; set; }
        [ForeignKey("cats")]
        public int CategoryId { get; set; }
        public int Rate { get; set; }
        [JsonIgnore]
        public Company cpy { get; set; }
        [JsonIgnore]
        public Categories cats { get; set; }
        [JsonIgnore]
        public virtual List<FeedBack> feeds { get; set; }


        [ForeignKey("bra")]
        public int BrandId { get; set; }
        [ForeignKey("mod")]
        public int ModelId { get; set; }
        [JsonIgnore]

        public Brand bra { get; set; }
        [JsonIgnore]
        public Model mod { get; set; }
        [JsonIgnore]
        public virtual List<OrderDetails> Orders { get; set; }
        [JsonIgnore]
        public virtual List<SimilaritiesProducts> needs { get; set; }



    }
}
