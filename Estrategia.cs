using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace tpfinal
{
    public class Estrategia
    {
        // Función auxiliar privada para recuento y armado del árbol
        private Heap ConstruirHeap(List<string> datos)
        {
            List<string> palabras = new List<string>();
            List<int> cantidad = new List<int>();

            for (int i = 0; i < datos.Count; i++)
            {
                string texto = datos[i];
                if (texto == "") continue;

                bool existe = false;
                for (int j = 0; j < palabras.Count; j++)
                {
                    if (palabras[j] == texto)
                    {
                        cantidad[j]++;
                        existe = true;
                        break;
                    }
                }

                if (!existe)
                {
                    palabras.Add(texto);
                    cantidad.Add(1);
                }
            }

            Heap heap = new Heap(true);
            for (int i = 0; i < palabras.Count; i++)
            {
                heap.agregar(new Dato(cantidad[i], palabras[i]));
            }

            return heap;
        }

        // 1. BUSCAR CON HEAP
        public void BuscarConHeap(List<string> datos, int cantidad, List<Dato> collected)
        {
            collected.Clear();
            if (cantidad <= 0) return;

            Heap heap = ConstruirHeap(datos);

            for (int i = 0; i < cantidad && !heap.esVacia(); i++)
            {
                collected.Add(heap.eliminar());
            }
        }

        // 2. BUSCAR CON ORDEN 
        public void BuscarConOrden(List<string> datos, int cantidad, List<Dato> collected)
        {
            collected.Clear();
            if (cantidad <= 0) return;

            List<Dato> lista = new List<Dato>();
            List<string> palabras = new List<string>();
            List<int> cantidades = new List<int>();

            // Conteo manual
            for (int i = 0; i < datos.Count; i++)
            {
                string txt = datos[i];
                if (txt == "") continue;

                bool existe = false;
                for (int j = 0; j < palabras.Count; j++)
                {
                    if (palabras[j] == txt)
                    {
                        cantidades[j]++;
                        existe = true;
                        break;
                    }
                }

                if (!existe)
                {
                    palabras.Add(txt);
                    cantidades.Add(1);
                }
            }

            for (int i = 0; i < palabras.Count; i++)
            {
                lista.Add(new Dato(cantidades[i], palabras[i]));
            }

            // Ordenamiento Burbuja (Mayor a Menor)
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = 0; j < lista.Count - i - 1; j++)
                {
                    if (lista[j].ocurrencia < lista[j + 1].ocurrencia)
                    {
                        Dato aux = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = aux;
                    }
                }
            }

            // Extracción
            for (int i = 0; i < cantidad && i < lista.Count; i++)
            {
                collected.Add(lista[i]);
            }
        }

        // 3. CONSULTA 1 (Tiempos)
        public string Consulta1(List<string> datos)
        {
            List<Dato> c1 = new List<Dato>();
            Stopwatch t1 = Stopwatch.StartNew();
            BuscarConHeap(datos, 5, c1);
            t1.Stop();

            List<Dato> c2 = new List<Dato>();
            Stopwatch t2 = Stopwatch.StartNew();
            BuscarConOrden(datos, 5, c2);
            t2.Stop();

            return "Heap: " + t1.ElapsedMilliseconds + " ms | Orden: " + t2.ElapsedMilliseconds + " ms";
        }

        // 4. CONSULTA 2 (Camino Izquierdo)
        public string Consulta2(List<string> datos)
        {
            Heap heap = ConstruirHeap(datos);
            List<Dato> arr = heap.GetElementos();

            string resultado = "";
            int i = 0;

            while (i < arr.Count)
            {
                resultado += arr[i].ToString() + "\n";
                i = 2 * i + 1;
            }

            return resultado;
        }

        // 5. CONSULTA 3 (Niveles)
        public string Consulta3(List<string> datos)
        {
            Heap heap = ConstruirHeap(datos);
            string resultado = "";

            for (int i = 0; i < heap.GetElementos().Count; i++)
            {
                int nivel = (int)Math.Log(i + 1, 2);
                resultado += "Nivel " + nivel + " -> " + heap.GetElementos()[i].ToString() + "\n";
            }

            return resultado;
        }
    }
}
