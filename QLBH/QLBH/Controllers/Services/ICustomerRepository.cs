using QLBH.Controllers.Data;
using QLBH.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Services
{
    public interface ICustomerRepository
    {
        List<CustomerVM> GetAll();
        CustomerVM GetById(Guid id);
        //Lấy thông tin người nhập từ VM trả về CustomerModel là nơi lưu trữ thông tin từ khách hàng nhập vào
        CustomerVM Add(CustomerModel model);
        void Update(CustomerVM customer, Guid id);
        void Delete(Guid id);
    }
}
