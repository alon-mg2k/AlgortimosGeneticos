using System;
using System.Collections.Generic;
using System.Text;

namespace SistadaEvidenciaAG
{
    class Mutacion
    {
        public static Mutacion prob_mutation = new Mutacion();
        public Double[,] ProbabilidadMutacion() {
            Console.WriteLine("_________________________________________\n");
            Console.WriteLine("---- PROBABILIDAD DE MUTACIÓN ----");
            Console.WriteLine("_________________________________________\n");

            Random rd = new Random();
            
            Double[,] MatrizMutacion = new double[2, 10];

            for (int i = 0; i < 2; i++){ 
                for (int j = 9; j >=0 ; j--) {
                    MatrizMutacion[i, j] = Math.Round(rd.NextDouble(),2);
                    Console.Write(MatrizMutacion[i, j] + " ");
                }
                Console.Write("\n");
            }
            return MatrizMutacion;
        }
        public int[,] MutacionPareja(Double[,] matrizProbabilidad, int[,]matrizMutada) {
            Console.WriteLine("_________________________________________\n");
            Console.WriteLine("---- PAREJA DE CROMOSOMAS MUTADA ----");
            Console.WriteLine("_________________________________________\n");
            Double probMutacion = 0.1;
            for (int i = 0; i < 2; i++) {
                for (int j = 9; j >= 0; j--) {
                    if (matrizProbabilidad[i, j] < probMutacion)
                    {
                        if (matrizMutada[i, j] == 0) { matrizMutada[i, j] = 1; Console.Write(matrizMutada[i, j] + " ");  }
                        else if (matrizMutada[i, j] == 1) { matrizMutada[i, j] = 0; Console.Write(matrizMutada[i, j] + " ");  }
                    }
                    else { Console.Write(matrizMutada[i, j] + " "); };
                }
                Console.WriteLine("");
            }
            return matrizMutada;
        }
    }
}
