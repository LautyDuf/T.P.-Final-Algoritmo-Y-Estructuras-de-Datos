using System;
using System.Collections.Generic;

namespace tpfinal
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("       Trabajo Practico Integrador - AED");
            Console.WriteLine("\n");

            // 1. Cargamos datos de prueba directamente en código (Mock Data)
            // Estariamos esperando: Manzana (5), Banana (4), Pera (3), Naranja (2), Uva (1)
            List<string> datosPrueba = new List<string>()
            {
                "Manzana", "Banana", "Pera", "Manzana", "Manzana",
                "Banana", "Uva", "Naranja", "Manzana", "Pera",
                "Banana", "Manzana", "Banana", "Naranja", "Pera"
            };

            Console.WriteLine(">> Datos cargados exitosamente (" + datosPrueba.Count + " registros).\n");

            Estrategia estrategia = new Estrategia();
            List<Dato> resultados = new List<Dato>();

            // --- PRUEBA DE HEAP ---
            Console.WriteLine("--- 1. BuscarConHeap (Top 3) ---");
            estrategia.BuscarConHeap(datosPrueba, 3, resultados);
            foreach (Dato d in resultados)
            {
                Console.WriteLine(d.ToString());
            }

            // --- PRUEBA DE ORDENAMIENTO (BURBUJA) ---
            Console.WriteLine("\n--- 2. BuscarConOtro (Top 3) ---");
            estrategia.BuscarConOtro(datosPrueba, 3, resultados);
            foreach (Dato d in resultados)
            {
                Console.WriteLine(d.ToString());
            }

            // --- PRUEBA DE CONSULTA 1 (TIEMPOS) ---
            Console.WriteLine("\n--- 3. Consulta 1 (Tiempos) ---");
            Console.WriteLine(estrategia.Consulta1(datosPrueba));

            // --- PRUEBA DE CONSULTA 2 (CAMINO IZQUIERDO) ---
            Console.WriteLine("\n--- 4. Consulta 2 (Camino Izquierdo del Heap) ---");
            Console.WriteLine(estrategia.Consulta2(datosPrueba));

            // --- PRUEBA DE CONSULTA 3 (NIVELES) ---
            Console.WriteLine("\n--- 5. Consulta 3 (Niveles del Árbol) ---");
            Console.WriteLine(estrategia.Consulta3(datosPrueba));

            Console.Write("Presiona cualquier tecla para salir . . . ");
            Console.ReadKey(true);
        }
    }
}
