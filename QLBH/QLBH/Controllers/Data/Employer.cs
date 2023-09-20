using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Data
{
    public class Employer
    {
        public Guid maNV { get; set; }
        public String Hoten { get; set; }
        public String Sdt { get; set; }
        public String Dchi { get; set; }
        public DateTime? Nvaolam { get; set; }
        public ICollection<Invoice> invoices { get; set; }
    }
}
