using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.Datos;

namespace Papeleria.Negocio
{
    public class ConexionNegocio
    {
        public async Task<string> ProbarAsync(string clave)
        {
            using var conexion = new Conexion(clave);
            return await conexion.ProbarConexionAsync();
        }
    }
}
