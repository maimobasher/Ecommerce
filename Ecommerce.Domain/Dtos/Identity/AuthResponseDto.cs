using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Dtos.Identity
{
    public class AuthResponseDto:IDtos
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
