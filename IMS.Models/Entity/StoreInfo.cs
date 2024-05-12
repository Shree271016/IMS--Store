using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Models.Entity
{
    public class StoreInfo:BaseEntity
    {
        [Required(ErrorMessage ="Please Input Store Name")]
        [Display(Name = "Store Name")]
        [StringLength(20, MinimumLength = 2)]
        public string StoreName {  get; set; }
        [Required]  
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        public string phoneNumber { get; set; }
        [Required]  
        public string RegistratinNo { get; set; }
        [Required]  
        public string PanNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string MOdifiedBy { get; set; }
        
    }
}
