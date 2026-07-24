using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementDTOs.AuthDTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public DateTime Expiration { get; set; }
    }
}
