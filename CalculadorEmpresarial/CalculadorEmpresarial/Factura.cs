using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CalculadorEmpresarial
{

    //En vez de usar una interfaz para todas las facturas, usé dos diferentes para
    //los productos y servicios, espero no sea muy confuso
    public interface FacturaProducto //Interfaz para los productos - Declarar lo que se necesita de los productos
    {
        int numeroFactura_Productos { get; set; }
        string descripcion_Productos { get; set; }
        int cantidad_Productos { get; set; }
        double precioUnitario_Productos { get; set; }

        void ObtenerFactura(int numeroProducto, string descripcion, int cantidad, double precio);
        double TotalFacturasProductos();

    }

    public interface FacturaServicio // Interfaz servicios - declarar que se necesita para los servicios
    {
        string descripcion_Servicio { get; set; }
        double precio_Servicio { get; set; }

        void ObtenerFactura(string descripcion, double precio);
        double TotalFacturasServicios();
    }

    public class Facturas : FacturaProducto, FacturaServicio
    {
        //Productos
        public int numeroFactura_Productos { get; set; }
        public string descripcion_Productos { get; set; }
        public int cantidad_Productos { get; set; }
        public double precioUnitario_Productos { get; set; }

        public double TotalPagado_Productos;

        //La idea con este es hacer un arreglo apartir de un objeto de clase, y que por cada
        //arreglo se vaya guardando las facturas. En el proceso, va guardando el total de
        //lo que se pago.
        //Esto es igual para el de servicio pero se separa por las interfaces.
        void FacturaProducto.ObtenerFactura(int numeroProducto, string descripcion, int cantidad, double precio)
        {
            numeroFactura_Productos = numeroProducto;
            descripcion_Productos = descripcion;
            cantidad_Productos = cantidad;
            precioUnitario_Productos = precio;

            TotalPagado_Productos += (precio * cantidad);
        }
        //Aqui solo retorna el total que se fue generando a partir de las facturas agregadas
        public double TotalFacturasProductos()
        {
            return TotalPagado_Productos;
        }
        

        //Servicios
        public string descripcion_Servicio { get; set; }
        public double precio_Servicio { get; set; }

        public double TotalPagado_Servicios;

        void FacturaServicio.ObtenerFactura(string descripcion, double precio)
        {
            descripcion_Servicio = descripcion;
            precio_Servicio = precio;

            TotalPagado_Servicios += precio;
        }
        public double TotalFacturasServicios()
        {
            return TotalPagado_Servicios;
        }


        //Toma ambos totales y los suma para retornar el total
        public double TotalFacturas(double TotalProductos, double TotalServicios)
        {
            return TotalProductos + TotalServicios;
        }
    }
}
