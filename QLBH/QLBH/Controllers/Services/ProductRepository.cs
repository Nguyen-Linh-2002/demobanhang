using QLBH.Controllers.Data;
using QLBH.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _con;

        public ProductRepository(MyDbContext conn)
        {
            _con = conn;
        }
        public ProductVM Add(ProductModel model)
        {
            var _product = new Product
            {
                TenSP = model.TenSP,
                DVT = model.DVT,
                GiaSP = model.GiaSP,
                giamgia = model.giamgia,
                Lton = model.Lton
            };
            _con.Add(_product);
            _con.SaveChanges();
            return new ProductVM
            {
                maSP = _product.maSP,
                TenSP = _product.TenSP,
                DVT = _product.DVT,
                GiaSP = _product.GiaSP,
                giamgia = _product.giamgia,
                Lton = _product.Lton
            };
        }

        public void Delete(Guid id)
        {
            var product = _con.products.SingleOrDefault(pr => pr.maSP == id);
            if (product != null)
            {
                _con.Remove(product);
                _con.SaveChanges();
            }
        }

        public List<ProductVM> GetAll()
        {
            var products = _con.products.Select(pr => new ProductVM
            {
                maSP = pr.maSP,
                TenSP = pr.TenSP,
                DVT = pr.DVT,
                GiaSP = pr.GiaSP,
                giamgia = pr.giamgia,
                Lton = pr.Lton
            });
            return products.ToList();
        }

        public ProductVM GetById(Guid id)
        {
            var product = _con.products.SingleOrDefault(pr => pr.maSP == id);
            if (product != null)
            {
                return new ProductVM
                {
                    maSP = product.maSP,
                    TenSP = product.TenSP,
                    DVT = product.DVT,
                    GiaSP = product.GiaSP,
                    giamgia = product.giamgia,
                    Lton = product.Lton
                };
            }
            return null;
        }

        public void Update(ProductVM product)
        {
            var _product = _con.products.SingleOrDefault(pr => pr.maSP == id);
            _product.TenSP = product.TenSP;
            _product.DVT = product.DVT;
            _product.GiaSP = product.GiaSP;
            _product.giamgia = product.giamgia;
            _product.Lton = product.Lton;
            _con.SaveChanges();

        }
    }
}
