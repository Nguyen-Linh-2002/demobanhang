using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Data
{
    public class Product
    {
        public Guid maSP { get; set; }
        public String TenSP { get; set; }
        public String DVT { get; set; }
        public double GiaSP { get; set; }
        public double giamgia { get; set; }
        public int Lton { get; set; }
        public ICollection<InvoiceDetails> invoiceDetails { get; set; }
    }
}
