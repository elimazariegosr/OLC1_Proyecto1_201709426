using OLC_Proyecto1_201709426.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC_Proyecto1_201709426.Modelos
{
    class Nodo
    {
        private Nodo siguiente, anterior, arriba, abajo;
        private Estado valor;
        public int cant_tr =0;

        public Nodo(Estado valor)
        {
            this.valor = valor;
        }
        public Nodo() { }

        public Nodo getSiguiente()
        {
            return siguiente;
        }

        public void setSiguiente(Nodo siguiente)
        {
            this.siguiente = siguiente;
        }

        public Nodo getAnterior()
        {
            return anterior;
        }

        public void setAnterior(Nodo anterior)
        {
            this.anterior = anterior;
        }

        public Nodo getArriba()
        {
            return arriba;
        }

        public void setArriba(Nodo arriba)
        {
            this.arriba = arriba;
        }

        public Nodo getAbajo()
        {
            return abajo;
        }

        public void setAbajo(Nodo abajo)
        {
            this.abajo = abajo;
        }

        public Estado getValor()
        {
            return valor;
        }

        public void setValor(Estado valor)
        {
            this.valor = valor;
        }

    }
}
