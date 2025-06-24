using Cau2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

namespace Cau2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Tran Khiet Loi", Department = "IT", Email = "tkloi2004@gmail.com" },
            new Employee { Id = 2, Name = "Tran Thi B", Department = "IT", Email = "b@example.com" }
        };

        // GET api/employees
        [HttpGet]
        public IActionResult GetAll()
        {
            logger.Info("Lay danh sach nhan vien");
            return Ok(employees);
        }

        // GET api/employees/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                logger.Error($"Khong tim thay nhan vien voi id = {id}");
                return NotFound();
            }

            logger.Info($"Lay chi tiet nhan vien voi id = {id}");
            return Ok(emp);
        }

        // POST api/employees
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
            logger.Info($"Them nhan vien moi: {employee.Name}");
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        // PUT api/employees/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee updated)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                logger.Error($"Cap nhat that bai, khong tim thay nhan vien id = {id}");
                return NotFound();
            }

            emp.Name = updated.Name;
            emp.Department = updated.Department;
            emp.Email = updated.Email;

            logger.Info($"Cap nhat nhan vien id = {id}");
            return NoContent();
        }

        // DELETE api/employees/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                logger.Error($"Xoa that bai, khong tim thay nhan vien id = {id}");
                return NotFound();
            }

            employees.Remove(emp);
            logger.Info($"Da xoa nhan vien id = {id}");
            return NoContent();
        }

    }
}
