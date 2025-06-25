using System;
using System.Collections.Generic;
using System.Linq;
using TP3juegosDeAzar.Data;
using TP3juegosDeAzar.Models;

namespace TP3juegosDeAzar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                bool continuar = true;

                while (continuar)
                {
                    Console.Write("Escriba el nombre del producto: ");
                    string nombre = Console.ReadLine();

                    int cantidad;
                    do
                    {
                        Console.Write("Escriba la cantidad de números aleatorios a generar: ");
                    } while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0);

                    bool permitirRepetidos = true;
                    if (cantidad <= 100)
                    {
                        Console.Write("¿Los números se pueden repetir? (s/n): ");
                        string respuesta = Console.ReadLine().ToLower();
                        permitirRepetidos = respuesta == "s";
                    }

                    var numerosGenerados = new List<int>();
                    var numeros = new List<Numero>();
                    var rand = new Random();

                    for (int i = 1; i <= cantidad; i++)
                    {
                        int valor;
                        do
                        {
                            valor = rand.Next(0, 100);
                        } while (!permitirRepetidos && numerosGenerados.Contains(valor));

                        numerosGenerados.Add(valor);
                        numeros.Add(new Numero { Orden = i, Valor = valor });
                    }

                    var producto = new Producto
                    {
                        Nombre = nombre,
                        FechaHoraCreacion = DateTime.Now,
                        Numeros = numeros
                    };

                    db.Productos.Add(producto);

                    Console.Write("¿Desea agregar otro producto? (s/n): ");
                    continuar = Console.ReadLine().ToLower() == "s";

                    if (!continuar)
                    {
                        db.SaveChanges();

                        Console.WriteLine("\nProductos y Números generados:\n");

                        var productos = db.Productos.OrderBy(p => p.FechaHoraCreacion).ToList();
                        foreach (var prod in productos)
                        {
                            Console.WriteLine($"{prod.ProductoId}. {prod.Nombre} - {prod.FechaHoraCreacion}");
                            foreach (var num in prod.Numeros.OrderBy(n => n.Orden))
                            {
                                Console.WriteLine($"\t{num.NumeroId}. [{num.Orden}] {num.Valor}");
                            }
                        }

                        Console.WriteLine("\nPrograma finalizado. Presione la tecla Enter para terminar.");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
