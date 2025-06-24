using Microsoft.AspNetCore.Mvc;

namespace Cau3.Controllers
{
    public class BlogController : Controller
    {

        [HttpGet("posts")]
        public IActionResult GetAllPosts()
        {
            return Ok("Danh sách bài viết");
        }

        // Action GetPostById: Truy cập bằng URL /posts/{id:int}
        [HttpGet("posts/{id:int}")]
        public IActionResult GetPostById(int id)
        {
            return Ok($"Bài viết với ID: {id}");
        }

        // Action SearchPosts: Truy cập bằng URL /posts/search/{keyword?}
        [HttpGet("posts/search/{keyword?}")]
        public IActionResult SearchPosts(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return Ok("Tìm kiếm không có từ khóa");
            return Ok($"Kết quả tìm kiếm cho: {keyword}");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
