using Microsoft.AspNetCore.Mvc;

namespace Cau3.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("users/{role:alpha}")]
        public IActionResult GetUsersByRole(string role)
        {
            var validRoles = new List<string> { "admin", "user", "manager" };

            if (!validRoles.Contains(role.ToLower()))
            {
                return BadRequest("Vai trò không hợp lệ. Chỉ chấp nhận: admin, user, manager.");
            }

            return Ok($"Danh sách người dùng có vai trò: {role}");
        }
    }
}
