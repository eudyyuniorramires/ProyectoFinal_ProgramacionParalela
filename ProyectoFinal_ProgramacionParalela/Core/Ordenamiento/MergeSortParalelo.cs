using ProyectoFinal_ProgramacionParalela.Data;
using ProyectoFinal_ProgramacionParalela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ProgramacionParalela.Core.Ordenamiento
{
    public static class MergeSortParalelo
    {

        private const int UMBRAL_SECUENCIAL = 5000;


        public static void MergeSort(Producto[] arreglo) 
        {
            if (arreglo.Length <= 1) return;

            if (arreglo.Length < UMBRAL_SECUENCIAL) 
            {
                Array.Sort(arreglo, (x, y) => x.Precio.CompareTo(y.Precio));
                return;
            }

            int medio = arreglo.Length / 2;
            Producto[] izquierda = arreglo.Take(medio).ToArray();
            Producto[] derecha = arreglo.Skip(medio).ToArray();

            Parallel.Invoke(

                () => MergeSort(izquierda),
                () => MergeSort(derecha)

            );


            Mezclar(arreglo, izquierda, derecha);

        }


        private static void Mezclar(Producto[] resultado, Producto[] izq, Producto[] der) 
        {

            int i = 0, j = 0, k = 0;
            while (i < izq.Length && j < der.Length) 
            {

                if (izq[i].Precio < der[j].Precio)
                    resultado[k++] = izq[i++];
                else
                    resultado[k++] = der[j++];

            }

            while (i < izq.Length) resultado[k++] = izq[i++];
            while (j < der.Length) resultado[k++] = der[j++];




        }
    }
}
