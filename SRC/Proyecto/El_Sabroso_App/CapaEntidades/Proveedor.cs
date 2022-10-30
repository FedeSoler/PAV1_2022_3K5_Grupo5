using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Sabroso_App.CapaEntidades
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public char Direccion { get; set; }

        public string Ciudad { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public int Activo { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
