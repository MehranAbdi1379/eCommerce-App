using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Contracts.DTO
{
    public class EmailVerificationDTO
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
