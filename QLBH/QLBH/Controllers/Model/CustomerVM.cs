using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Model
{
    public class CustomerVM
    {
        public Guid maKH { get; set; }
        public String Hoten { get; set; }
        public String Dchi { get; set; }
        public DateTime? Nsinh { get; set; }
    }
}
