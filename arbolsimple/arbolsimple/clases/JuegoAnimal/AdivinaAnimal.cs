using arbolsimple.clases.ArbolBinario;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace arbolsimple.clases.JuegoAnimal
{
    class AdivinaAnimal
    {

        private static Nodo raiz;

        public AdivinaAnimal()
        {
            
            raiz = new Nodo("Elefante");
            

        }

        public void jugar()
        {

            Nodo nodo = raiz;


            while (nodo != null)// Interacion del arbol
            {
                if (nodo.izquierda != null)//Existe una pregunta
                {
                    Console.WriteLine(nodo.valorNodo());

                    nodo = (respuesta()) ? nodo.izquierda : nodo.derecha;

                }

                else
                {
                    Console.WriteLine($"Ya se, es un {nodo.valorNodo()}?");
                    if (respuesta())
                    {
                        Console.WriteLine("Gane!! :)");

                       
                    }
                    else {
                        animalNuevo(nodo);
                    }
                    nodo = null;
                    return;
                }//fin if

            }//fin while
        }//fin jugar

        public bool respuesta()
        {
            while (true)
            {
                String resp = Console.ReadLine().ToLower().Trim();
                if (resp.Equals("si")) return true;
                if (resp.Equals("no")) return false;
                Console.WriteLine("La respuesta debe ser si o no");
            }
        }// fin respuesta

        private void animalNuevo(Nodo nodo)
        {
            StreamWriter text = File.AppendText("\\Users\\mynor\\OneDrive\\Escritorio\\JuegoAnimal\\Juego.txt");
            String animalNodo = (String)nodo.valorNodo();
            Console.WriteLine("Cual es el animal que pensaste?");
            String nuevoA = Console.ReadLine();

            Console.WriteLine($"Que pregunta con respuesta si / no puedo hacer para decir que es un(a) {nuevoA} ?");
            string pregunta = Console.ReadLine();

            Nodo nodo1 = new Nodo(animalNodo);

            Nodo nodo2 = new Nodo(nuevoA);
           

            Console.WriteLine(pregunta + $" Para un(a) {nuevoA} la respuesta es si /no ?");


            nodo.nuevoValor("tu animal " + pregunta + "?");

            if (respuesta())
            {

                nodo.izquierda = nodo2;
                nodo.derecha = nodo1;

            }
            else
            {
                nodo.izquierda = nodo1;
                nodo.derecha = nodo2;

            }


            text.WriteLine("Animales->"+ pregunta);
            text.WriteLine(pregunta + "->"+ nuevoA);
            text.Close();


        }// fin de AnimalNuevo

    }
}
