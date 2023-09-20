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
        private readonly MyDbContext con;
        public ProductController(MyDbContext myDb)
        {
            con = myDb;
        }
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
        [HttpPost()]
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
    }
}
