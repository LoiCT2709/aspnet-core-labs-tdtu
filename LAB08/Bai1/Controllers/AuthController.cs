using Bai1.Models;
using Bail.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bai1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager <IdentityUser> _userManager;
        private readonly UsersContext _context;
        //them
        private readonly IConfiguration _config;

/*        public AuthController(UserManager<IdentityUser> userManager, UsersContext context)
        {
            _userManager = userManager;
            _context = context;
        }
*/
        // Cac phuong thuc
        //1. Đăng kí:

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            if (!ModelState.IsValid) //Kiểm tra hợp lệ, lỗi trả về 400
            {
                return BadRequest(ModelState);
            }
            var result = await _userManager.CreateAsync(
            new IdentityUser { UserName = request.Username, Email = request.Email },
            request.Password
            );
            if (result.Succeeded) //Đăng nhập thành cống
            {
                request.Password = "";
                return CreatedAtAction(nameof(Register), new { email = request.Email }, request);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        //2. Đăng nhập:
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var managedUser = await _userManager.FindByEmailAsync(request.Email);
            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);
            if (userInDb is null)
                return Unauthorized();
            /* return Ok(new AuthResponse
             {
                 Username = userInDb.UserName,
                 Email = userInDb.Email,
             });*/
            var jwtSettings = _config.GetSection("Jwt");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim> {
        new Claim("MyClaim", "Demo")
    };

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponse
            {
                Username = userInDb.UserName,
                Email = userInDb.Email,
                Token = token //tra ve token 
            });
        }
        //them vao
        public AuthController(UserManager<IdentityUser> userManager, UsersContext context,
IConfiguration config)
        {
            _userManager = userManager;
            _context = context;
            _config = config;
        }


    }
}
