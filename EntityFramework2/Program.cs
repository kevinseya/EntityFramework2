using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using EntityFramework2.BussinesLogic;
using EntityFramework2.Repository;
using System.Drawing;
using EntityFramework2.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Main();
        static void Main()
        {
            BaseEFContext context = new BaseEFContext();
            VentaRepo ventaRepo = new VentaRepo(context);
            VentaBL ventaBL = new VentaBL(ventaRepo);


            while (true)
            {
                Console.WriteLine("************");
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("1. CRUD Categoria");
                Console.WriteLine("2. CRUD Clientes");
                Console.WriteLine("3. CRUD Proveedores");
                Console.WriteLine("4. CRUD Facturas");
                Console.WriteLine("5. CRUD Ventas");
                Console.WriteLine("6. CRUD Productos");
                Console.WriteLine("7. Realizar Venta");
                Console.WriteLine("8. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        MenuCRUD("Categorias");
                        break;
                    case "2":
                        MenuCRUD("Clientes");
                        break;
                    case "3":
                        MenuCRUD("Proveedores");
                        break;
                    case "4":
                        MenuCRUD("Facturas");
                        break;
                    case "5":
                        MenuCRUD("Ventas");
                        break;
                    case "6":
                        MenuCRUD("Productos");
                        break;
                    case "7":
                        ventaBL.realizarVenta();
                        break;
                    case "8":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }

            }
        }
        static void MenuCRUD(string entidad)
        {
            BaseEFContext context = new BaseEFContext();
            ClienteRepo clienteRepo = new ClienteRepo(context);
            ProveedorRepo proveedorRepo = new ProveedorRepo(context); 
            CategoriaRepo categoriaRepo = new CategoriaRepo(context);
            FacturaRepo facturaRepo = new FacturaRepo(context);
            VentaRepo ventaRepo = new VentaRepo(context);
            ProductoRepo productoRepo = new ProductoRepo(context);
            ClienteBL clienteBL = new ClienteBL(clienteRepo);
            ProveedorBL proveedorBL = new ProveedorBL(proveedorRepo);
            CategoriaBL categoriaBL = new CategoriaBL(categoriaRepo);
            FacturaBL facturaBL = new FacturaBL(facturaRepo);
            ProductoBL productoBL = new ProductoBL(productoRepo);
            VentaBL ventaBL = new VentaBL(ventaRepo);
            

            Console.WriteLine("************");
            Console.WriteLine($"\nMENU {entidad.ToUpper()}");
            Console.WriteLine($"1. Crear {entidad}");
            Console.WriteLine($"2. Consultar {entidad}");
            Console.WriteLine($"3. Actualizar {entidad}");
            Console.WriteLine($"4. Eliminar {entidad}");
            Console.WriteLine($"5. Volver al Menú Principal");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();
            try
            {
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("************");
                        Console.WriteLine($"CREAR {entidad}");
                        switch (entidad)
                        {
                            case "Categorias":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese la Descripcion: ");
                                string nuevaDescr = Console.ReadLine();
                                Categoria cat = new Categoria { Descripcion = nuevaDescr };
                                categoriaBL.crearCategoria(cat);

                                break;
                            case "Proveedores":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese los Nombres: ");
                                string nuevoNombreP = Console.ReadLine();
                                Console.Write("Ingrese la dirección: ");
                                string nuevaDireccionP = Console.ReadLine();
                                Console.Write("Ingrese el telefono: ");
                                string nuevoTelfP = Console.ReadLine();
                                Proveedor prov = new Proveedor { Nombre = nuevoNombreP, Direccion = nuevaDireccionP, Telefono = nuevoTelfP };
                                proveedorBL.crearProveedor(prov);
                                break;
                            case "Clientes":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese los Nombres: ");
                                string nuevoNombres = Console.ReadLine();
                                Console.Write("Ingrese el Telefono ");
                                string nuevoTelf = Console.ReadLine();
                                Console.Write("Ingrese la Direccion: ");
                                string nuevaDireccion = Console.ReadLine();
                                Cliente cli = new Cliente { Nombres = nuevoNombres, Telefono = nuevoTelf, Direccion = nuevaDireccion };
                                clienteBL.crearCliente(cli);
                                break;
                            case "Facturas":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese el id del cliente: ");
                                int.TryParse(Console.ReadLine(), out int idCliente);
                                Console.Write("Ingrese la fecha de la factura (YYYY-MM-DD): ");
                                DateTime.TryParse(Console.ReadLine(), out DateTime fechaFactura);
                                Factura fact = new Factura { Id_Cliente = idCliente, Fecha = fechaFactura };
                                facturaBL.crearFactura(fact);
                                break;
                            case "Ventas":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese la Cantidad:");
                                int.TryParse(Console.ReadLine(), out int cantidad);
                                Console.Write("Ingrese la id de la Factura:");
                                int.TryParse(Console.ReadLine(), out int idFactura);
                                Console.Write("Ingrese la id del producto: ");
                                int.TryParse(Console.ReadLine(), out int idProducto);
                                Venta vent = new Venta { Id_Factura = idFactura , Id_Producto = idProducto, Cantidad = cantidad };
                                ventaBL.crearVenta(vent);
                                break;
                            case "Productos":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese la descripción del producto: ");
                                string descripcion = Console.ReadLine();
                                Console.Write("Ingrese el precio(decimal) del producto: ");
                                decimal precio = decimal.Parse(Console.ReadLine());
                                Console.Write("Ingrese la id de la categoria: ");
                                int.TryParse(Console.ReadLine(), out int idCategoria);
                                Console.Write("Ingrese la id del proveedor: ");
                                int.TryParse(Console.ReadLine(), out int idProveedor);
                                Producto producto = new Producto { Descripcion = descripcion, precio = precio, Id_Categoria = idCategoria, Id_Proveedor = idProveedor };
                                productoBL.crearProducto(producto); 
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("************");
                        Console.WriteLine($"CONSULTAR {entidad}");
                        switch (entidad)
                        {
                            case "Categorias":
                                Console.WriteLine($"1. Listar ");
                                Console.WriteLine($"2. Consulta específica ");
                                Console.WriteLine($"3. Consulta Eager");
                                Console.WriteLine($"4. Regresar");
                                Console.Write("Seleccione una opción: ");
                                string opcion2 = Console.ReadLine();
                                switch (opcion2)
                                {
                                    case "1":
                                        Console.WriteLine("***********");
                                        categoriaBL.consultaCategoria();


                                        break;
                                    case "2":
                                        Console.WriteLine("***********");
                                        Console.WriteLine("Ingrese el nombre de la categoria a buscar");
                                        string nombreBuscar = Console.ReadLine();
                                        categoriaBL.consultaDatoEspecifico(nombreBuscar);

                                        break;
                                    case "3":
                                        Console.WriteLine("***********");
                                        categoriaBL.consultaDatoEAGER();

                                        break;
                                    case "4":
                                        return;
                                }

                                break;
                            case "Proveedores":
                                Console.WriteLine($"1. Listar ");
                                Console.WriteLine($"2. Consulta específica ");
                                Console.WriteLine($"3. Consulta Eager");
                                Console.WriteLine($"4. Regresar");
                                Console.Write("Seleccione una opción: ");
                                string opcion3 = Console.ReadLine();
                                switch (opcion3)
                                {
                                    case "1":
                                        Console.WriteLine("***********");
                                        proveedorBL.consultaProveedor();

                                        break;
                                    case "2":
                                        Console.WriteLine("***********");
                                        Console.WriteLine("Ingrese el nombre del proveedor a buscar");
                                        string nombreBuscar = Console.ReadLine();
                                        proveedorBL.consultaDatoEspecifico(nombreBuscar);

                                        break;
                                    case "3":
                                        Console.WriteLine("***********");
                                        proveedorBL.consultaDatoEAGER();
                                        break;
                                    case "4":
                                        return;
                                }
                                break;
                            case "Clientes":
                                Console.WriteLine($"1. Listar ");
                                Console.WriteLine($"2. Consulta específica ");
                                Console.WriteLine($"3. Consulta Eager");
                                Console.WriteLine($"4. Regresar");
                                Console.Write("Seleccione una opción: ");
                                string opcion4 = Console.ReadLine();
                                switch (opcion4)
                                {
                                    case "1":
                                        Console.WriteLine("***********");
                                        clienteBL.consultaCliente();
                                        break;
                                    case "2":
                                        Console.WriteLine("***********");
                                        Console.WriteLine("Ingrese el apellido de los clientes a buscar");
                                        string apellidoBuscar = Console.ReadLine();
                                        clienteBL.consultaDatoEspecifico(apellidoBuscar);
                                        break;
                                    case "3":
                                        Console.WriteLine("***********");
                                        clienteBL.consultaDatoEAGER();
                                        break;
                                    case "4":
                                        return;
                                }
                                break;
                            case "Facturas":
                                Console.WriteLine($"1. Listar ");
                                Console.WriteLine($"2. Consulta específica ");
                                Console.WriteLine($"3. Consulta Eager");
                                Console.WriteLine($"4. Regresar");
                                Console.Write("Seleccione una opción: ");
                                string opcion5 = Console.ReadLine();
                                switch (opcion5)
                                {
                                    case "1":
                                        Console.WriteLine("***********");
                                        facturaBL.consultaFactura();
                                        break;
                                    case "2":
                                        Console.WriteLine("***********");
                                        Console.WriteLine("Ingrese el nombre del cliente para la factura a buscar");
                                        string nombreBuscar = Console.ReadLine();
                                        facturaBL.consultaDatoEspecifico(nombreBuscar);
                                        break;
                                    case "3":
                                        Console.WriteLine("***********");
                                        facturaBL.consultaDatoEAGER();
                                        break;
                                    case "4":
                                        return;
                                }
                                break;
                            case "Ventas":
                                Console.WriteLine($"1. Listar ");
                                Console.WriteLine($"2. Consulta específica ");
                                Console.WriteLine($"3. Consulta Eager");
                                Console.WriteLine($"4. Regresar");
                                Console.Write("Seleccione una opción: ");
                                string opcion6 = Console.ReadLine();
                                switch (opcion6)
                                {
                                    case "1":
                                        Console.WriteLine("***********");
                                        ventaBL.consultaVenta();
                                        break;
                                    case "2":
                                        Console.WriteLine("***********");
                                        Console.WriteLine("Ingrese el nombre del producto para la venta a buscar");
                                        string nombreBuscar = Console.ReadLine();
                                        ventaBL.consultaDatoEspecifico(nombreBuscar);
                                        break;
                                    case "3":
                                        Console.WriteLine("***********");
                                        ventaBL.consultaDatoEAGER();
                                        break;
                                    case "4":
                                        return;
                                }
                                break;
                            case "Productos":
                                Console.WriteLine($"1. Listar ");
                                Console.WriteLine($"2. Consulta específica ");
                                Console.WriteLine($"3. Consulta Eager");
                                Console.WriteLine($"4. Regresar");
                                Console.Write("Seleccione una opción: ");
                                string opcion7 = Console.ReadLine();
                                switch (opcion7)
                                {
                                    case "1":
                                        Console.WriteLine("***********");
                                        productoBL.consultaProducto();
                                        break;
                                    case "2":
                                        Console.WriteLine("***********");
                                        Console.WriteLine("Ingrese el nombre del proveedor para el producto a buscar");
                                        string nombreBuscar = Console.ReadLine();
                                        productoBL.consultaDatoEspecifico(nombreBuscar);
                                        break;
                                    case "3":
                                        Console.WriteLine("***********");
                                        productoBL.consultaDatoEAGER();
                                        break;
                                    case "4":
                                        return;
                                }
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("************");
                        Console.WriteLine($"ACTUALIZAR {entidad}");
                        switch (entidad)
                        {
                            case "Categorias":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese el id de la categoria a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int idCategoria1);
                                Console.Write("Ingrese la Descripcion a actualizar: ");
                                String actualizarDescripcionCat = Console.ReadLine();
                                categoriaBL.actualizarCategoria(idCategoria1, actualizarDescripcionCat);
                                break;
                            case "Proveedores":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese el id del proveedor a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int idProveedor1);
                                Console.Write("Ingrese los Nombres a actualizar: ");
                                String actualizarNombreP = Console.ReadLine();
                                Console.Write("Ingrese la Direccion a actualizar: ");
                                String actualizarDireccionP = Console.ReadLine();
                                Console.Write("Ingrese el Telefono a actualizar: ");
                                String actualizarTelfP = Console.ReadLine();
                                proveedorBL.actualizarProveedor(idProveedor1, actualizarNombreP, actualizarDireccionP, actualizarTelfP);
                                break;
                            case "Clientes":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese el id del cliente a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int idCliente1);
                                Console.Write("Ingrese los Nombres a actualizar: ");
                                String actualizarNombre = Console.ReadLine();
                                Console.Write("Ingrese el Telf a actualizar: ");
                                String actualizarTelf = Console.ReadLine();
                                Console.Write("Ingrese la Direccion a actualizar: ");
                                String actualizarDireccion = Console.ReadLine();
                                clienteBL.actualizarCliente(idCliente1, actualizarNombre, actualizarTelf, actualizarDireccion);
                                break;
                            case "Facturas":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese el id de la factura a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int idFactura1);
                                Console.Write("Ingrese la fecha de la factura (YYYY-MM-DD): ");
                                DateTime.TryParse(Console.ReadLine(), out DateTime fechaFactura);
                                Console.Write("Ingrese el id del Cliente a actualizar:");
                                int.TryParse(Console.ReadLine(), out int idCliente);
                                facturaBL.actualizarFactura(idFactura1,fechaFactura,idCliente);
                                break;
                            case "Ventas":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese el id de la venta a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int idVenta1);
                                Console.Write("Ingrese el id de la factura a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int idfacturaV);
                                Console.Write("Ingrese el id del prodcuto a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int idproductoV);
                                Console.Write("Ingrese la cantidad a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int cantidad);
                                ventaBL.actualizarVenta(idVenta1,cantidad,idfacturaV,idproductoV);
                                break;
                            case "Productos":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese el id del producto a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int idProducto1);
                                Console.Write("Ingrese la Descripcion a actualizar: ");
                                String actualizarNombrePr = Console.ReadLine();
                                Console.Write("Ingrese el precio (decimal) a actualizar: ");
                                decimal.TryParse(Console.ReadLine(), out decimal actualizarPrecioPr);
                                Console.Write("Ingrese el id del proveedor a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int idProveedor);
                                Console.Write("Ingrese el id de la categoria a actualizar: ");
                                int.TryParse(Console.ReadLine(), out int idCategoria);
                                productoBL.actualizarProducto(idProducto1,actualizarNombrePr,actualizarPrecioPr,idProveedor,idCategoria);
                                break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("************");
                        Console.WriteLine($"ELIMINAR {entidad}");
                        switch (entidad)
                        {
                            case "Categorias":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese el id de la categoria a eliminar: ");
                                int.TryParse(Console.ReadLine(), out int idCategoria);
                                categoriaBL.eliminarCategoria(idCategoria);
                                break;
                            case "Proveedores":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese el id del proveedor a eliminar: ");
                                int.TryParse(Console.ReadLine(), out int idProveedor);
                                proveedorBL.eliminarProveedor(idProveedor);
                                break;
                            case "Clientes":
                                Console.Write("Ingrese el id del cliente a eliminar: ");
                                int.TryParse(Console.ReadLine(), out int idCliente1);
                                clienteBL.eliminarCliente(idCliente1);
                                break;
                            case "Facturas":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese el id de la factura a eliminar: ");
                                int.TryParse(Console.ReadLine(), out int idFactura);
                                facturaBL.eliminarFactura(idFactura);
                                break;
                            case "Ventas":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese el id de la venta a eliminar: ");
                                int.TryParse(Console.ReadLine(), out int idVenta);
                                ventaBL.eliminarVenta(idVenta);
                                break;
                            case "Productos":
                                Console.WriteLine("***********");
                                Console.Write("Ingrese el id del prodcuto a eliminar: ");
                                int.TryParse(Console.ReadLine(), out int idProducto);
                                productoBL.eliminarProducto(idProducto);
                                break;
                        }
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no valida");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}