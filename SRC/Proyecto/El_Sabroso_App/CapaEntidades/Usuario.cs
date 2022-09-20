using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Sabroso_App.CapaEntidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public int Id_permiso { get; set; }
        public string NombreUsuario { get; set; }

        public string password { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }

        


        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}
