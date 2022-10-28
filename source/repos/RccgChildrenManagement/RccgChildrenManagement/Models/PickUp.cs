using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RccgChildrenManagement.Models
{
    public class PickUp
    {
        public int PickUpId { get; set; }
        [Required(ErrorMessage = "ChildFirstName  is required !")]
        public string ChildFirstName { get; set; }
        [Required(ErrorMessage = "ChildLastName  is required !")]
        public string ChildLastName { get; set; }
        [Required(ErrorMessage = "DOB  is required !")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Class  is required !")]
        public string Class { get; set; }
        [Required(ErrorMessage = "Action  is required !")]
        public string Action { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
