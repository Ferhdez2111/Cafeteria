using ProyectoCafeteria.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCafeteria.WebApi.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);

    }
}
