using System;
using System.Collections.Generic;
using System.Text;

namespace SistadaEvidenciaAG
{
    class Evaluacion
    {
        public static Evaluacion EV = new Evaluacion();
        public void MetodoEvaluacion(int[,] RAND_POB_BINARY) {
            float sumatoriaPorcentaje = 0;
            int[] arreglo_pesos = { 47, 43, 44, 35, 33, 36, 24, 49, 41, 29 };
            int[] arreglo_ganancia = { 67, 15, 33, 75, 81, 44, 17, 72, 91, 16 };
            int[] cromosomas_aptitud = new int[10];
            float[] arreglo_probabilidad = new float[10];
            int totalGananciaAptitud = AlgoritmoEvaluacion(10,arreglo_pesos,arreglo_ganancia,cromosomas_aptitud,RAND_POB_BINARY,arreglo_probabilidad);
            Seleccion.SEL.Probabilidad(cromosomas_aptitud, arreglo_probabilidad, sumatoriaPorcentaje, totalGananciaAptitud);
            ProcesarParejas(arreglo_pesos,arreglo_ganancia,cromosomas_aptitud,RAND_POB_BINARY,arreglo_probabilidad);
        }

        public int AlgoritmoEvaluacion(int lim_pesos, int[] arreglo_pesos, int[] arreglo_ganancia, 
            int[] cromosomas_aptitud, int[,]RAND_POB_BINARY, float[] arreglo_probabilidad)
        {
            Console.WriteLine("_________________________________________\n");
            Console.WriteLine("---- TABLA DE EVALUACIÓN (PESOS y APTITUD) ----");
            Console.WriteLine("     PC = PESO CROMOSOMAS");
            Console.WriteLine("     GC = GANANCIA CROMOSOMAS");
            Console.WriteLine("_________________________________________\n");

            int mayor = 0;
            int totalGananciaPeso = 0;
            int totalGananciaAptitud = 0;
            
            for (int i = 0; i < lim_pesos ; i++)
            {
                int valorGanancia = 0;
                int pesoTotal = 0;
                int gananciaTotal = 0;
                for (int j = arreglo_pesos.Length - 1; j >= 0; j--)
                {
                    Console.Write(RAND_POB_BINARY[i, j] + " ");
                }
                for (int j = 0; j < arreglo_pesos.Length; j++)
                {

                    int valorPeso = arreglo_pesos[j] * RAND_POB_BINARY[i, j];
                    valorGanancia = arreglo_ganancia[j] * RAND_POB_BINARY[i, j];

                    pesoTotal += valorPeso;
                    gananciaTotal += valorGanancia;

                    if (pesoTotal >= 220)
                    {
                        pesoTotal = 0;
                        gananciaTotal = 0;
                    }
                }
                cromosomas_aptitud[i] = gananciaTotal;
             
                if (cromosomas_aptitud[i] > mayor)
                {
                    mayor = cromosomas_aptitud[i];
                }

                Console.Write("     PC" + (i + 1) + ": " + pesoTotal + "  GC" + (i + 1) + ": " + gananciaTotal + "\n");
                totalGananciaPeso = totalGananciaPeso + pesoTotal;
                totalGananciaAptitud = totalGananciaAptitud + gananciaTotal;
            }
            Console.WriteLine("\nTOTAL DE PESOS: " + totalGananciaPeso);
            Console.WriteLine("TOTAL DE APTITUD O GANANCIA: " + totalGananciaAptitud);
            Console.WriteLine("CROMOSOMA MAYOR: " + mayor);
            return totalGananciaAptitud;
        }

        public void ProcesarParejas(int[] arreglo_pesos, int[] arreglo_ganancia,
            int[] cromosomas_aptitud, int[,] RAND_POB_BINARY, float[] arreglo_probabilidad) {
            for (int i = 0; i < 3; i++) {
                Console.WriteLine("\n");
                Console.WriteLine("_________________________________________\n");
                Console.WriteLine("---- PAREJA " + (i+1) + " ----");
                Console.WriteLine("_________________________________________\n");
                int[,] matrizParejas = Seleccion.SEL.GenerarParejasAleatorias(RAND_POB_BINARY);
                Double[,] matrizProbabilidad = Mutacion.prob_mutation.ProbabilidadMutacion();
                int[,] matrizParejaMutado = Mutacion.prob_mutation.MutacionPareja(matrizProbabilidad, matrizParejas);
                AlgoritmoEvaluacion(2, arreglo_pesos, arreglo_ganancia, cromosomas_aptitud, matrizParejaMutado, arreglo_probabilidad);
                Console.WriteLine("\n");
            }
        }

    }
}
