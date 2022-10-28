using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RccgChildrenManagement.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

       // [Required(ErrorMessage = "EmailAddress  is required !")]
        public string EmailAddress { get; set; }
      
      //  [Required(ErrorMessage = "ParentCode  is required !")]
        public string ParentCode { get; set; }
        //[NotMapped]
        //public List<ChildrenCodes> ChildrenCode { get; set; }
       // [Required(ErrorMessage = "ChildrenCode  is required !")]
        public string ChildrenCode { get; set; }
       // [Required(ErrorMessage = "ChildrenId  is required !")]
        public int ChildrenId { get; set; }
        //[Required(ErrorMessage = "UserId  is required !")]
        //public int UserId { get; set; }
       
        public string QRImage { get; set; }
        //[Required(ErrorMessage = "DroppedOf  is required !")]
        public bool DroppedOff { get; set; }
       // [Required(ErrorMessage = "PickedUp  is required !")]
        public bool PickedUp { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool isActive { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

public class Attend 
{
    public List<AttendanceDetails> details { get; set; }
}
public class AttendanceDetails 
{   
    public bool isActive { get; set; }
    public int ChildrenId { get; set; }
}

public class ChildrenCodes
{
    public string ChildFirstName { get; set; }
    public string ChildLastName { get; set; }
    public string DOB { get; set; }
    public string Class { get; set; }

}
