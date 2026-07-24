using StudentManagementDTOs.AuthDTOs;
using StudentManagemetBAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagemetBAL.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginDto loginDto)
        {
            // Hardcoded Credentials
            if (loginDto.Username != "admin" ||
                loginDto.Password != "admin@123")
            {
                return null;
            }

            var token = _tokenService.GenerateToken("admin", "Admin");

            var response = new LoginResponseDto
            {
                Token = token,
                Username = "admin",
                Role = "Admin",
                Expiration = DateTime.Now.AddMinutes(60)
            };

            return await Task.FromResult(response);
        }
    }
}
