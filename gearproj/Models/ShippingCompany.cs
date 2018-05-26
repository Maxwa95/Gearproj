using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;
using System.Data.Entity; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace gearproj.Models
 { 
    public class ShippingCompany 
    {
        public int ShippingCompanyId { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber{get;set;}
        [Required]
        public int MaxDeliveryDays {get;set;}
        public List<OrderInfo> Orders { get; set; }
    
    } 
            
}