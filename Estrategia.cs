using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Trabajo_Practico_Integrador
{
public class Estrategia
{

  //Base
private List<Dato> listaDatos = new List<Dato>();//Lista auxiliar, mejor dicho una lista temporal

//Constructor
public Estrategia()
{
}

//METODOS
/*1. BuscarConHeap(List<string> datos, int cantidad, List<Dato> collected): Retorna en la
variable collected los primeros elementos con mayor número de ocurrencias de la lista datos
utilizando una Heap como estructura de datos soporte. El número de elementos a retornar es
indicado por el parámetro cantidad.*/

public void BuscarConHeap( List<string> datos, int cantidad, List<Dato> collected)
{
listaDatos.Clear();
collected.Clear();//Para no acomular datos viejos

foreach ( string texto in datos )
{
bool encontrado = false;
  
if ( texto != "" )
{
//Contar cantidad de cada uno
foreach ( Dato a in listaDatos)
{

if ( a.Texto == texto )
{
a.Ocurrencias++;
encontrado = true;
break;
}
}

if ( !encontrado)
{
listaDatos.Add(new Dato(1, texto));
}
}
}

//Creacion de HEAP

Heap heap = new Heap(true);//MAX HEAP

foreach ( Dato a in listaDatos )
{
heap.agregar(a);//Ordena automatiamente heap
}

if ( cantidad <= 0 )
{
return;
}

listaDatos.Clear();

for ( int i = 0; i< cantidad; i++ )
{
if ( ! heap.esVacia() )
{
collected.Add(heap.eliminar());
}
}
}

/*2. BuscarConOrden(List<string> datos, int cantidad, List<Dato> collected): Tiene la misma
funcionalidad del método BuscarConHeap() pero debe implementarse utilizando un método
ordenamiento de los vistos en clase el que sea de su preferencia.*/

//Ordenamiento: heap sort

public void BuscarConOrden( List<string> datos, int cantidad, List<Dato> collected)
{
listaDatos.Clear();
collected.Clear();

foreach ( string texto in datos )
{
bool encontrado = false;
  
if ( texto != "" )
{
//Contar cantidad de cada uno
foreach ( Dato a in listaDatos)
{

if ( a.Texto == texto )
{
a.Ocurrencias++;
encontrado = true;
break;
}
}

if ( !encontrado)
{
listaDatos.Add(new Dato(1, texto));
}
}
}
  
//Creacion de HEAP

Heap heap = new Heap(true);//MAX HEAP

foreach ( Dato a in listaDatos )
{
heap.agregar(a);//Ordena automatiamente heap
}

if ( cantidad <= 0 )
{
return;
}

listaDatos.Clear();

//Lista auxiliar
List<Dato> ordenados = new List<Dato>();

while ( !heap.esVacia() )
{
ordenados.Add(heap.eliminar());//Lo saca y lo ordena de mayor a menor
}

//Aca es donde cambia la estructura ya que extrae los primeros mas grandes
for ( int i = 0; i < cantidad && i < ordenados.Count; i++ )
{
collected.Add(ordenados[i]);
}
}
  
/*3. Consulta1 (List<string> datos): Retorna un texto con los tiempos que insumen los
métodos BuscarConHeap() y BuscarConOrden() en realizar la búsqueda de los 5 elementos de
con mayor cantidad de ocurrencias.*/

public string Consulta1 ( List<string> datos) //No vodi porque va a retornar
{
List<Dato> c1 = new List<Dato>();//En lugar de instanciar objeto
Stopwatch reloj1 = new Stopwatch();
reloj1.Start();
BuscarConHeap(datos, 5, c1);
reloj1.Stop();
List<Dato> c2 = new List<Dato>();
Stopwatch reloj2 = new Stopwatch();
reloj2.Start();
BuscarConOrden(datos, 5, c2);
reloj2.Stop();

return "Heap: "+ reloj1.ElapsedMilliseconds + " ms, Orden: "+ reloj2.ElapsedMilliseconds + " ms";
}

/*4. Consulta2 (List<string> datos): Retorna un texto con el camino a la hoja más izquierda
de la Heap que se construye a partir de los datos de entrada cuando se utiliza el método
BuscarConHeap().*/

public string Consulta2 ( List<string> datos)
{
listaDatos.Clear();

foreach ( string texto in datos )
{
bool encontrado = false;

if ( texto != "" )
{
//Contar cantidad de cada uno
foreach ( Dato a in listaDatos)
{
if ( a.Texto == texto )
{
a.Ocurrencias++;
encontrado = true;
break;
}
}
if ( !encontrado)
{
listaDatos.Add(new Dato(1, texto));
}
}
}
  
//Creacion de HEAP
Heap heap = new Heap(true);//MAX HEAP

foreach ( Dato a in listaDatos )
{
heap.agregar(a);//Ordena automatiamente heap
}

listaDatos.Clear();

//PARTE nueva
int indice = 0;

string resultado = "";

while ( indice < heap.getElementos().Count )
{
resultado += heap.getElementos()[indice].ToString() + "\n";
indice = (2*indice)+1;//Recorrer por izquierda es
}

return resultado;
}

/*5. Consulta3 (List<string> datos): Retorna un texto que contiene los datos de la Heap que
se construye a partir de los datos de entrada cuando se utiliza el método BuscarConHeap(),
explicitando en el texto resultado los niveles en los que se encuentran ubicados cada uno de
los datos.*/

public string Consulta3 ( List<string> datos)
{
listaDatos.Clear();

foreach ( string texto in datos )
{
bool encontrado = false;

if ( texto != "" )
{
//Contar cantidad de cada uno
foreach ( Dato a in listaDatos)
{
if ( a.Texto == texto )
{
a.Ocurrencias++;
encontrado = true;
break;
}
}
if ( !encontrado)
{
listaDatos.Add(new Dato(1, texto));
}
}
}
  
//Creacion de HEAP
Heap heap = new Heap(true);//MAX HEAP

foreach ( Dato a in listaDatos )
{
heap.agregar(a);//Ordena automatiamente heap
}

listaDatos.Clear();
//Parte Nueva
string resultado = "";

for ( int i = 0; i< heap.getElementos().Count ; i++ )
{//Recorrer por izquierda es
int Nivel = (int)Math.Floor(Math.Log(i + 1, 2));//El 2 es para que me devuelva de base el log2
resultado += "Nivel: "+ Nivel +", Nodo: "+ heap.getElementos()[i].ToString() +"\n"; // el \n es para salto de linea
}

return resultado;
}
}
}
