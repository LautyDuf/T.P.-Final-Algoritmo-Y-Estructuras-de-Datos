using System;
using System.Collections.Generic;

namespace tpfinal
{
    public class Heap
    {
        private List<Dato> elementos;
        private bool esMaxHeap;

        public Heap(bool esMaxHeap)
        {
            this.esMaxHeap = esMaxHeap;
            elementos = new List<Dato>();
        }

        public bool esVacia()
        {
            return elementos.Count == 0;
        }

        public Dato tope()
        {
            if (esVacia())
                return null;

            return elementos[0];
        }

        public bool agregar(Dato elem)
        {
            if (elem == null)
                return false;

            elementos.Add(elem);
            heapifyUp(elementos.Count - 1);
            return true;
        }

        public Dato eliminar()
        {
            if (esVacia())
                return null;

            Dato eliminado = elementos[0];

            int ultimo = elementos.Count - 1;
            elementos[0] = elementos[ultimo];
            elementos.RemoveAt(ultimo);

            if (!esVacia())
                heapifyDown(0);

            return eliminado;
        }

        private void heapifyUp(int i)
        {
            while (i > 0)
            {
                int padre = (i - 1) / 2;

                bool condicion = false;

                // Compara usando la variable 'ocurrencia' en minúscula
                if (esMaxHeap)
                {
                    if (elementos[i].ocurrencia > elementos[padre].ocurrencia)
                        condicion = true;
                }
                else
                {
                    if (elementos[i].ocurrencia < elementos[padre].ocurrencia)
                        condicion = true;
                }

                if (!condicion)
                    break;

                Dato aux = elementos[i];
                elementos[i] = elementos[padre];
                elementos[padre] = aux;

                i = padre;
            }
        }

        private void heapifyDown(int i)
        {
            int n = elementos.Count;

            while (true)
            {
                int izq = 2 * i + 1;
                int der = 2 * i + 2;
                int candidato = i;

                if (izq < n)
                {
                    if (elementos[izq].ocurrencia > elementos[candidato].ocurrencia)
                        candidato = izq;
                }

                if (der < n)
                {
                    if (elementos[der].ocurrencia > elementos[candidato].ocurrencia)
                        candidato = der;
                }

                if (candidato == i)
                    break;

                Dato aux = elementos[i];
                elementos[i] = elementos[candidato];
                elementos[candidato] = aux;

                i = candidato;
            }
        }

        public List<Dato> GetElementos()
        {
            return elementos;
        }
    }
}
