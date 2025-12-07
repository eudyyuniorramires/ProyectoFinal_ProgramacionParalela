using ProyectoFinal_ProgramacionParalela.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ProgramacionParalela.Core.Analisis
{
    public static class AnalizadorBigData
    {

        public static void BuscarExtremos(Producto[] productos) 
        {
        
            var min = productos.AsParallel().OrderBy(p => p.Precio).FirstOrDefault();
            var max = productos.AsParallel().OrderByDescending(p => p.Precio).FirstOrDefault();

            Console.WriteLine($"[Busqueda...] Mas barata: {min.Nombre} ({min.Precio})");
            Console.WriteLine($"[Busqueda...] Mas Caros: {max.Nombre} ({max.Precio})");

        }

        public static void EstadisticasPorMarca(Producto[] productos)
        {
            var statsGlobales = new ConcurrentDictionary<string, (double Suma, int Conteo)>();

            Parallel.ForEach(
                productos,
                () => new Dictionary<string, (double Suma, int Conteo)>(),
                (prod, state, localDict) => 
                {
                    if (!localDict.ContainsKey(prod.Marca))
                        localDict[prod.Marca] = (0, 0);

                    var actual = localDict[prod.Marca];
                    localDict[prod.Marca] = (actual.Suma + prod.Precio, actual.Conteo + 1);
                    return localDict;
                },
                (localDict) =>
                {
                    foreach (var kvp in localDict)
                    {
                        statsGlobales.AddOrUpdate(kvp.Key, kvp.Value,
                            (k, val) => (val.Suma + kvp.Value.Suma, val.Conteo + kvp.Value.Conteo));
                    }
                }
            );

            Console.WriteLine("\n--- Estadisticas por Marca (Paralelo) ---");
            foreach (var kvp in statsGlobales)
            {
                Console.WriteLine($"Marca: {kvp.Key.PadRight(10)} | Count: {kvp.Value.Conteo} | Promedio: {kvp.Value.Suma / kvp.Value.Conteo:C2}");
            }
        }
    }


}

