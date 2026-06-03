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

            List<string> datosPrueba = new List<string>()
            {
                "Manzana", "Banana", "Pera", "Manzana", "Manzana",
                "Banana", "Uva", "Naranja", "Manzana", "Pera",
                "Banana", "Manzana", "Banana", "Naranja", "Pera"
            };

            Console.WriteLine(">> Datos de prueba cargados exitosamente.\n");

            Estrategia estrategia = new Estrategia();
            List<Dato> resultados = new List<Dato>();

            Console.WriteLine("--- 1. BuscarConHeap (Top 3) ---");
            estrategia.BuscarConHeap(datosPrueba, 3, resultados);
            foreach (Dato d in resultados) Console.WriteLine(d.ToString());

            Console.WriteLine("\n--- 2. BuscarConOrden (Top 3) ---");
            estrategia.BuscarConOrden(datosPrueba, 3, resultados);
            foreach (Dato d in resultados) Console.WriteLine(d.ToString());

            Console.WriteLine("\n--- 3. Consulta 1 (Tiempos) ---");
            Console.WriteLine(estrategia.Consulta1(datosPrueba));

            Console.WriteLine("\n--- 4. Consulta 2 (Camino Izquierdo) ---");
            Console.WriteLine(estrategia.Consulta2(datosPrueba));

            Console.WriteLine("\n--- 5. Consulta 3 (Niveles) ---");
            Console.WriteLine(estrategia.Consulta3(datosPrueba));

            Console.Write("\nPresiona cualquier tecla para salir . . . ");
            Console.ReadKey(true);
        }
    }
}
}
