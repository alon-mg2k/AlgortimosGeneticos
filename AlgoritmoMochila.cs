using System;

namespace SistadaEvidenciaAG
{
    class AlgoritmoMochila
    {
        public static AlgoritmoMochila AG = new AlgoritmoMochila();
        public Random rd = new Random();
        public static int[] listaAptitud = new int[10];

        public int[] RandPobGenerator()
        {
            int[] RAND_POB_INT = new int[10];
            for (int i = 0; i < RAND_POB_INT.Length; i++)
            {
                RAND_POB_INT[i] = rd.Next(220);
            }
            return RAND_POB_INT;
        }

        public int[,] CromosomeConstructor()
        {
            int[] RAND_POB_INT = RandPobGenerator();
            int[,] RAND_POB_BINARY = new int[10, 10];

            Console.WriteLine("_________________________________________\n");
            Console.WriteLine("---- CREACIÓN DE POBLACIÓN INICIAL ----");
            Console.WriteLine("_________________________________________\n");
            
            for (int i = 0; i < RAND_POB_INT.Length; i++) {
                Console.Write(RAND_POB_INT[i]+ " ");

                for (int j = 0; j < RAND_POB_INT.Length; j++) {
                    RAND_POB_BINARY[i, j] = RAND_POB_INT[i] % 2;
                    RAND_POB_INT[i] = RAND_POB_INT[i] / 2;
                }

                for (int j = RAND_POB_INT.Length - 1; j >= 0; j--) {
                    Console.Write(RAND_POB_BINARY[i, j] + " ");
                }

                Console.Write("\n");
            }
            return RAND_POB_BINARY;
        }

        static void ModuloEvaluacion(int[,] Cromosomas, int[] listaPesos) {       
            Evaluacion.EV.MetodoEvaluacion(Cromosomas);
            
        }

        public static void Main(String[] args)
        {           
            int[,] Cromosomas = AG.CromosomeConstructor();
            ModuloEvaluacion(Cromosomas,listaAptitud);
            
        }
    }
}
