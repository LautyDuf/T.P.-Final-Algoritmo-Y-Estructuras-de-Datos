using System;

namespace tpfinal
{
    public class Dato
    {
        public int ocurrencia;
        public string texto;

        public Dato(int ocurrencia, string texto)
        {
            this.ocurrencia = ocurrencia;
            this.texto = texto;
        }

        public override string ToString()
        {
            return texto + " , " + ocurrencia;
        }
    }
}
