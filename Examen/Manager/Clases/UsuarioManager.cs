using Examen.Models.BE;
using Examen.Models.DTO;
using Examen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Manager
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IUserAppServices userAppServices;
        public UsuarioManager(IUserAppServices userAppServices)
        {
            this.userAppServices = userAppServices;
        }
        public List<Usuario> ListAll()
        {

            return (from x in userAppServices.ListAll()
                    select new Usuario()
                    { 
                        IdUsuario = x.UserId,
                        Credencial = x.Credential,
                        Clave = x.Password,
                        Nombre = x.FullName
                    }).ToList();
        }
    }
}
