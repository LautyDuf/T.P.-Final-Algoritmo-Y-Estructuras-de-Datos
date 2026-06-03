using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace tpfinal
{
    public class Estrategia
    {
        private Heap ConstruirHeap(List<string> datos)
        {
            List<string> palabras = new List<string>();
            List<int> cantidad = new List<int>();

            int i, j;

            for (i = 0; i < datos.Count; i++)
            {
                string texto = datos[i];

                if (texto == "")
                    continue;

                bool existe = false;

                for (j = 0; j < palabras.Count; j++)
                {
                    if (palabras[j] == texto)
                    {
                        cantidad[j]++;
                        existe = true;
                    }
                }

                if (existe == false)
                {
                    palabras.Add(texto);
                    cantidad.Add(1);
                }
            }

            Heap heap = new Heap(true);

            for (i = 0; i < palabras.Count; i++)
            {
                Dato d = new Dato(cantidad[i], palabras[i]);
                heap.agregar(d);
            }

            return heap;
        }

        // 1. HEAP
        public void BuscarConHeap(List<string> datos, int cantidad, List<Dato> collected)
        {
            collected.Clear();

            if (cantidad <= 0)
                return;

            Heap heap = ConstruirHeap(datos);

            int i;
            for (i = 0; i < cantidad && !heap.esVacia(); i++)
            {
                collected.Add(heap.eliminar());
            }
        }

        // 2. ORDENAMIENTO BURBUJA
        public void BuscarConOrden(List<string> datos, int cantidad, List<Dato> collected)
        {
            collected.Clear();

            if (cantidad <= 0)
                return;

            Heap heap = ConstruirHeap(datos);

            List<Dato> lista = new List<Dato>();

            while (!heap.esVacia())
            {
                lista.Add(heap.eliminar());
            }

            int i, j;

            for (i = 0; i < lista.Count - 1; i++)
            {
                for (j = 0; j < lista.Count - i - 1; j++)
                {
                    if (lista[j].ocurrencia < lista[j + 1].ocurrencia)
                    {
                        Dato aux = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = aux;
                    }
                }
            }

            for (i = 0; i < cantidad && i < lista.Count; i++)
            {
                collected.Add(lista[i]);
            }
        }

        // 3. TIEMPOS
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

        // 4. CAMINO IZQUIERDO
        public string Consulta2(List<string> datos)
        {
            Heap heap = ConstruirHeap(datos);
            List<Dato> arr = heap.GetElementos();

            string resultado = "";
            int i = 0;

            while (i < arr.Count)
            {
                resultado = resultado + arr[i].ToString() + "\n";
                i = 2 * i + 1;
            }

            return resultado;
        }

        // 5. NIVELES
        public string Consulta3(List<string> datos)
        {
            Heap heap = ConstruirHeap(datos);

            string resultado = "";
            int i;

            for (i = 0; i < heap.GetElementos().Count; i++)
            {
                int nivel = (int)Math.Log(i + 1, 2);

                resultado = resultado + "Nivel " + nivel + " -> " +
                            heap.GetElementos()[i] + "\n";
            }

            return resultado;
        }
    }
}
