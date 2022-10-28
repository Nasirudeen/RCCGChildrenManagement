using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RccgChildrenManagement.Models
{
    public class FetchQrDetails
    {
        public string ChildFirstName { get; set; }
        public string ChildLastName { get; set; }
        public string ChildrenCode { get; set; }
        public string ParentCode { get; set; }
        public int ChildrenId { get; set; }
    }
}
