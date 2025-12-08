
using ProyectoFinal_ProgramacionParalela.Models;
using System;
using System.Collections.Generic;

namespace ProyectoFinal_ProgramacionParalela.Data
{
    public static class GeneradorDatos
    {
        private static readonly Random random = new Random();

        private static readonly string[] Marcas = { "Sony", "Samsung", "LG", "Panasonic", "HP", "Dell", "Lenovo", "Asus", "Acer", "Apple", "Microsoft", "Xiaomi" };
        private static readonly string[] Modelos = { "Ultra", "Pro", "Max", "Lite", "Air", "Gaming", "Office", "Home" };
        private static readonly string[] Sufijos = { "X1", "v2", "G5", "Series 5", "2024", "2025" };
        private static readonly string[] TiposProducto = { "TV 4K", "Smartphone", "Laptop", "Monitor", "Tablet", "Auriculares", "Reloj", "Cámara" };

        /// <summary>
        /// Genera una lista de productos de inventario con datos aleatorios.
        /// </summary>
        /// <param name="cantidad">El número de productos a generar.</param>
        /// <returns>Una lista de productos.</returns>
        public static List<Producto> GeneradorInventario(int cantidad)
        {
            Console.WriteLine("Generando productos en memoria...");
            var productos = new List<Producto>(cantidad);

            for (int i = 0; i < cantidad; i++)
            {
                var tipo = TiposProducto[random.Next(TiposProducto.Length)];
                var marca = Marcas[random.Next(Marcas.Length)];
                var modelo = Modelos[random.Next(Modelos.Length)];
                var sufijo = Sufijos[random.Next(Sufijos.Length)];

                productos.Add(new Producto
                {
                    Id = i + 1,
                    Nombre = $"{marca} {tipo} {modelo} {sufijo}",
                    Categoria = tipo, // Asignar la categoría
                    Marca = $"{marca} {tipo} {modelo} {sufijo}", // Para mantener la granularidad de las estadísticas
                    // Generar un precio decimal entre 100.00 y 1100.00
                    Precio = (decimal)(random.NextDouble() * 1000 + 100) 
                });
            }
            return productos;
        }
    }
}
