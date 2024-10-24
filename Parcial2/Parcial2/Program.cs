using System;
using System.Collections.Generic;

class Producto
{
    public string Nombre;
    public decimal Precio;
    public string Categoria;

    public Producto(string nombre, decimal precio, string categoria)
    {
        Nombre = nombre;
        Precio = precio;
        Categoria = categoria;
    }
}

class Panaderia
{
    List<Producto> inventario = new List<Producto>();

    public void AgregarProducto(string nombre, decimal precio, string categoria)
    {
        inventario.Add(new Producto(nombre, precio, categoria));
        Console.WriteLine("Producto agregado.");
    }

    public void EliminarProducto(string nombre)
    {
        Producto producto = inventario.Find(p => p.Nombre == nombre);
        if (producto != null)
        {
            inventario.Remove(producto);
            Console.WriteLine("Producto eliminado.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    public void ActualizarProducto(string nombre, decimal precio, string categoria)
    {
        Producto producto = inventario.Find(p => p.Nombre == nombre);
        if (producto != null)
        {
            producto.Precio = precio;
            producto.Categoria = categoria;
            Console.WriteLine("Producto actualizado.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    public void ListarProductos()
    {
        if (inventario.Count == 0)
        {
            Console.WriteLine("No hay productos en el inventario.");
        }
        else
        {
            Console.WriteLine("Inventario:");
            foreach (var producto in inventario)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio}, Categoría: {producto.Categoria}");
            }
        }
    }

    public void CalcularValorInventario()
    {
        decimal total = 0;
        foreach (var producto in inventario)
        {
            total += producto.Precio;
        }
        Console.WriteLine($"Valor total del inventario: {total}");
    }
}

class Program
{
    static void Main()
    {
        Panaderia panaderia = new Panaderia();
        int opcion;

        do
        {
            Console.WriteLine("\n1. Agregar producto\n2. Eliminar producto\n3. Actualizar producto\n4. Listar productos\n5. Calcular valor del inventario\n0. Salir");
            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Precio: ");
                    decimal precio = decimal.Parse(Console.ReadLine());
                    Console.Write("Categoría (Pan/Bizcocho/Pastel): ");
                    string categoria = Console.ReadLine();
                    panaderia.AgregarProducto(nombre, precio, categoria);
                    break;

                case 2:
                    Console.Write("Nombre del producto a eliminar: ");
                    nombre = Console.ReadLine();
                    panaderia.EliminarProducto(nombre);
                    break;

                case 3:
                    Console.Write("Nombre del producto a actualizar: ");
                    nombre = Console.ReadLine();
                    Console.Write("Nuevo precio: ");
                    precio = decimal.Parse(Console.ReadLine());
                    Console.Write("Nueva categoría (Pan/Bizcocho/Pastel): ");
                    categoria = Console.ReadLine();
                    panaderia.ActualizarProducto(nombre, precio, categoria);
                    break;

                case 4:
                    panaderia.ListarProductos();
                    break;

                case 5:
                    panaderia.CalcularValorInventario();
                    break;

                case 0:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }
}