using Examen.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Services
{
    public interface IUserAppServices
    {
        List<UserApp> ListAll();
    }
}
