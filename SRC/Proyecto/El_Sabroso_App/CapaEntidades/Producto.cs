using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Sabroso_App.CapaEntidades
{
    public class Producto
    {
        
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }


        public int Precio { get; set; }

        public Categoria Categoria { get; set; }   

        public bool Activo  { get; set; }



        public int IdProveedor { get; set; }

        public Proveedor Proveedor{ get; set; }
        public Producto(int idProducto, string nombre, string descripcion, int precio, Categoria categoria, bool activo, int idProveedor, Proveedor Proveedor)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Categoria = categoria;
            Activo = true;
            IdProveedor = idProveedor;
            Proveedor = Proveedor;
            
        }

        public Producto() 
        {
        
        }

        public override string ToString() 
        {
            return Nombre;
        }

    }

    

}
