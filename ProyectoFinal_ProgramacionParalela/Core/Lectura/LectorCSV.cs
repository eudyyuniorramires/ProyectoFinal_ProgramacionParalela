
using ProyectoFinal_ProgramacionParalela.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ProyectoFinal_ProgramacionParalela.Core.Lectura
{
    public static class LectorCSV
    {
        /// <summary>
        /// Lee productos desde un archivo CSV de forma paralela.
        /// </summary>
        /// <param name="rutaArchivo">La ruta completa del archivo CSV.</param>
        /// <returns>Una lista de productos leídos desde el archivo.</returns>
        public static List<Producto> LeerProductos(string rutaArchivo)
        {
            var productos = new List<Producto>();

            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine($"Error: El archivo '{rutaArchivo}' no fue encontrado.");
                return productos;
            }

            try
            {
                // Leer todas las líneas y saltar la cabecera (header)
                var lineas = File.ReadAllLines(rutaArchivo).Skip(1);

                // Usar PLINQ para procesar las líneas en paralelo para mayor eficiencia
                productos = lineas.AsParallel()
                    .Select(linea =>
                    {
                        var columnas = linea.Split(',');
                        if (columnas.Length >= 4)
                        {
                            try
                            {
                                // Crear un nuevo objeto Producto desde las columnas del CSV
                                return new Producto
                                {
                                    Nombre = columnas[0].Trim(),
                                    Categoria = columnas[1].Trim(),
                                    // Usar CultureInfo.InvariantCulture para asegurar que el punto '.' sea el separador decimal
                                    Precio = decimal.Parse(columnas[2].Trim(), CultureInfo.InvariantCulture),
                                    Marca = columnas[3].Trim()
                                };
                            }
                            catch (FormatException)
                            {
                                // Si una línea tiene un formato de número incorrecto, se ignora.
                                return null;
                            }
                        }
                        return null; // Ignorar líneas que no tengan suficientes columnas
                    })
                    .Where(p => p != null) // Filtrar los resultados nulos (líneas con errores)
                    .Select(p => p!)      // Asegurar al compilador que ya no hay nulos
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error inesperado al procesar el archivo CSV: {ex.Message}");
            }

            return productos;
        }
    }
}
