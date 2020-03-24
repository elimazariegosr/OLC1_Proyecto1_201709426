using OLC_Proyecto1_201709426.Automata;
using OLC_Proyecto1_201709426.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC_Proyecto1_201709426.Automata
{
    class AF
    {
        List<Token> er = new List<Token>();
        List<Token> terminales = new List<Token>();
        
        public List<Estado> estados_afd = new List<Estado>();
        Lista lista_estados = new Lista();
        
        int index = 0;
        int index_afn = 1;
        
        public String nombre = "";
        public AF(List<Token> er, String nombre)
        {
            this.er = er;
            this.nombre = nombre;
            crear_afn(new Estado());
            generar_afd();
            graficar_tabla();
            imprimir();
            graficar_afd();
        }
        public Estado crear_afn(Estado estado) {
            Estado e1, e2, e3, e4, e5,tmp;
            switch (er.ElementAt(index).getId_token()) 
            {
                case 42:
                    index++;
                    e1 = new Estado("Epsilon", index_afn++);
                    e2 = crear_afn(e1);
                    e3 = new Estado("Epsilon", index_afn++);
                    crear_kleen(estado,e1,e2,e3);
                    estado = e3;
                    break;
                case 43:
                    index++;
                    int aux = index;
                    e1 = crear_afn(estado);
                    index = aux;
                    crear_transicion(estado, e1, 1);
                    e2 = new Estado("Epsilon", index_afn++);
                    e3 = crear_afn(e2);
                    e4 = new Estado("Epsilon", index_afn++);
                    crear_kleen(e1, e2, e3, e4);
                    estado = e4;
                    break;
                case 46:
                    index++;
                    e1 = crear_afn(estado);
                    crear_transicion(estado,e1,1);
                    e2 = crear_afn(e1);
                    crear_transicion(e1,e2,1);
                    estado = e2;
                    break;
                case 63:
                    index++;
                    e1 = new Estado("Epsilon", index_afn++);
                    e3 = crear_afn(e1);
                    e2 = new Estado("Epsilon", index_afn++);
                    e4 = new Estado("Epsilon", index_afn++);
                    e5 = new Estado("Epsilon", index_afn++);
                    crear_union(estado, e1, e2, e3, e4, e5);
                    estado = e5;

                    break;
                case 124:
                    index++;
                    e1 = new Estado("Epsilon",index_afn++);
                    e3 = crear_afn(e1);
                    e2 = new Estado("Epsilon", index_afn++);
                    e4 = crear_afn(e2);
                    e5 = new Estado("Epsilon", index_afn++);
                    crear_union(estado,e1,e2,e3,e4,e5);
                    estado = e5;

                    break;
                default:
                    estado = new Estado();
                    estado.id_estado = index_afn;
                    estado.puente = er.ElementAt(index).getLexema();
                    if (!existe_terminal(er.ElementAt(index).getLexema())) { 
                        terminales.Add(er.ElementAt(index));
                    }
                    index++;
                    index_afn++;
                    break;
            }

            return estado;
        }
        public Boolean existe_terminal(String lexema) {
            for (int i = 0; i < terminales.Count; i++)
            {
                if (terminales.ElementAt(i).getLexema().Equals(lexema)) {
                    return true;
                }

            }
            return false;
        }
        public void crear_kleen(Estado estado, Estado e1, Estado e2, Estado e3) {
            crear_transicion(estado, e1, 1);
            crear_transicion(e1, e2, 1);
            crear_transicion(e2, e1, 1);
            crear_transicion(e2, e3, 2);
            crear_transicion(estado, e3, 2);

        }
        public void crear_union(Estado estado, Estado e1, Estado e2, Estado e3, Estado e4, Estado e5) {
            crear_transicion(estado, e1, 1);
            crear_transicion(estado, e2, 2);
            crear_transicion(e1, e3, 1);
            crear_transicion(e2, e4, 1);
            crear_transicion(e3, e5, 1);
            crear_transicion(e4, e5, 1);
        }

        public void crear_transicion(Estado actual, Estado siguiente, int valor) {
            if (lista_estados.retornar_0(actual).cant_tr < valor)
            {
                lista_estados.insertar(actual, siguiente);
            }
        }
        public void generar_afd()
        {
            List<int> e0 = new List<int>();
            e0.Add(0);
            List<int> ir_e0 = ir(e0,"Epsilon");
            if (ir_e0.Count == 0) {
                ir_e0.Add(0);
            }
            estados_afd.Add(new Estado(string.Join(",", ir_e0.ToArray())));
            
            Estado tmp = estados_afd.ElementAt(0);
            tmp.visitado = true;
            while(tmp != null)
            {
                for (int i = 0; i < terminales.Count; i++)
                {
                    List<int> ir_terminal = ir(ir_e0,terminales.ElementAt(i).getLexema());
                    String stir = string.Join(",", ir_terminal.ToArray());

                    Estado nuevo = existe_estado(stir);
                    if (ir_terminal.Count > 0)
                    {
                        Transicion tr = null;
                        if (!tmp.existe_transicion(terminales.ElementAt(i), stir))
                        {
                            tr = new Transicion(stir, terminales.ElementAt(i));
                            tmp.transiciones.Add(tr);
                        
                        }
                        if (nuevo == null)
                        {
                            nuevo = new Estado();
                            nuevo.sigs = ir_terminal;
                            nuevo.puente = stir;
                            if (tr != null)
                            {
                                tr.e_final = nuevo;
                            }
                            estados_afd.Add(nuevo);
                        }
                        else {
                            tr.e_final = nuevo;
                        }
                    }
                        
                    
                }
                tmp = buscar_no_visitado(estados_afd);
                if (tmp != null) { 
                    ir_e0 = ir(tmp.sigs,"Epsilon");
                    
                    if (ir_e0.Count == 0) {
                        ir_e0 = tmp.sigs;
                    }
                    if (ir_e0.Contains(index_afn - 1))
                    {
                        tmp.aceptacion = true;
                    }
                }
            }
        }

        public Estado existe_estado(String estado) {
            for (int i = 0; i < estados_afd.Count; i++)
            {
                if (estados_afd.ElementAt(i).puente.Equals(estado)) {
                    return estados_afd.ElementAt(i);
                }
            }
            return null;
        }
        public Estado buscar_no_visitado(List<Estado> estados) {
            for (int i = 0; i < estados.Count; i++)
            {
                if (estados.ElementAt(i).visitado == false) {
                    estados.ElementAt(i).visitado = true;
                    return estados.ElementAt(i);
                }
            }
            return null;
        }
        public List<int> ir(List<int> l_estado, String terminal) {
            List<int> list = new List<int>();
            List<Estado> visita = new List<Estado>();

            for (int i = 0; i < l_estado.Count; i++)
            {
                Nodo tmp = lista_estados.existe_cabecera(new Estado("", l_estado.ElementAt(i)));
                while (tmp != null) {
                    if (tmp.getSiguiente() != null)
                    {
                        tmp = tmp.getSiguiente();
                        while (tmp != null)
                        {
                            if (tmp.getValor().puente.Equals(terminal))
                            {
                                if (!list.Contains(tmp.getValor().id_estado))
                                {
                                    list.Add(tmp.getValor().id_estado);
                                    visita.Add(new Estado("", tmp.getValor().id_estado));

                                }
                            }
                            tmp = tmp.getSiguiente();
                        }
                    }
                    Estado aux = buscar_no_visitado(visita);
                    if (aux != null) {
                        tmp = lista_estados.existe_cabecera(new Estado("", aux.id_estado));

                    }
                    else {
                        tmp = null;
                    }
                }

            }
            list.Sort();
            return list;
        }

        public String[,] llenar_tabla()
        {
            String[,] tb = new String[estados_afd.Count + 1, terminales.Count + 1];
            tb[0,0] = "ESTADO";
            for (int i = 0; i < terminales.Count; i++)
            {
                tb[0,i + 1] = terminales.ElementAt(i).getLexema();
            }
            for (int i = 0; i < estados_afd.Count; i++)
            {
                tb[i + 1,0] = estados_afd.ElementAt(i).puente;
                for (int j = 0; j < terminales.Count ; j++)
                {
                    for (int k = 0; k < estados_afd.ElementAt(i).transiciones.Count; k++)
                    {
                        if (tb[0,j + 1].Equals(estados_afd.ElementAt(i).transiciones.ElementAt(k).valor_tr.getLexema()))
                        {
                            tb[i + 1,j + 1] = estados_afd.ElementAt(i).transiciones.ElementAt(k).e_final.puente;
                        }
                    }
                }
            }

            return tb;
        }
        public void graficar_tabla() {
            String[,] tb = llenar_tabla();
            String file;
            file = "digraph Grafica{\n";

            file = file + "graph [ratio=fill];\n"
                    + "node [label=\"\\N\", fontsize=15, shape=plaintext];\n"
                    + "graph [bb=\"0,0,352,154\"];";

            file = file + "arset [label=<\n"
                    + "        <TABLE ALIGN=\"LEFT\">\n";

            for (int i = 0; i < tb.GetLength(0); i++)
            {
                file = file + "<TR>";
                for (int j = 0; j < tb.GetLength(1); j++)
                {
                    String valor = "--";
                    if (tb[i,j] != null)
                    {
                        valor = tb[i,j].Replace("<", "&#60;").Replace(">", "&#62;");
                    }

                    file = file + "<TD>" + valor + "</TD>\n";
                }
                file = file + "</TR>";
            }

            file = file + "</TABLE>\n>,];\n}";
            Generador_Grafica gr = new Generador_Grafica();
            gr.generar_imagen("tb_" + nombre, file);
        }
        public void graficar_afd() { 
           Dictionary<String, String> ids = new Dictionary<string, string>();
        for (int i = 0; i < estados_afd.Count; i++) {
            ids.Add(estados_afd.ElementAt(i).puente, "S" + i);
        }
            String file = "digraph dot{\nrankdir=LR;\n node[shape=\"circle\"];\n"
                + "label = \"AFD de la expresion:\";\n";

        for (int i = 0; i < estados_afd.Count; i++) {
            file = file + ids[estados_afd.ElementAt(i).puente] + "[label = \"S" + i + "\"];\n";
            for (int j = 0; j < estados_afd.ElementAt(i).transiciones.Count; j++) {
                String label = estados_afd.ElementAt(i).transiciones.ElementAt(j).valor_tr.getLexema().Replace("\"", "\\\"").Replace("\\\\\"", "\\\"");
                file = file + ids[estados_afd.ElementAt(i).puente] + "->"
                        + ids[estados_afd.ElementAt(i).transiciones.ElementAt(j).final]
                        + "[label=\"" +label+ "\"];\n";
                    if (estados_afd.ElementAt(i).transiciones.ElementAt(j).e_final != null) {
                        if (estados_afd.ElementAt(i).transiciones.ElementAt(j).e_final.aceptacion == true)
                        {
                            file = file + ids[estados_afd.ElementAt(i).transiciones.ElementAt(j).final] + "[shape = \"doublecircle\"];";
                        }
                    }
                    
            }
        }
        file = file + "\n}";
            Generador_Grafica gr = new Generador_Grafica();
            gr.generar_imagen("afd_" + nombre,file);
        }
        public void imprimir()
        {
            String file = "digraph G{ \nrankdir=LR;\n node[shape=\"circle\"];";
            Nodo tmp_cabecera = lista_estados.cabecera;
            while (tmp_cabecera != null)
            {
                Nodo tmp_hijos = tmp_cabecera;
                if (tmp_cabecera.getSiguiente() != null)
                {
                    tmp_hijos = tmp_cabecera.getSiguiente();
                }
                while (tmp_hijos != null)
                {
                    if (tmp_cabecera.getAbajo() != null)
                    {
                        file = file + "S" + tmp_cabecera.getValor().id_estado + "-> S" + tmp_hijos.getValor().id_estado + "[label=\"" + tmp_hijos.getValor().puente.Replace("\"", "\\\"").Replace("\\\\\"", "\\\"") + "\"];\n";
                    }
                    tmp_hijos = tmp_hijos.getSiguiente();
                }
                if (tmp_cabecera.getAbajo() == null)
                {
                    file = file + "S" + tmp_cabecera.getValor().id_estado + "[shape=\"doublecircle\"]\n";
                }
                tmp_cabecera = tmp_cabecera.getAbajo();

            }
            file = file + "\n}";
            Generador_Grafica gr = new Generador_Grafica();
            gr.generar_imagen("afnd_" + nombre, file);
        }
        public void generar_graficas() { 
        
        }
    }
}
