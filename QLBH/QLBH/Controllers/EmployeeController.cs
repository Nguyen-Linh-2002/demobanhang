using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _em;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _em = employeeRepository;
        }
        [HttpPost()]
        public IActionResult Create(EmployeeModel model)
        {
            try
            {
                return Ok(_em.Add(model));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_em.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("id")]
        public IActionResult GetByID(Guid id)
        {
            try
            {
                //Kiểm tra nếu người dùng không nhập tìm kiếm
                var data = _em.GetByID(id);
                if (data != null)
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
        [HttpPut("id")]
        public IActionResult Update(EmployeeVM model, Guid id)
        { //Kiểm tra nếu người dùng không nhập tìm kiếm
                if(id == model.maNV)
                {
                    try
                    {
                    _em.Update(model, id);
                    return NoContent();
                    }
                    catch
                    {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                }    
                return NotFound();               
        }
        [HttpDelete("id")]
        public IActionResult Delete(Guid id)
        {

            try
            {
                //Kiểm tra nếu người dùng không nhập tìm kiếm
                var data = _em.GetByID(id);
                if (data != null)
                {
                     _em.Delete(id);
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
