using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementDTOs.AuthDTOs;
using StudentManagemetBAL.Interfaces;

namespace Student_Management_System_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.LoginAsync(loginDto);

            if (result == null)
            {
                return Unauthorized(new
                {
                    Success = false,
                    Message = "Invalid Username or Password"
                });
            }

            return Ok(new
            {
                Success = true,
                Message = "Login Successful",
                Data = result
            });
        }
    }
}
