using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Dtos
{
    public class ReviewDto
    {
        public string? Content { get; set; }
        public int? Rating { get; set; } // 1 to 5
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
    }
}
