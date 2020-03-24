using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLC_Proyecto1_201709426.Automata
{
    class Generador_Grafica
    {
        String ruta = "";
        StringBuilder grafica;

        public Generador_Grafica() {
            ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);    

        }
        public void generar_imagen(String nombre, String valor) {
            StringBuilder file = new StringBuilder();
            file.Append(valor);
            System.IO.File.WriteAllText(nombre + ".dot", file.ToString());
            while (!File.Exists(nombre + ".dot")) { 
            }

            ProcessStartInfo si = new ProcessStartInfo("dot.exe");
            si.Arguments = "-Tpng " + nombre + ".dot -o " + nombre + ".png";
            Process.Start(si).WaitForExit();
        }
    }
}
