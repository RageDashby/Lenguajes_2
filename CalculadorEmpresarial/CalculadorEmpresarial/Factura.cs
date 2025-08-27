using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CalculadorEmpresarial
{

    public interface FacturaProducto
    {
        int numeroFactura_Productos { get; set; }
        string descripcion_Productos { get; set; }
        int cantidad_Productos { get; set; }
        double precioUnitario_Productos { get; set; }
        void ObtenerFactura(int numeroProducto, string descripcion, int cantidad, double precio);
        double TotalFacturasProductos();
    }

    public interface FacturaServicio
    {
        string descripcion_Servicio { get; set; }
        double precio_Servicio { get; set; }
        void ObtenerFactura(string descripcion, double precio);
        double TotalFacturasServicios();
    }

    public class FacturaProductoIndividual : FacturaProducto
    {
        public int numeroFactura_Productos { get; set; }
        public string descripcion_Productos { get; set; }
        public int cantidad_Productos { get; set; }
        public double precioUnitario_Productos { get; set; }

        public void ObtenerFactura(int numeroProducto, string descripcion, int cantidad, double precio)
        {
            numeroFactura_Productos = numeroProducto;
            descripcion_Productos = descripcion;
            cantidad_Productos = cantidad;
            precioUnitario_Productos = precio;
        }

        public double TotalFacturasProductos()
        {
            return cantidad_Productos * precioUnitario_Productos;
        }
    }

    public class FacturaServicioIndividual : FacturaServicio
    {
        public string descripcion_Servicio { get; set; }
        public double precio_Servicio { get; set; }

        public void ObtenerFactura(string descripcion, double precio)
        {
            descripcion_Servicio = descripcion;
            precio_Servicio = precio;
        }

        public double TotalFacturasServicios()
        {
            return precio_Servicio;
        }
    }
}
