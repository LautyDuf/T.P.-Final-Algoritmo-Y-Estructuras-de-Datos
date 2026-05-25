using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Trabajo_Practico_Integrador
{
public class Heap
{
private List<Dato> elementos;
private bool esMaxHeap;
  
public Heap(bool esMaxHeap)
{
this.elementos = new List<Dato>();
this.esMaxHeap = esMaxHeap;
}

public bool esVacia()
{
return elementos.Count == 0;
}

public Dato tope()
{
if (esVacia()) return null;
return elementos[0];
}

public bool agregar(Dato elem)
{
if (elem == null) return false;
elementos.Add(elem);
heapifyUp(elementos.Count - 1);
return true;
}

public Dato eliminar()
{
if (esVacia()) return null;
Dato eliminado = elementos[0];
int ultimo = elementos.Count - 1;
elementos[0] = elementos[ultimo];
elementos.RemoveAt(ultimo);
  
if (!esVacia())
heapifyDown(0);
return eliminado;
}
  
//HEAPIFY UP
private void heapifyUp(int indice)
{
while (indice > 0)
{
int padre = (indice - 1) / 2;
bool condicion;

  if (esMaxHeap)
condicion = elementos[indice].Ocurrencias > elementos[padre].Ocurrencias;

  else
condicion = elementos[indice].Ocurrencias < elementos[padre].Ocurrencias;
  
if (!condicion) break;
swap(indice, padre);
indice = padre;
}
}

//HEAPIFY DOWN
private void heapifyDown(int indice)
{
int n = elementos.Count;
while (true)
{
int hijoIzq = 2 * indice + 1;
int hijoDer = 2 * indice + 2;
int candidato = indice;

//HIJO IZQUIERDO
if (hijoIzq < n)
{
if (esMaxHeap)
{
if (elementos[hijoIzq].Ocurrencias > elementos[candidato].Ocurrencias)
candidato = hijoIzq;
}
  
else
{
if (elementos[hijoIzq].Ocurrencias < elementos[candidato].Ocurrencias)
candidato = hijoIzq;
}
}

//HIJO DERECHO

if (hijoDer < n)
{
if (esMaxHeap)
{
if (elementos[hijoDer].Ocurrencias > elementos[candidato].Ocurrencias)
candidato = hijoDer;
}
else
{
if (elementos[hijoDer].Ocurrencias < elementos[candidato].Ocurrencias)
candidato = hijoDer;
}
}
if (candidato == indice)
break;
swap(indice, candidato);
indice = candidato;
}
}

private void swap(int i, int j)
{
Dato aux = elementos[i];
elementos[i] = elementos[j];
elementos[j] = aux;
}

public List<Dato> getElementos()
{
return elementos;
}
}
}
