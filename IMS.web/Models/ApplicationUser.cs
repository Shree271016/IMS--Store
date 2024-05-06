using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IMS.web.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
      
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    
        public int StoreId { get; set; }
        public int UserRoleId { get; set; }

        public string profileUrl  { get; set; }  
        public bool IsActived { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string MOdifiedBy { get; set;}


       


    }
}
