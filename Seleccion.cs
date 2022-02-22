using System;
using System.Collections.Generic;
using System.Text;

namespace SistadaEvidenciaAG
{
    class Seleccion
    {
        public static Seleccion SEL = new Seleccion();
        public void Probabilidad(int[] cromosomas_aptitud, float[] arreglo_probabilidad, float sumatoriaPorcentaje, int totalGananciaAptitud)
        {
            Console.WriteLine("_________________________________________\n");
            Console.WriteLine("---- PROBABILIDAD ----");
            Console.WriteLine("_________________________________________\n");

            for (int i = 0; i < cromosomas_aptitud.Length; i++)
            {
                arreglo_probabilidad[i] = (float)cromosomas_aptitud[i] / totalGananciaAptitud;
                sumatoriaPorcentaje += arreglo_probabilidad[i];
                //Console.WriteLine(i + "    " + (float)sumatoriaPorcentaje + "     %" +(float) sumatoriaPorcentaje*100);
                Console.WriteLine("PROB" + i + ": " + arreglo_probabilidad[i] * 100 + "% " + "    " + (float)sumatoriaPorcentaje + "     %" + (float)sumatoriaPorcentaje * 100);
            }
        }

        public int[,] GenerarParejasAleatorias(int[,] RAND_POB_BINARY)
        {
            Random rd = new Random();
            int pareja1 = 0, pareja2 = 0;
            while (pareja1 == pareja2)
            {
                pareja1 = rd.Next(10);
                pareja2 = rd.Next(10);
            }

            int posicionAleatoria = 10-rd.Next(10);

            int[,] ParejaCromosoma = new int[2, 10];
            Console.WriteLine("_________________________________________\n");
            Console.WriteLine("---- PAREJA DE CROMOSOMA ALEATORIA ----");
            Console.WriteLine("INDICE DE CROMOSOMA 1: " + (pareja1+1));
            Console.WriteLine("INDICE DE CROMOSOMA 2: " + (pareja2+1));
            Console.WriteLine("GEN DE CRUCE (DERECHA A IZQUIERDA): " + posicionAleatoria);
            Console.WriteLine("_________________________________________\n");

            for (int i = 0; i < 2; i++) { 
                for (int j = 9; j >= 0; j--)
                {
                    if (i == 0) { Console.Write(RAND_POB_BINARY[pareja1, j] + " "); }
                    if (i == 1) { Console.Write(RAND_POB_BINARY[pareja2, j] + " "); }
                }
                Console.Write("\n");
            }
            Console.Write("\n");
            for (int i = 0; i < 2; i++) {
                for (int j = 9; j >= 0; j--) {
                    if (i == 0) {
                        if (j >= posicionAleatoria) { ParejaCromosoma[i, j] = RAND_POB_BINARY[pareja1, j]; }
                        else { ParejaCromosoma[i, j] = RAND_POB_BINARY[pareja2, j]; }
                    }
                    if (i == 1){
                        if (j >= posicionAleatoria) { ParejaCromosoma[i, j] = RAND_POB_BINARY[pareja2, j]; }
                        else { ParejaCromosoma[i, j] = RAND_POB_BINARY[pareja1, j]; }
                    }
                    Console.Write(ParejaCromosoma[i, j] + " ");
                }
                Console.Write("\n");
            }
            return ParejaCromosoma;
        }

    }
}
