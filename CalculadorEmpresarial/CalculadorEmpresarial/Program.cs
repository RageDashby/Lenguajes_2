namespace CalculadorEmpresarial
{
    class Program
    {
        static List<Empleado> empleados = new List<Empleado>();
        static List<FacturaProducto> facturasProductos = new List<FacturaProducto>();
        static List<FacturaServicio> facturasServicios = new List<FacturaServicio>();

        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("1. Registrar empleado");
                Console.WriteLine("2. Registrar factura");
                Console.WriteLine("3. Mostrar reporte");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarEmpleado();
                        break;
                    case "2":
                        RegistrarFactura();
                        break;
                    case "3":
                        MostrarReporte();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void RegistrarEmpleado()
        {
            Console.Write("Tipo de empleado (1: Operador, 2: Técnico, 3: Confianza): ");
            string tipo = Console.ReadLine();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Días trabajados (0-5): ");
            int diasTrabajados = int.Parse(Console.ReadLine());

            if (tipo == "1" || tipo == "2")
            {
                Console.Write("¿Fue puntual? (sí/no): ");
                bool puntualidad = Console.ReadLine().ToLower() == "sí";
                Console.Write("¿Tuvo asistencia perfecta? (sí/no): ");
                bool asistencia = Console.ReadLine().ToLower() == "sí";

                if (tipo == "1")
                    empleados.Add(new Operador(nombre, diasTrabajados, puntualidad, asistencia));
                else
                    empleados.Add(new Tecnico(nombre, diasTrabajados, puntualidad, asistencia));
            }
            else if (tipo == "3")
            {
                Console.Write("¿Tuvo asistencia perfecta? (sí/no): ");
                bool asistencia = Console.ReadLine().ToLower() == "sí";
                empleados.Add(new Confianza(nombre, diasTrabajados, asistencia));
            }
            else
            {
                Console.WriteLine("Tipo no válido.");
            }
        }

        static void RegistrarFactura()
        {
            Console.Write("Tipo de factura (1: Producto, 2: Servicio): ");
            string tipo = Console.ReadLine();

            if (tipo == "1")
            {
                FacturaProductoIndividual factura = new FacturaProductoIndividual();
                Console.Write("Número de factura: ");
                int numero = int.Parse(Console.ReadLine());
                Console.Write("Descripción: ");
                string descripcion = Console.ReadLine();
                Console.Write("Cantidad: ");
                int cantidad = int.Parse(Console.ReadLine());
                Console.Write("Precio unitario: ");
                double precio = double.Parse(Console.ReadLine());
                factura.ObtenerFactura(numero, descripcion, cantidad, precio);
                facturasProductos.Add(factura);
            }
            else if (tipo == "2")
            {
                FacturaServicioIndividual factura = new FacturaServicioIndividual();
                Console.Write("Descripción: ");
                string descripcion = Console.ReadLine();
                Console.Write("Precio: ");
                double precio = double.Parse(Console.ReadLine());
                factura.ObtenerFactura(descripcion, precio);
                facturasServicios.Add(factura);
            }
            else
            {
                Console.WriteLine("Tipo no válido.");
            }
        }

        static void MostrarReporte()
        {
            double totalSueldos = 0;
            Console.WriteLine("--- Empleados ---");
            foreach (var emp in empleados)
            {
                float pago = emp.CalcularPago();
                totalSueldos += pago;
                Console.WriteLine($"Nombre: {emp.Nombre}, Sueldo base: {emp.SueldoBase}, Pago neto: {pago}");
            }

            double totalFacturasProductos = 0;
            Console.WriteLine("--- Facturas de Productos ---");
            foreach (var fp in facturasProductos)
            {
                double total = fp.TotalFacturasProductos();
                totalFacturasProductos += total;
                Console.WriteLine($"Número: {fp.numeroFactura_Productos}, Descripción: {fp.descripcion_Productos}, Cantidad: {fp.cantidad_Productos}, Precio: {fp.precioUnitario_Productos}, Total: {total}");
            }

            double totalFacturasServicios = 0;
            Console.WriteLine("--- Facturas de Servicios ---");
            foreach (var fs in facturasServicios)
            {
                double total = fs.TotalFacturasServicios();
                totalFacturasServicios += total;
                Console.WriteLine($"Descripción: {fs.descripcion_Servicio}, Precio: {fs.precio_Servicio}, Total: {total}");
            }

            double totalFacturas = totalFacturasProductos + totalFacturasServicios;
            double totalGeneral = totalSueldos + totalFacturas;

            Console.WriteLine($"Total sueldos: {totalSueldos}");
            Console.WriteLine($"Total facturas: {totalFacturas}");
            Console.WriteLine($"Total general: {totalGeneral}");
        }
    }
}

