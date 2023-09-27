using QLBH.Controllers.Data;
using QLBH.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Services
{
    public class EmployeeReponsitory : IEmployeeRepository
    {
        private readonly MyDbContext _context;
        //Khai báo data
        public EmployeeReponsitory(MyDbContext context)
        {
            _context = context;
        }
        public EmployeeVM Add(EmployeeModel model)
        {
            var _employee = new Employer()
            {
                Hoten = model.Hoten,
                Sdt = model.Sdt,
                Dchi = model.Dchi,
                Nvaolam = model.Nvaolam
            };
            _context.Add(_employee);
            _context.SaveChanges();
            return new EmployeeVM()
            {
                maNV= _employee.maNV,
                Hoten = _employee.Hoten,
                Sdt =_employee.Sdt,
                Dchi= _employee.Dchi,
                Nvaolam= _employee.Nvaolam
            };
        }

        public void Delete(Guid id)
        {
            var employee = _context.employers.SingleOrDefault(e => e.maNV == id);
            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChanges();
            }          
        }

        public List<EmployeeVM> GetAll()
        {
            var _employees = _context.employers.Select(e => new EmployeeVM
            {
                maNV= e.maNV,
                Hoten = e.Hoten,
                Sdt=e.Sdt,
                Dchi= e.Dchi,
                Nvaolam=e.Nvaolam
            });
            return _employees.ToList();
        }

        public EmployeeVM GetByID(Guid id)
        {
            var employee = _context.employers.SingleOrDefault(e => e.maNV == id);
            if(employee!=null)
            {
                return new EmployeeVM()
                {
                    maNV = employee.maNV,
                    Hoten = employee.Hoten,
                    Sdt = employee.Sdt,
                    Dchi = employee.Dchi,
                    Nvaolam = employee.Nvaolam
                };
            }
            return null;
        }

        public void Update(EmployeeVM model, Guid id)
        {
            var employee = _context.employers.SingleOrDefault(e => e.maNV == id);
            if (employee != null)
            {
                employee.Hoten = model.Hoten;
                employee.Sdt = model.Sdt;
                employee.Dchi = model.Dchi;
                employee.Nvaolam = model.Nvaolam;
            }
            _context.SaveChanges();

        }
    }
}
