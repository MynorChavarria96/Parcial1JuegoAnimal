using arbolsimple.clases.ArbolBinario;
using arbolsimple.clases.JuegoAnimal;
using System;
using System.Collections;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace arbolsimple
{
    class Program
    {



        public static void imprimir(Nodo r)
        {

            if (r != null)
            {
                r.visitar();
                imprimir(r.subarbolDerecho());
                imprimir(r.subarbolIzquierdo());
            }
        }




        
        public static void preorden(Nodo r)
        {
            if (r != null)
            {
                r.visitar();
                preorden(r.subarbolIzquierdo());
                preorden(r.subarbolDerecho());

            }

        }

        

        public static void indorden(Nodo r)
        {
            if (r != null)
            {
                indorden(r.subarbolIzquierdo());
                r.visitar();
                indorden(r.subarbolDerecho());
            }
        }

        public static void postorden(Nodo r)
        {
            if (r != null)
            {
                postorden(r.subarbolIzquierdo());
                postorden(r.subarbolDerecho());
                r.visitar();
            }
        }

        public static void arbolBasico()
        {
            try
            {
                ArbolBinario arbol;
                Nodo a1, a2, a;
                Stack pila = new Stack();
                a1 = ArbolBinario.nuevoArbol(null, "Maria", null);
                a2 = ArbolBinario.nuevoArbol(null, "Fabrizio", null);
                a = ArbolBinario.nuevoArbol(a1, "Gaby", a2);

                pila.Push(a);//Aplilar

                a1 = ArbolBinario.nuevoArbol(null, "Andrea", null);
                a2 = ArbolBinario.nuevoArbol(null, "Abel", null);
                a = ArbolBinario.nuevoArbol(a1, "Monica", a2);
              
                pila.Push(a);//Apilar


                a2 = (Nodo)pila.Pop();
                a1 = (Nodo)pila.Pop();

                //a = ArbolBinario.nuevoArbol(a1, "Hector", a2);
                arbol = new ArbolBinario(a);
                



                imprimir(a);
                
                Console.WriteLine();

                //Console.WriteLine("Preorden");
                //preorden(a);
                //Console.WriteLine();

                //Console.WriteLine("Postorden");
                //postorden(a);
                //Console.WriteLine();
                //Console.WriteLine("inorden");
                //indorden(a);
                //Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ups hubo un error" + ex.Message);
            }

        }













        static void juegoAnimales()
        {
            Boolean otroJuego = true;

            AdivinaAnimal juego = new AdivinaAnimal();
           ImprimeArbol imprime = new ImprimeArbol();


            Console.WriteLine("Juguemos a adivinar animales?  si /no");
            String resp = Console.ReadLine().ToLower().Trim();
            if (resp.Equals("si")) {
                
                do
                {
                    juego.jugar();
                   
                  
                    Console.WriteLine("\nJugamos otra vez?");
                    Console.WriteLine("Responde usando si / no");
                    otroJuego = juego.respuesta();

                } while (otroJuego);
            }

            imprime.imagen();

        }

        


        static void Main(string[] args)
        {
           
            juegoAnimales();
           



        }
    }
}
