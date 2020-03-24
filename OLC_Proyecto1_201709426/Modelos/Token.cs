using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC_Proyecto1_201709426.Modelos
{
    class Token
    {
        private int id_token;
        private String lexema;
        private String descripcion;
        private int fila;
        private int columna;

        public Token()
        {
        }

        public Token(int id_token, String lexema, String descripcion, int fila, int columna)
        {
            this.id_token = id_token;
            this.lexema = lexema;
            this.descripcion = descripcion;
            this.fila = fila;
            this.columna = columna;
        }

        public Token(int id_token, String lexema, String descripcion)
        {
            this.id_token = id_token;
            this.lexema = lexema;
            this.descripcion = descripcion;
        }


        public String getDescripcion()
        {
            return descripcion;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }


        public int getId_token()
        {
            return id_token;
        }

        public void setId_token(int id_token)
        {
            this.id_token = id_token;
        }

        public String getLexema()
        {
            return lexema;
        }

        public void setLexema(String lexema)
        {
            this.lexema = lexema;
        }

        public int getFila()
        {
            return fila;
        }

        public void setFila(int fila)
        {
            this.fila = fila;
        }

        public int getColumna()
        {
            return columna;
        }

        public void setColumna(int columna)
        {
            this.columna = columna;
        }


    }
}
