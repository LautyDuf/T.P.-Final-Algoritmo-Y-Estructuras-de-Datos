using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Trabajo_Practico_Integrador
{
public class Dato
{

public int Ocurrencias { get; set; }
public string Texto { get; set; }
public Dato(int ocurrencias, string texto)
{
Ocurrencias = ocurrencias;
Texto = texto;
}

public override string ToString()
{
return Texto + " | " + Ocurrencias;
}
}
}
