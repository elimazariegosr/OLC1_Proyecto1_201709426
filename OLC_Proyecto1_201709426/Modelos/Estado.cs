using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC_Proyecto1_201709426.Modelos
{
    class Estado
    {
        public int id_estado;
        public List<Transicion> transiciones = new List<Transicion>();
        public List<int> sigs ;

        public String puente;
      
        public Boolean visitado = false;
        public Boolean aceptacion = false;

        public Estado()
        {

        }


        public Boolean existe_transicion(Token ter, String estado)
        {

            for (int i = 0; i < transiciones.Count; i++)
            {
                if (transiciones.ElementAt(i).valor_tr.getLexema().Equals(ter.getLexema()) && transiciones.ElementAt(i).final.Equals(estado))
                {
                    if (transiciones.ElementAt(i).valor_tr.getId_token() == ter.getId_token()) { 
                    
                    return true;
                    }
                }
            }
            return false;
        }

        public Estado(String puente, int id)
        {
            this.puente = puente;
            this.id_estado = id;
        }
        public Estado(String puente)
        {
            this.puente = puente;
        }

    }
}
