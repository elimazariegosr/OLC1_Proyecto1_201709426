using OLC_Proyecto1_201709426.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC_Proyecto1_201709426.Analizadores
{
    class Analizador_Sintactico
    {
        List<Token> lista_tokens = new List<Token>();
        Dictionary<String, List<Token>> lista_conjuntos = new Dictionary<String, List<Token>>();
        Dictionary<String, List<Token>> lista_er= new Dictionary<String, List<Token>>();
        Dictionary<Token, String> lista_lex = new Dictionary<Token, String>();


        int index = 0;

        public Analizador_Sintactico(List<Token> lista_tokens, Dictionary<String, List<Token>> lista_conjuntos,
                Dictionary<String, List<Token>> lista_er, Dictionary<Token, String> lista_lex)
        {
            this.lista_tokens = lista_tokens;
            this.lista_conjuntos = lista_conjuntos;
            this.lista_er = lista_er;
            this.lista_lex = lista_lex;
            lista_tokens.Add(new Token(999, "#", "fin"));
        }

        public void analizar()
        {
            while (lista_tokens.ElementAt(index).getId_token() != 999) {

                if (lista_tokens.ElementAt(index).getId_token() == 773)
                {
                    consumir();
                    definicion_conjunto();
                }
                if (lista_tokens.ElementAt(index).getId_token() == 774)
                {
                    if (lista_tokens.ElementAt(index + 1).getId_token() == 58)
                    {
                        definicion_er_lex(1, lista_tokens.ElementAt(index).getLexema());

                    }
                    else
                    {
                        definicion_er_lex(0, lista_tokens.ElementAt(index).getLexema());

                    }

                }
                if (lista_tokens.ElementAt(index).getId_token() == 778 || lista_tokens.ElementAt(index).getId_token() == 779)
                {
                    consumir();
                }

            }
        }

        public void definicion_er_lex(int lex_ex, String nombre)
        {
            List<Token> list = new List<Token>();
            consumir();
            if (lex_ex == 0)
            {
                if (lista_tokens.ElementAt(index).getId_token() == 45)
                {
                    consumir();
                }
                else
                {

                }
                if (lista_tokens.ElementAt(index).getId_token() == 62)
                {
                    consumir();
                }
                else
                {

                }
            }
            else
            {
                if (lista_tokens.ElementAt(index).getId_token() == 58)
                {
                    consumir();
                }
            }

            while (lista_tokens.ElementAt(index).getId_token() != 59)
            {
                if (lista_tokens.ElementAt(index).getId_token() != 34 &&
                        lista_tokens.ElementAt(index).getId_token() != 123 &&
                        lista_tokens.ElementAt(index).getId_token() != 125)
                {

                    list.Add(lista_tokens.ElementAt(index));
                }
                consumir();
            }
            if (lista_tokens.ElementAt(index).getId_token() == 59)
            {
                consumir();
            }
            else
            {

            }
            if (lex_ex == 1)
            {
                try
                {
                    lista_lex[list.ElementAt(0)] = nombre;
                }
                catch (Exception) {
                    lista_lex.Add(list.ElementAt(0), nombre);

                }
                
            }
            else
            {
                try
                {
                    lista_er[nombre] = list;

                }
                catch (Exception) { 
                    lista_er.Add(nombre, list);

                }
            }
        }

        public void definicion_conjunto()
        {
            String nombre = "";
            List<Token> list = new List<Token>();
            if (lista_tokens.ElementAt(index).getId_token() == 58)
            {// token dos puntos
                consumir();
            }
            else
            {//error sintactico

            }
            if (lista_tokens.ElementAt(index).getId_token() == 774)
            {// token identificador
                nombre = lista_tokens.ElementAt(index).getLexema();
                consumir();
            }
            else
            {//error sintactico

            }
            if (lista_tokens.ElementAt(index).getId_token() == 45)
            { // token -
                consumir();
            }
            else
            {//error sintactico

            }
            if (lista_tokens.ElementAt(index).getId_token() == 62)
            {//  token >
                consumir();
            }
            else
            {//error sintactico

            }
            while (lista_tokens.ElementAt(index).getId_token() != 59)
            {
                list.Add(lista_tokens.ElementAt(index));
                consumir();
            }
            if (lista_tokens.ElementAt(index).getId_token() == 59)
            {
                consumir();
            }
            else
            {

            }

            list = conjunto(list);

            try
            {
                lista_conjuntos[nombre] = list;
            }
            catch (Exception) {
                lista_conjuntos.Add(nombre, list);

            }
        }

        public List<Token> conjunto(List<Token> list) {
            List<Token> tmp = new List<Token>();
            if (list.ElementAt(0).getId_token() == 91)
            {
                for (int i = 2; i < list.Count -2; i++)
                {
                    for (int j = 0; j < list.ElementAt(i).getLexema().Length; j++)
                    {
                        tmp.Add(new Token(list.ElementAt(i).getLexema()[j], String.Concat(list.ElementAt(i).getLexema()[j]), "todo"));
                    }
                }
            }
            else {
                if (list.ElementAt(1).getId_token() == 44 || list.ElementAt(2).getId_token() == 44)
                {
                    for (int i = 0; i < list.Count; i++)
                    {

                        if (list.ElementAt(i).getId_token() != 44)
                        {
                            if (list.ElementAt(i).getId_token() == 92)
                            {
                                i++;
                                if (list.ElementAt(i).getLexema().Equals("t"))
                                {
                                    tmp.Add(new Token(9, "\t", "tabulacion"));                                    
                                }
                                else if (list.ElementAt(i).getLexema().Equals("n"))
                                {
                                    tmp.Add(new Token(10, "\n", "salto de linea"));
                                }
                                else
                                {
                                    tmp.Add(list.ElementAt(i));
                                }
                            }
                            else
                            {
                                tmp.Add(list.ElementAt(i));
                            }
                        }
                    }
                }
                else
                {
                    if (list.ElementAt(0).getId_token() == 775)
                    {
                        for (int i = int.Parse(list.ElementAt(0).getLexema()); i <= int.Parse(list.ElementAt(2).getLexema()); i++)
                        {
                            tmp.Add(new Token(775, string.Concat(i), ""));
                        }
                    }
                    else
                    {
                        for (int i = list.ElementAt(0).getLexema()[0]; i <= list.ElementAt(2).getLexema()[0]; i++)
                        {
                            char c = Convert.ToChar(i);
                            tmp.Add(new Token(i, string.Concat(c), ""));
                        }
                    }
                }

            }

            return tmp;

        }
        public void consumir()
        {
            index++;
        }

    }
}
