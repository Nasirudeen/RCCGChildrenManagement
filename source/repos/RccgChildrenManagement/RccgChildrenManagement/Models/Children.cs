using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RccgChildrenManagement.Models
{
    public class Children
    {
        public int ChildrenId { get; set; }
        // [Required(ErrorMessage = "EmailAddress  is required !")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "ChildFirstName  is required !")]
        public string ChildFirstName { get; set; }
        [Required(ErrorMessage = "ChildLastName  is required !")]
        public string ChildLastName { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime? DOB { get; set; }
        [Required(ErrorMessage = "Class  is required !")]
        public string Class { get; set; }
        public bool isActive { get; set; }
        [NotMapped] 
        public string Heading { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
