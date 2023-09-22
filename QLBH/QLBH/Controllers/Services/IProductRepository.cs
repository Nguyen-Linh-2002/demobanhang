using QLBH.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers.Services
{
   public interface IProductRepository
    {
        List<ProductVM> GetAll();
        ProductVM GetById(Guid id);
        ProductVM Add(ProductModel model);
        void Update(ProductVM product);
        void Delete(Guid id);
    }
}
