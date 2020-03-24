using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC_Proyecto1_201709426.Modelos
{
    class Transicion
    {
        public Estado e_final;
        public String final;
        public Token valor_tr;
        public Boolean aceptacion = false;

        public Transicion(String final, Token valor) {
            this.final = final;
            this.valor_tr = valor;
        }

    }
}
