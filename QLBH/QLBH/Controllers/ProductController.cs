using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Controllers.Data;
using QLBH.Controllers.Model;
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
                var productlist = con.products.ToList();
                return Ok(productlist);
            }
            catch
            {
                return BadRequest();
            }
        }
        //lấy sản phẩm bằng việc tìm kiếm
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var product = con.products.FirstOrDefault(p => p.maSP == id);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        // Tạo mới sản phẩm 
        [HttpPost()]
        [Authorize]
        public IActionResult Createnew(ProductModel model)
        {
            try
            {
                var product = new Product
                {
                    TenSP = model.TenSP,
                    DVT = model.DVT,
                    GiaSP = model.GiaSP,
                    giamgia = model.giamgia,
                    Lton = model.Lton
                };
                con.Add(product);
                con.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch
            {
                return BadRequest();
            }
        }

        // Chỉnh sửa thông tin sản phẩm
        [HttpPut("{id}")]
        public IActionResult UpdateById(Guid id, ProductModel model)
        {
            try
            {
                var product = con.products.FirstOrDefault(p => p.maSP == id);
                if (product != null)
                {
                    product.TenSP = model.TenSP;
                    product.DVT = model.DVT;
                    product.GiaSP = model.GiaSP;
                    product.giamgia = model.giamgia;
                    product.Lton = model.Lton;
                    con.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
            // Xóa một sản phẩm 
            [HttpDelete("{id}")]   
        public IActionResult DeleteById(Guid id)
        {
            try
            {
                var product = con.products.FirstOrDefault(p => p.maSP == id);
                if (product != null)
                {
                    con.Remove(product);
                    con.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
