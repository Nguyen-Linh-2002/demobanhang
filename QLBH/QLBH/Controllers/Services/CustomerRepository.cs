using QLBH.Controllers.Data;
using QLBH.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MyDbContext _con;

       public CustomerRepository(MyDbContext context)
        {
            _con = context;
        }
        public CustomerVM Add(CustomerModel model)
        {
            //khai báo một data customer và gán giá trị nhập từ người dùng
            var _customer = new Customer()
            {
                Hoten = model.Hoten,
                Dchi = model.Dchi,
                Nsinh = model.Nsinh
               
            };
            _con.Add(_customer);
            _con.SaveChanges();
            //trả thông tin nhập về cho người xem
            return new CustomerVM
            {
                maKH= _customer.maKH,
                Hoten = _customer.Hoten,
                Dchi = _customer.Dchi,
                Nsinh = _customer.Nsinh
            };
        }

        public void Delete(Guid id)
        {
            //Tìm kiếm sự có mặt từ thực thể b kiếm 
            var _customer = _con.customers.SingleOrDefault(c => c.maKH == id);
            if(_customer!= null)
            {
                _con.Remove(_customer);
                _con.SaveChanges();
            }    
        }

        public List<CustomerVM> GetAll()
        {
            var customers = _con.customers.Select(c => new CustomerVM
            {
                maKH = c.maKH,
                Hoten = c.Hoten,
                Dchi = c.Dchi,
                Nsinh = c.Nsinh
            });
            return customers.ToList();
        }

        public CustomerVM GetById(Guid id)
        {
            var _customer = _con.customers.SingleOrDefault(c => c.maKH == id);// c là 1 phần tử trong mảng
            if (_customer != null)
            {
                return new CustomerVM
                {
                    maKH = _customer.maKH,
                    Hoten = _customer.Hoten,
                    Dchi = _customer.Dchi,
                    Nsinh = _customer.Nsinh
                };
            }
            return null;    
        }

        public void Update(CustomerVM customer, Guid id)
        {
            var _customer = _con.customers.SingleOrDefault(c => c.maKH == id);
            _customer.Hoten = customer.Hoten;
            _customer.Dchi = customer.Dchi;
            _customer.Nsinh = customer.Nsinh;
            _con.SaveChanges();
        }
    }
}
