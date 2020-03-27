using OLC_Proyecto1_201709426.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC_Proyecto1_201709426.Analizadores
{
    class Analizador_Lexico
    {


        public void analizar(String texto,List<Token> lista_token, List<Token> lista_errores) {
            int estado_actual = 0, id_token = -1; // declarando variables para obtener el estado actual y el id del token
            String lexema = "", descripcion = "";// declarando variables para el lexema y la descripcion del token
            int j = 0;
            int fila = 0;
            int columna = 0;
            for (int i = 0; i < texto.Length; i++)
            {
                int ch_int_actual, ch_int_siguiente = -1;// variables para ver el codigo acsii del caracter en la posicion i,j

                ch_int_actual = texto.ElementAt(i);//asignacion de codigo ascii
                if (estado_actual == 0)
                {
                    estado_actual = transicion(ch_int_actual);// validando a que estado pertenece el codigo
                }
                try
                {
                    ch_int_siguiente = texto.ElementAt(i + 1);//asignado caracter en la posicion j + 1
                }
                catch (Exception) { 
                
                }
                switch (estado_actual)
                    
                {
                    case 92:
                        i++;
                        if (texto.ElementAt(i) == 'n')
                        {
                            lexema = lexema + "\n";
                        }
                        else if (texto.ElementAt(i) == 't')
                        {
                            lexema = lexema + "\t";
                        } else if(texto.ElementAt(i) == 'r')
                        {
                            lexema = lexema + "\r";
                        }

                        else { 
                            lexema = lexema + texto.ElementAt(i);
                        }
                        estado_actual = 0;
                        id_token = texto.ElementAt(i) + 100;
                        descripcion = "caracter especial";
                        break;
                    case 10:
                        columna = 0;
                        fila++;
                        estado_actual = -2;
                        break;
                    case 34:
                        if (ch_int_actual == 92)
                        {
                            //lexema = lexema + texto.ElementAt(i);
                            i++;
                            char c = es_caracter(texto.ElementAt(i));
                            if (c != ' ')
                            {
                                lexema = lexema + c;
                            }
                            else { 
                                lexema = lexema + texto.ElementAt(i);
                            }
                            try
                            {
                                ch_int_siguiente = texto.ElementAt(i + 1);//asignado caracter en la posicion j + 1
                            }
                            catch (Exception e)
                            {
                            }

                        }
                        else
                        {
                            if (texto.ElementAt(i).Equals('\n')) {

                                columna = 0;
                                fila++;
                            }
                           
                            lexema = lexema + texto.ElementAt(i);

                        }
                        if (ch_int_siguiente == 34)
                        {
                            estado_actual = 0;
                            id_token = 780;
                            descripcion = "Cadena";
                            i++;
                            lexema = lexema + '"';
                            break;
                        }


                        break;
                    case 60:
                        lexema = lexema + texto.ElementAt(i);
                        if (ch_int_siguiente == 33)
                        {
                            estado_actual = 779;
                        }
                        else
                        {
                            id_token = 60;
                            estado_actual = 0;
                        }
                        break;

                    case 47:
                        lexema = lexema + texto.ElementAt(i);
                        if (ch_int_siguiente == 47)
                        {
                            estado_actual = 778;
                        }
                        else
                        {
                            id_token = 47;
                            estado_actual = 0;
                        }

                        break;

                    case 774:
                        lexema = lexema + texto.ElementAt(i);
                        if ((ch_int_siguiente > 96 && ch_int_siguiente < 123) || (ch_int_siguiente > 64 && ch_int_siguiente < 91)
                            || (ch_int_siguiente > 47 && ch_int_siguiente < 58) || (ch_int_siguiente == 95))
                        {//validar si el siguiente es letra o numero
                            estado_actual = 774;// permaneciendo en el estado actual
                        }
                        else
                        {
                            if (lexema == "CONJ")
                            {//validando si el id es la palabra reservada CONJ
                                id_token = 773;//asignando id 
                                descripcion = "Reservada ";
                            }
                            else
                            {// asignando identificador
                                id_token = 774;
                                descripcion = "Identificador";
                            }
                            estado_actual = 0;//regresando al estado inicial
                        }
                        break;
                    case 775:// estado para la aceptacion de numeros
                        lexema = lexema + texto.ElementAt(i);// concatenando el char
                        if (ch_int_siguiente > 47 && ch_int_siguiente < 58)
                        {// validando si el siguiente char es un numero
                            estado_actual = 775;//permaneciendo en el estado actual
                        }
                        else
                        {
                            id_token = estado_actual;// asignando numero
                            descripcion = "Numero";
                            estado_actual = 0;
                        }
                        break;
                    case 776:// estado para obviar espacios
                        estado_actual = -2;
                        break;

                    case 777://estado que reconoce errores lexicos
                        lexema = lexema + texto.ElementAt(i);
                        descripcion = "Error Lexico";
                        lista_errores.Add(new Token(777, lexema, descripcion, i, j));//agregando el error a la lista
                        estado_actual = -2;
                        break;
                    case 778:

                      
                        lexema = lexema + texto.ElementAt(i);

                        if (ch_int_siguiente == 10)
                        {
                            estado_actual = 0;
                            id_token = 778;

                            descripcion = "Comentario una linea";
                        }


                        break;
                    case 779:
                        lexema = lexema + texto.ElementAt(i);
                        try
                        {
                            if (texto.ElementAt(i) == 33)
                            {
                                if (texto.ElementAt(i + 1) == 62)
                                {
                                    lexema = lexema + texto.ElementAt(i + 1);
                                    i++;
                                    descripcion = "Comentario multilinea";

                                    estado_actual = 0;
                                    id_token = 779;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                        }
                        break;
                    default:// sirve para reconocer cualquier caracter definido en el rango establecido
                        lexema = String.Concat(texto.ElementAt(i));//asignando el lexema
                        descripcion = "Simbolo ";// asignando descripcion
                        id_token = estado_actual;// asingando id de token segun el codigo ascii del simbolo
                        estado_actual = 0;
                        break;

                }
                if (estado_actual == 0)
                {//si el estado es 0 en este punto agrega el token a la lista
                    columna++;
                    lista_token.Add(new Token(id_token, lexema, descripcion, fila, columna));
                    lexema = "";
                }
                if (estado_actual == -2)
                {// sirve para cuando se obvian los espacios o se encuentran errores
                    estado_actual = 0;
                }

            }


        }

        char es_caracter(char c) {
            switch (c) {
                case 'n':
                    return '\n';
                case 't':
                    return '\t';
                case 'r':
                    return '\r';
               
            }
            return ' ';
        }
        public int transicion(int ch_int)
        {// metodo 
            int tkr = -1;
            
            if (tkr == -1)
            {
                if ((ch_int > 96 && ch_int < 123) || (ch_int > 64 && ch_int < 91))
                {// letraas
                    return 774;
                }
                else if ((ch_int > 47 && ch_int < 58))
                {//numeros
                    return 775;
                }
                else if (ch_int == 32 || ch_int == 13 || ch_int == 9)
                {// Espacios
                    tkr = 776;
                }
                else 
                {
                    tkr = ch_int; // cualquier char dentro del rango
                }
            }
            return tkr;//retornando el estado
        }

    }
}
