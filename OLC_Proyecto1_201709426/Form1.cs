using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OLC_Proyecto1_201709426.Modelos;
using OLC_Proyecto1_201709426.Analizadores;
using System.Diagnostics;
using System.IO;
using OLC_Proyecto1_201709426.Automata;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace OLC_Proyecto1_201709426
{
    public partial class Form1 : Form
    {
        String nombre_archivo = "";
        int contador = 0;

        List<Token> lista_errores = new List<Token>();
        List<Token> lista_tokens = new List<Token>();
        Dictionary<String, List<Token>> lista_conjuntos = new Dictionary<String, List<Token>>();
        Dictionary<String, List<Token>> lista_er = new Dictionary<String, List<Token>>();
        Dictionary<Token, String> lista_lex = new Dictionary<Token, String>();
        List<AF> automatas = new List<AF>();
        int index = 0;
        String token_reconcido = "";
        String nombre_token = "";
        String error_reconocido = "";


        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            contador++;
            nombre_archivo = "nueva" + contador;
            crear_ventana("", "");
        }
        public void crear_ventana(String texto, String ruta)
        {
            TabPage ventana = new TabPage();
            ventana.Height = 25;
            ventana.Width = 50;
            TextBox editor = new TextBox();
            editor.BackColor = Color.Black;
            editor.ForeColor = Color.Goldenrod;
            editor.Font = new System.Drawing.Font(editor.Font.FontFamily, 12);
            editor.Height = 320;
            editor.Width = 430;
            editor.AcceptsReturn = false;
            editor.AcceptsTab = true;
            editor.Text = texto;
            editor.Multiline = true;
            editor.ScrollBars = ScrollBars.Horizontal;
            editor.ScrollBars = ScrollBars.Vertical;
            ventana.Controls.Add(editor);
            ventana.Text = "Nueva";
            tb_principal.TabPages.Add(ventana);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String texto_ventana = "", texto_archivo, ruta_archivo;

            openFileDialog1.Filter = "OLC | *.er";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ruta_archivo = openFileDialog1.FileName;
                nombre_archivo = ruta_archivo;
                System.IO.StreamReader sr = new System.IO.StreamReader(ruta_archivo, System.Text.Encoding.Default);
                texto_ventana = sr.ReadToEnd();
                sr.Close();
                crear_ventana(texto_ventana, "");
            }
        }
        private void btn_analizar_Click(object sender, EventArgs e)
        {
            try
            {
                lista_tokens = new List<Token>();
                lista_conjuntos = new Dictionary<string, List<Token>>();
                lista_er = new Dictionary<string, List<Token>>();
                lista_lex = new Dictionary<Token, string>();
               /* com_afns.Items.Clear();
                com_tb.Items.Clear();
                com_afds.Items.Clear();
                com_afds.Items.Add("AFD");
                com_afns.Items.Add("AFD");
                com_tb.Items.Add("AFD");*/
                txt_salida.Text = "";

                int select = tb_principal.SelectedIndex;
                TextBox txt_actual = tb_principal.Controls[select].Controls[0] as TextBox;
                if (txt_actual.TextLength > 0)
                {
                    Analizador_Lexico lexico = new Analizador_Lexico();
                    lexico.analizar(txt_actual.Text, lista_tokens, lista_errores);
                    Analizador_Sintactico sintactico = new Analizador_Sintactico(lista_tokens, lista_conjuntos, lista_er, lista_lex);
                    sintactico.analizar();
                    int index = 0;
                    while (index < lista_er.Count)
                    {
                        Automata.AF af = new Automata.AF(lista_er.ElementAt(index).Value, lista_er.ElementAt(index).Key);
                        automatas.Add(af);
                        com_afns.Items.Add(lista_er.ElementAt(index).Key);
                        com_tb.Items.Add(lista_er.ElementAt(index).Key);
                        com_afds.Items.Add(lista_er.ElementAt(index).Key);
                        index++;
                    }

                }
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(nombre_archivo + ".pdf", FileMode.Create));
                doc.Open();
                Paragraph title = new Paragraph();
                title.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLUE);
                title.Add("Tabla de tokens del archivo: " + nombre_archivo);
                doc.Add(title);
                doc.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(5);
                table.AddCell("Id Token");
                table.AddCell("Lexema");
                table.AddCell("Descripcion");
                table.AddCell("Fila");
                table.AddCell("Columna");

                for (int i = 0; i < lista_tokens.Count -1; i++)
                {
                    table.AddCell(String.Concat(lista_tokens.ElementAt(i).getId_token()));
                    table.AddCell(lista_tokens.ElementAt(i).getLexema());
                    table.AddCell(lista_tokens.ElementAt(i).getDescripcion());
                    table.AddCell(String.Concat(lista_tokens.ElementAt(i).getFila()));
                    table.AddCell(String.Concat(lista_tokens.ElementAt(i).getColumna()));

                }
                doc.Add(table);
                doc.Close();
                string pdfPath = Path.Combine(Application.StartupPath, nombre_archivo + ".pdf");

                Process.Start(pdfPath);
            }
            catch (Exception) { 
            
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void com_tb_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tm = (string)com_tb.SelectedItem;
            if (tm != null) { cargar_imagen(tm, "tb_"); }
        }


        private void com_afds_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tm = (string)com_afds.SelectedItem;
            if (tm != null) { cargar_imagen(tm, "afd_"); }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void com_afns_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tm = (string)com_afns.SelectedItem;
            if (tm != null) { cargar_imagen(tm, "afnd_"); }
        }
        public void cargar_imagen(String nombre, String tipo)
        {
            try
            {
                String ruta = tipo + nombre + ".png";
                pcb_imagen.Image = System.Drawing.Image.FromFile(ruta);

            }
            catch (Exception) { }
        }

        String tokens = "";
        String errores = "";
        private void button1_Click_2(object sender, EventArgs e)

        {

            tokens = "<ListaTokens>";
            errores = "<ListaErrores>";
            for (int i = 0; i < lista_lex.Count; i++)
            {
                Boolean aceptada = false;
                try { 


                   token_reconcido = "";
                    aceptada = analizar_lexema(lista_lex.ElementAt(i).Value, lista_lex.ElementAt(i).Key.getLexema(),
                        lista_lex.ElementAt(i).Key.getFila());

                }
                catch (Exception)
                {

                }

                txt_salida.Text = txt_salida.Text + "Expresion: " + lista_lex.ElementAt(i).Value +
                    "   |  Lexema: " + lista_lex.ElementAt(i).Key.getLexema() + "    |  Resultado: " + aceptada + "\n";


            }
            tokens = tokens + "</ListaTokens>";
            errores = errores + "</ListaErrores>";
            String no = nombre_archivo.Replace("\\", "").Replace(".", "").Replace(" ", "").Replace(":", "");
            StringBuilder file = new StringBuilder();
            file.Append(errores);
            System.IO.File.WriteAllText("errores" + no + ".xml", file.ToString());
            string pdfPath = Path.Combine(Application.StartupPath, "errores" + no + ".xml");

            Process.Start(pdfPath);
            file = new StringBuilder();
            file.Append(tokens);
            System.IO.File.WriteAllText("tokens" + no + ".xml", file.ToString());
             pdfPath = Path.Combine(Application.StartupPath, "tokens" + no + ".xml");

            Process.Start(pdfPath);
        }


        
        Boolean analizar_lexema(String expresion, String lexema, int fila)
        {
            char cr = '\r';
            lexema = lexema.Replace(String.Concat(cr),"");
            index = 1;
            Boolean aceptado = false;
            Boolean aceptado_f = true;
            Estado tmp = buscar_af(expresion).estados_afd.ElementAt(0);
            while (tmp != null)
            {
                aceptado = false;
                Estado aux = tmp;
                for (int i = 0; i < tmp.transiciones.Count; i++)
                {
                    if (tmp.transiciones.ElementAt(i).valor_tr.getId_token() == 780)
                    {
                        nombre_token = tmp.transiciones.ElementAt(i).valor_tr.getLexema();
                        if (si_es_cadena(tmp.transiciones.ElementAt(i).valor_tr.getLexema(), lexema))
                        {
                            tmp = tmp.transiciones.ElementAt(i).e_final;
                            i = tmp.transiciones.Count;
                            aceptado = true;
                        }

                    }
                }
                if (!aceptado)
                {
                    for (int i = 0; i < tmp.transiciones.Count; i++)
                    {
                        if (tmp.transiciones.ElementAt(i).valor_tr.getId_token() == 774)
                        {
                            nombre_token = tmp.transiciones.ElementAt(i).valor_tr.getLexema();
                            if (si_es_conjunto(tmp.transiciones.ElementAt(i).valor_tr.getLexema(), String.Concat(lexema.ElementAt(index))))
                            {
                                tmp = tmp.transiciones.ElementAt(i).e_final;
                                i = tmp.transiciones.Count;
                                aceptado = true;
                            }
                        }

                    }
                }

                if (index >= lexema.Length - 1)
                {
                    if (!tmp.aceptacion) {
                        aceptado_f = false;
                    }
                        tmp = null;
                    if (aceptado)
                    {
                        tokens = tokens + "<Token>\n<Nombre>" + nombre_token + "</Nombre>\n<Valor>" + token_reconcido +
                        "</Valor>\n <Fila> " + fila + " </Fila>\n <Columna> " + index + " </Columna>\n </Token>\n";
                        token_reconcido = "";
                        Console.WriteLine(lexema[index]);//agregacion de errores

                    }
                }
                else {
                    if (aceptado)
                    {
                        tokens = tokens + "<Token>\n<Nombre>" + nombre_token + "</Nombre>\n<Valor>" + token_reconcido +
                        "</Valor>\n <Fila> " + fila + " </Fila>\n <Columna> " + index + " </Columna>\n </Token>\n";
                        token_reconcido = "";
                        Console.WriteLine(lexema[index]);//agregacion de errores

                    }
                    else
                    {
                        aceptado_f = false;
                        errores = errores + "<Error>\n<Valor>" + lexema[index] + "</Valor>\n"
                            + "<Fila>" + fila + "</Fila>\n<Columna>" + index + "</Columna>\n</Error>\n";
                        Console.WriteLine(lexema[index]);//agregacion de errores
                        index++;
                    }
                }
               
            }

            return aceptado_f;

        }
        Boolean existe_TR(Estado e) {
            for (int i = 0; i < e.transiciones.Count; i++)
            {
                if (e.transiciones.ElementAt(i).e_final == e)
                {
                    return true;
                }
                else if (e.transiciones.ElementAt(i).e_final.id_estado == e.id_estado) { 
                    return true;
                }
            }
            return false;
        }
        Boolean si_es_cadena(String cadena, String valor)
        {
            Boolean estado = true;
           
            for (int i = 1; i < cadena.Length - 1; i++)
            {
                if (!cadena.ElementAt(i).Equals(valor.ElementAt(index)))
                {
                    estado = false;
                }
                else
                {
                    token_reconcido = token_reconcido + valor.ElementAt(index);
                    index++;
                }

            }
            return estado;
        }
        Boolean si_es_numero(String num, String valor)
        {
            Boolean estado = true;
            for (int i = 1; i < num.Length - 1; i++)
            {
                if (!num.ElementAt(i).Equals(valor.ElementAt(index)))
                {
                    estado = false;
                }
                else
                {
                    token_reconcido = token_reconcido + valor.ElementAt(index);
                    index++;
                }

            }
            return estado;
        }
        Boolean si_es_conjunto(String conjunto, String valor)
        {
            Boolean estado = false;
            List<Token> conj = lista_conjuntos[conjunto];
                for (int i = 0; i < conj.Count; i++)
                {
                    if (conj.ElementAt(i).getLexema().Equals(valor))
                    {
                        token_reconcido = token_reconcido + valor;
                        index++;
                        return true;
                    }
                }
            return estado;

        }
        AF buscar_af(String nombre)
        {
            for (int i = 0; i < automatas.Count; i++)
            {
                if (automatas.ElementAt(i).nombre.Equals(nombre))
                {
                    return automatas.ElementAt(i);
                }
            }
            return null;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                saveFileDialog1.ShowDialog();
                string path = saveFileDialog1.FileName;
                nombre_archivo = path;
                int select = tb_principal.SelectedIndex;
                TextBox txt_actual = tb_principal.Controls[select].Controls[0] as TextBox;
                File.WriteAllText(path, txt_actual.Text);

            }
            catch (Exception) { }
        }
    }
}