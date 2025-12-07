using ProyectoFinal_ProgramacionParalela.Core.Analisis;
using ProyectoFinal_ProgramacionParalela.Core.Ordenamiento;
using ProyectoFinal_ProgramacionParalela.Data;
using ProyectoFinal_ProgramacionParalela.Models;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {

        // Configurar procesos
        int numProcesadores = Environment.ProcessorCount;
        Console.WriteLine($"Núcleos lógicos detectados: {numProcesadores} ");

        // 1. Generar Datos (Simular 5 Millones)

        // Nota: Baja este número si te da OutOfMemoryException en tu laptop
        var datos = GeneradorDatos.GeneradorInventario(5_000_000);

        // Clonar array para que la comparativa sea justa (uno para sec, uno para par)
        var datosParaSecuencial = (Producto[])datos.Clone();
        var datosParaParalelo = (Producto[])datos.Clone();

        Console.WriteLine("\n--- INICIANDO BENCHMARK ---");
        Stopwatch sw = new Stopwatch();

        // PRUEBA 1: Ordenamiento Secuencial (Linea base)
        sw.Start();
        Array.Sort(datosParaSecuencial, (x, y) => x.Precio.CompareTo(y.Precio));
        sw.Stop();
        long tiempoSecuencial = sw.ElapsedMilliseconds;
        Console.WriteLine($"Ordenamiento Secuencial: {tiempoSecuencial} ms");

        // PRUEBA 2: Ordenamiento Paralelo (Merge Sort)

        sw.Restart();
        MergeSortParalelo.MergeSort(datosParaParalelo);
        sw.Stop();
        long tiempoParalelo = sw.ElapsedMilliseconds;
        Console.WriteLine($"Ordenamiento Paralelo:   {tiempoParalelo} ms");

        // Calculo de Speedup 
        double speedup = (double)tiempoSecuencial / tiempoParalelo;
        Console.WriteLine($"Speedup (Aceleración):   {speedup:F2}x veces más rápido");

        // PRUEBA 3: Nuevos Requerimientos Analisis
        Console.WriteLine("\n--- Ejecutando Análisis Paralelo ---");
        sw.Restart();
        AnalizadorBigData.BuscarExtremos(datosParaParalelo);
        AnalizadorBigData.EstadisticasPorMarca(datosParaParalelo);
        sw.Stop();
        Console.WriteLine($"Tiempo de Análisis Total: {sw.ElapsedMilliseconds} ms");
    }
}