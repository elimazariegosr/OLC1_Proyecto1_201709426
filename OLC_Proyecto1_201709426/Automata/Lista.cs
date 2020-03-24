using OLC_Proyecto1_201709426.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OLC_Proyecto1_201709426.Automata
{
    class Lista
    {

        public Nodo cabecera = null;

        public Boolean esta_vacia()
        {
            return cabecera == null;
        }
        
        public Nodo retornar_0(Estado nodo) {
            Nodo tmp = existe_cabecera(nodo);
            if (tmp == null) {
                tmp = new Nodo();
                tmp.cant_tr = 0;
            }
            else
            {
                if (tmp.getValor().id_estado == 0) {
                    int i = 0;
                }
            }
            return tmp;
        }
        public Nodo existe_cabecera(Estado valor)
        {
            if (!esta_vacia())
            {
                Nodo aux = cabecera;
                while (aux != null)
                {
                    if (aux.getValor().id_estado == valor.id_estado)
                    {
                        return aux;
                    }
                    aux = aux.getAbajo();
                }
            }
            return null;
        }

        public Nodo crear_cabecera(Estado valor)
        {
            Nodo nuevo = new Nodo(valor);

            if (!esta_vacia())
            {

                Nodo aux = cabecera;
                if (aux.getValor().id_estado > valor.id_estado)
                {
                    nuevo.setAbajo(aux);
                    aux.setArriba(nuevo);
                    cabecera = nuevo;

                }
                
                else {
                    while (aux != null)
                    {
                        if (aux.getAbajo() == null)
                        {
                            aux.setAbajo(nuevo);
                            nuevo.setArriba(aux);
                            return nuevo;
                        }else if (aux.getValor().id_estado < valor.id_estado && aux.getAbajo().getValor().id_estado > valor.id_estado) {
                            nuevo.setArriba(aux);
                            nuevo.setAbajo(aux.getAbajo());
                            aux.getAbajo().setArriba(nuevo);
                            aux.setAbajo(nuevo);
                            return nuevo;
                        
                        }

                        aux = aux.getAbajo();
                    }

                }
                return nuevo;

            }
            else
            {
                cabecera = new Nodo(valor);
                return cabecera;
            }
        }
        public void insertar(Estado cab, Estado valor)
        {
            Nodo aux_cabecera = existe_cabecera(cab);
            if (aux_cabecera == null)
            {
                aux_cabecera = crear_cabecera(cab);
            }
            Nodo auxiliar = aux_cabecera;
            int i = 0;
            while (auxiliar.getSiguiente() != null)
            {
                auxiliar = auxiliar.getSiguiente();
            }
            i++;

            Nodo nuevo = new Nodo(valor);
            if (existe_cabecera(valor) == null)
            {
                crear_cabecera(valor);

            }

            auxiliar.setSiguiente(nuevo);
            nuevo.setAnterior(auxiliar);
            aux_cabecera.cant_tr = i;
        }

    }
}
