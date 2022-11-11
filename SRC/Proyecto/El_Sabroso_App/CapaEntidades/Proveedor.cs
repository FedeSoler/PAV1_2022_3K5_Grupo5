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
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public string Ciudad { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public int Activo { get; set; }

        public Proveedor(string nombre,string apellido,string email,string telefono,string direccion,string ciudad,DateTime fechaalta)
        { this.Nombre = nombre;
          this.Apellido = apellido;
          this.Email = email;
          this.Telefono = telefono;
          this.Direccion = direccion;
          this.Ciudad = ciudad;
          this.Fecha_Alta = fechaalta;
          this.Activo = 1;
        }
        public Proveedor(int idProveedor, string nombre, string apellido, string email, string telefono, string direccion, string ciudad, DateTime fecha_Alta)
        {
            IdProveedor = idProveedor;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
            Direccion = direccion;
            Ciudad = ciudad;
            Fecha_Alta = fecha_Alta;
            Activo = 1;
        }

        public Proveedor()
        {
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
