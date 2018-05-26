using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gearproj.Models
{
    public class Categories
    {
        public int CategoriesId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CategoriesName { get; set; }
        public virtual List<Categories_Model> models { get; set; }

    }
    public class Categories_Model
    {
        public int id { get; set; }
        [ForeignKey("category")]
        public int? CategoriesId { get; set; }
        [ForeignKey("model")]
        public int? ModelId { get; set; }
        public Model model { get; set; }
        public Categories category { get; set; }


    }
}