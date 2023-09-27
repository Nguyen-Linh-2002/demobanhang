using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Model
{
    public class CustomerModel
    {
       
        public String Hoten { get; set; }
    
        public String Dchi { get; set; }
  
        public DateTime? Nsinh { get; set; }
    }
}
