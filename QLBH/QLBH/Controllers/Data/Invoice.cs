using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Data
{
    public class Invoice
    {
        public Guid maHD { get; set; }
        public DateTime Nlap { get; set; }
        public double Ttien { get; set; }
        public Guid maKH { get; set; }
        public Guid maNV { get; set; }

        public Customer customer { get; set; }
        public Employer employer { get; set; }
        public ICollection<InvoiceDetails> invoiceDetails { get; set; }
    }
}
