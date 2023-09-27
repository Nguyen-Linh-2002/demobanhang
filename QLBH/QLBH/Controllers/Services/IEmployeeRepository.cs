using QLBH.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Services
{
   public interface IEmployeeRepository
    {
        List<EmployeeVM> GetAll();
        EmployeeVM GetByID(Guid id);
        void Delete(Guid id);
        void Update(EmployeeVM model, Guid id);
        //Thêm thông tin mới từ người xem vào model
        EmployeeVM  Add(EmployeeModel model);

    }
}
