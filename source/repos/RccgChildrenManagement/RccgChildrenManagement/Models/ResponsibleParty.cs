using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RccgChildrenManagement.Models
{
    public class ResponsibleParty
    {
        public int ResponsiblePartyId { get; set; }

        [Required(ErrorMessage = "relfn  is required !")]
        public string relfn { get; set; }
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "relln  is required !")]
        public string relln { get; set; }
        [Required(ErrorMessage = "RegistrationId  is required !")]
        public int RegistrationId { get; set; }
        [Required(ErrorMessage = "PersonType  is required !")]
        public string PersonType { get; set; }
        [Required(ErrorMessage = "relemail  is required !")]
        public string relemail { get; set; }
        [Required(ErrorMessage = "relphonenumber  is required !")]
        public int relphonenumber { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
