using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace arbolsimple.clases.JuegoAnimal
{
    class ImprimeArbol
    {
        public void imagen()
        {

            String line;
            try
            {

                StreamReader sr = new StreamReader("\\Users\\mynor\\OneDrive\\Escritorio\\JuegoAnimal\\Juego.txt");
                StreamWriter text = new StreamWriter("\\Users\\mynor\\OneDrive\\Escritorio\\JuegoAnimal\\ImagenJuego.txt");

                line = sr.ReadLine();

                text.WriteLine("digraph {");
                while (line != null)
                {
                    text.WriteLine(line);
                    line = sr.ReadLine();
                }

                sr.Close();
                text.WriteLine("}");
                text.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            Console.WriteLine("Deseas imprimir Arbol?");
            String respuesta = Console.ReadLine().ToLower().Trim();
            if (respuesta.Equals("si"))
            {
                Genera_Arbol("ImagenJuego.txt", "C:/Users/mynor/OneDrive/Escritorio/JuegoAnimal");
            }
            Console.WriteLine("Su Arbol se imprimió correctamente...");

        }

        public static void Genera_Arbol(string fileName, string path)
        {


            try
            {
                var command = string.Format("dot -Tjpg {0} -o {1}", Path.Combine(path, fileName), Path.Combine(path, fileName.Replace(".txt", ".jpg")));
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/C " + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception x)
            {
                Console.WriteLine(x.ToString());
            }
        }



    }
}
