using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Controllers.Data;
using QLBH.Controllers.Model;
using QLBH.Controllers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //gọi cơ sở dữ liệu để dùng
        private readonly MyDbContext con;
        private readonly IProductRepository _productRepository;


        //nhúng 
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
 

        //gán biến cho cơ sở dữ liệu
        public ProductController(MyDbContext myDb)
        {
            con = myDb;
        }
        //lấy toàn bộ sản phẩm
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_productRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //lấy sản phẩm bằng việc tìm kiếm
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _productRepository.GetById(id);
                if(data!=null)
                {
                    return Ok(data);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        // Tạo mới sản phẩm 
        [HttpPost()]
        [Authorize]
        public IActionResult Createnew(ProductModel model)
        {
            try
            {

                return Ok(_productRepository.Add(model));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // Chỉnh sửa thông tin sản phẩm
        [HttpPut("{id}")]
        public IActionResult UpdateById(Guid id, ProductVM model)
        {
            if(id!= model.maSP)
            {
                return NotFound();
            }    
            try
            {
                 _productRepository.Update(model);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
            // Xóa một sản phẩm 
            [HttpDelete("{id}")]   
        public IActionResult DeleteById(Guid id)
        {
            try
            {
                var data = _productRepository.GetById(id);
                if (data != null)
                {
                    _productRepository.Delete(id);
                    return Ok();
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
