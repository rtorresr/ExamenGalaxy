using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.DTO
{
    public class UserApp
    {
        public int UserId { get; set; }
        public string Credential { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
