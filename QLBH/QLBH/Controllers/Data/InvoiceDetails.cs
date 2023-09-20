using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Data
{
    public class InvoiceDetails
    {
        public Guid maHD { get; set; }
        public Guid maSP { get; set; }
        public int Sluong { get; set; }
        // relationship
        public Product product { get; set; }
        public Invoice invoice { get; set; }
    }
}
