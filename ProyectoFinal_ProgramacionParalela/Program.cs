
using ProyectoFinal_ProgramacionParalela.Core.Analisis;
using ProyectoFinal_ProgramacionParalela.Core.Lectura;
using ProyectoFinal_ProgramacionParalela.Data;
using ProyectoFinal_ProgramacionParalela.Models;
using System.Diagnostics;
using System.IO; // Necesario para buscar archivos

class Program
{
    static void Main(string[] args)
    {
        int numProcesadores = Environment.ProcessorCount;
        Console.WriteLine($"Núcleos lógicos detectados: {numProcesadores}");

        List<Producto> datos = new List<Producto>();
        string opcion = "";
        while (opcion != "1" && opcion != "2")
        {
            Console.WriteLine("\n¿Cómo desea obtener los datos?");
            Console.WriteLine("1. Generar datos aleatoriamente");
            Console.WriteLine("2. Leer desde un archivo CSV");
            Console.Write("Seleccione una opción (1 o 2): ");
            opcion = Console.ReadLine() ?? "";
        }

        if (opcion == "1")
        {
            int cantidadProductos = 0;
            while (cantidadProductos <= 0)
            {
                Console.Write("\nIngrese la cantidad de productos a generar (ej: 5000000): ");
                if (!int.TryParse(Console.ReadLine(), out cantidadProductos) || cantidadProductos <= 0)
                {
                    Console.WriteLine("Entrada no válida.");
                    cantidadProductos = 0;
                }
            }
            Console.WriteLine($"\nGenerando {cantidadProductos:N0} productos...");
            datos = GeneradorDatos.GeneradorInventario(cantidadProductos);
            Console.WriteLine("Datos generados.");
        }
        else // opcion == "2"
        {
            string? rutaArchivo = null;
            var archivosCsv = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv")
                                     .Select(Path.GetFileName)
                                     .Where(f => f != null).Select(f => f!).ToList();

            if (archivosCsv.Any())
            {
                Console.WriteLine("\nSe encontraron los siguientes archivos CSV:");
                for (int i = 0; i < archivosCsv.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {archivosCsv[i]}");
                }

                bool seleccionValida = false;
                while(!seleccionValida)
                {
                    Console.Write("\nSeleccione un archivo por su número o ingrese una ruta manualmente: ");
                    string seleccion = Console.ReadLine() ?? "";

                    if (int.TryParse(seleccion, out int indice) && indice > 0 && indice <= archivosCsv.Count)
                    {
                        rutaArchivo = archivosCsv[indice - 1];
                        seleccionValida = true;
                    }
                    else if (!string.IsNullOrWhiteSpace(seleccion))
                    {
                        rutaArchivo = seleccion;
                        seleccionValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Selección no válida. Por favor, intente de nuevo.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNo se encontraron archivos CSV en el directorio del proyecto.");
                while (string.IsNullOrWhiteSpace(rutaArchivo))
                {
                    Console.Write("Por favor, ingrese la ruta completa del archivo CSV: ");
                    rutaArchivo = Console.ReadLine() ?? "";
                }
            }

            Console.WriteLine($"\nLeyendo datos desde '{rutaArchivo}'...");
            datos = LectorCSV.LeerProductos(rutaArchivo!);
            Console.WriteLine($"Se cargaron {datos.Count:N0} productos.");
        }

        if (!datos.Any())
        {
            Console.WriteLine("No hay datos para analizar. El programa finalizará.");
            return;
        }

        var datosParaAnalisis = datos.ToArray();

        Console.WriteLine("\n--- INICIANDO ANÁLISIS BIG DATA ---\n");
        Stopwatch sw = new Stopwatch();
        sw.Start();

        Console.WriteLine("[Análisis] Buscando producto más caro y más barato...");
        var (masBarato, masCaro) = AnalizadorBigData.BuscarExtremos(datosParaAnalisis);

        if (masBarato != null && masCaro != null)
        {
            Console.WriteLine($"Producto más barato: {masBarato.Nombre} ({masBarato.Precio:C2})");
            Console.WriteLine($"Producto más caro: {masCaro.Nombre} ({masCaro.Precio:C2})\n");
        }

        Console.WriteLine("[Análisis] Calculando estadísticas por marca...");
        var estadisticas = AnalizadorBigData.EstadisticasPorMarca(datosParaAnalisis);

        if (estadisticas.Any())
        {
            Console.WriteLine("\n--- Estadísticas por Marca (Paralelo con PLINQ) ---");
            foreach (var stat in estadisticas)
            {
                Console.WriteLine($"Marca: {stat.Marca.PadRight(35)} | Count: {stat.Conteo,8:N0} | Promedio: {stat.PromedioPrecio,10:C2}");
            }
        }

        sw.Stop();
        Console.WriteLine($"\nTiempo Total del Análisis: {sw.ElapsedMilliseconds:N0} ms");
    }
}
