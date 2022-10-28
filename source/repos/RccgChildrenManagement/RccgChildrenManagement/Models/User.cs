using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RccgChildrenManagement.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "FirstName  is required !")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName  is required !")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address  is required !")]
        public string Address { get; set; }
        [Required(ErrorMessage = "PhoneNo  is required !")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "EmailAddress  is required !")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password  is required !")]
        public string Password { get; set; }
       
        [Required(ErrorMessage = "Memeber_Visitor  is required !")]
        public string Member_Visitor { get; set; }
        [Required(ErrorMessage = "Kidnumber  is required !")]
        public int Kidnumber { get; set; }
        public int RoleId { get; set; }
        public bool OtpUsed { get; set; }
        [NotMapped]
        public List<ChildrenDetails> ChildrenDetails { get; set; }
        [NotMapped]
        public string relfn { get; set; }
        [NotMapped]
        public string relln { get; set; }
        [NotMapped]
        public string PersonType { get; set; }
        [NotMapped]
        public string relemail { get; set; }
        [NotMapped]
        public int relphonenumber { get; set; }
      // [Required(ErrorMessage = "NewPassword  is required !")]
        [NotMapped]
        public string? NewPassword { get; set; }
       
        //[Required(ErrorMessage = "ConfirmPassword  is required !")]
       [NotMapped]
       public string ConfirmPassword { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public byte[] RowVersion { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
      //  public IList<UserResponseItem> UserResponses = new List<UserResponseItem>();
    }

    public class ChildrenDetails 
    {
        public string ChildFirstName { get; set; }
        public string ChildLastName { get; set; }   
        public string DOB { get; set; }    
        public string Class { get; set; }
      
    }
}
