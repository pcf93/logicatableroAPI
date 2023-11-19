using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordelia.LoginRegister.Application.DTO
{
    public class UserRegisterDto
    {
        public string UserName { get; set; } = string.Empty;

        public string UserPassword { get; set; } = string.Empty;

        public string UserEmail { get; set; } = string.Empty;

        public string UserPhone { get; set; } = string.Empty;

        public DateTime UserBirthDate { get; set; }

        public string UserCity { get; set; } = string.Empty;
    }
}
