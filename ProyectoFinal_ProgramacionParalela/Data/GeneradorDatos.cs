using ProyectoFinal_ProgramacionParalela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ProgramacionParalela.Data
{

   
    public static class GeneradorDatos
    {

       
        private static readonly string[] Marcas = { "Samsung", "Apple", "Sony", "LG", "Dell", "HP", "Asus", "Lenovo", "Xiaomi" };
        private static readonly string[] Tipos = { "Laptop", "Smartphone", "TV 4K", "Monitor", "Tablet", "Auriculares", "Cámara", "Reloj" };
        private static readonly string[] Sufijos = { "Pro", "Ultra", "Lite", "Max", "Air", "Gaming", "Office", "X", "S" };
        private static readonly string[] Versiones = { "2024", "2025", "v2", "Series 5", "X1", "G5" };

        public static Producto[] GeneradorInventario(int cantidad) 
        {
            Console.WriteLine($"Generando {cantidad:NO} productos en memoria...");
            var random = new Random();
            var invetario = new Producto[cantidad];


            Parallel.For(0, cantidad, i => {

                int marcaIndex = (i + random.Next(0,10)) % Marcas.Length;
                int tipoIndex = (i + random.Next(0,10)) % Tipos.Length;
                int sufijoIndex = random.Next(0, Sufijos.Length);
                int versionIndex = random.Next(0, Versiones.Length);

                string MarcaElegida = Marcas[marcaIndex];

                string nombreGenerado = $"{Marcas[marcaIndex]} {Tipos[tipoIndex]} {Sufijos[sufijoIndex]} {Versiones[versionIndex]}";

                invetario[i] = new Producto
                {
                    Id = i+1000,
                    Nombre = MarcaElegida,
                    Marca = nombreGenerado,
                    Precio = Math.Round(random.NextDouble() * 1000 + 100, 2)

                };
            
           
            });

            return invetario;
        
        }
    }
}
