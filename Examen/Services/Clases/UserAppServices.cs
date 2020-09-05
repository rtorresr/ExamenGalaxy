using Examen.Contexto;
using Examen.Models.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Services
{
    public class UserAppServices : IUserAppServices
    {
        private readonly ExamenContext examenContext;
        private readonly ILogger<UserAppServices> log;
        public UserAppServices(ExamenContext examenContext, ILogger<UserAppServices> log)
        {
            this.examenContext = examenContext;
            this.log = log;
        }
        public List<UserApp> ListAll()
        {
            log.LogInformation("Llego Listall User App");
            return examenContext.UserApp.ToList();
        }
    }
}
