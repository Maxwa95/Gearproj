using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gearproj.Models
{
    public class FeedBack
    {
        public int FeedBackId { get; set; }
        [MaxLength(255)]
        public string Comment { get; set; }
        [ForeignKey("user")]
        public string Userid { get; set; }
        [ForeignKey("prod")]
        public  int Productid { get; set; }
        public  Product prod { get; set; }
        public ApplicationUser user { get; set; }
             
    }
}