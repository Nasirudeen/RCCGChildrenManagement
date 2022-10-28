using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RccgChildrenManagement.Models
{
    public class Otp
    {
        public int OtpId { get; set; }
        public string OtpCode { get; set; }
        public string EmailAddress { get; set; }
        public bool OtpUsed { get; set; }
       
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public byte[] RowVersion { get; set; }

    }
}
