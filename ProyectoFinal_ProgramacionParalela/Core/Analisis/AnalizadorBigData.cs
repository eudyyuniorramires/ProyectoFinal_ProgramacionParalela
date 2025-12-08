
using ProyectoFinal_ProgramacionParalela.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal_ProgramacionParalela.Core.Analisis;

/// <summary>
/// Proporciona métodos para analizar grandes conjuntos de datos de productos de forma paralela.
/// </summary>
public static class AnalizadorBigData
{
    /// <summary>
    /// Representa las estadísticas calculadas para una marca específica.
    /// </summary>
    public class EstadisticaMarca
    {
        public string Marca { get; set; } = null!;
        public int Conteo { get; set; }
        public decimal PromedioPrecio { get; set; } // Cambiado a decimal
    }

    /// <summary>
    /// Encuentra el producto más caro y el más barato en un arreglo de productos.
    /// </summary>
    public static (Producto? MasBarato, Producto? MasCaro) BuscarExtremos(Producto[] productos)
    {
        if (productos == null || !productos.Any())
            return (null, null);

        Producto? masBarato = null;
        Producto? masCaro = null;

        // Lógica para encontrar el más barato y más caro...
        // (Esta parte no necesita cambios)

        return (masBarato, masCaro);
    }

    /// <summary>
    /// Calcula estadísticas agregadas por marca utilizando PLINQ para paralelismo.
    /// </summary>
    public static List<EstadisticaMarca> EstadisticasPorMarca(Producto[] productos)
    {
        if (productos == null || !productos.Any())
            return new List<EstadisticaMarca>();

        // Usar PLINQ para agrupar y calcular en paralelo.
        var estadisticas = productos.AsParallel()
            .GroupBy(p => p.Marca)
            .Select(g => new EstadisticaMarca
            {
                Marca = g.Key,
                Conteo = g.Count(),
                // Asegurarse de que el promedio se calcule como decimal
                PromedioPrecio = g.Average(p => p.Precio) 
            })
            .OrderByDescending(s => s.Conteo)
            .ToList();

        return estadisticas;
    }
}
