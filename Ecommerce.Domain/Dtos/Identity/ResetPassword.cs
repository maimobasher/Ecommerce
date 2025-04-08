using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Dtos.Identity
{
    public class ResetPasswordDto:IDtos
    {
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;  // 
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmNewPassword { get; set; } = string.Empty;  // 
    }
}
