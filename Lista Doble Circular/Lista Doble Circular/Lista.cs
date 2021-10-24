using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lista_Doble_Circular
{
    class Lista
    {
     
        private Nodo head;

        public Nodo Head
        {
            get { return head; }
            set { head = value; }
        }


        public Lista()
        {
            head = null;
        }


        public void agregarNodo(Nodo nuevo)
        {

            if (head == null)
            {
                nuevo.siguiente = nuevo;
                nuevo.anterior = nuevo;
                head = nuevo;
                return;
            }
            Nodo h = head;
            if (nuevo.dato < head.dato)
            {
                nuevo.siguiente = head;
                nuevo.siguiente.anterior = nuevo;
                while (h.siguiente != head)
                {
                    h = h.siguiente;
                }
                h.siguiente = nuevo;
                h.siguiente.anterior = head;
                head = nuevo;
                return;
            }
            while (h.siguiente != head)
            {
                if (nuevo.dato < h.siguiente.dato)
                {
                    break;
                }
                h = h.siguiente;
            }
            nuevo.siguiente = h.siguiente;
            nuevo.anterior = h;
            h.siguiente = nuevo;
            if (h.siguiente.siguiente.anterior != head)
            {
                h.siguiente.siguiente.anterior = nuevo;
            }
            
        }

        public void buscarNodo()
        {
            Nodo h = head;
            bool encontrado = false;
            Console.Write(" Ingrese el dato del nodo a buscar: ");
            int nodoBuscado = int.Parse(Console.ReadLine());
            if (h != null)
            {
                do
                {
                    if (h.dato == nodoBuscado)
                    {
                        Console.WriteLine("\n Nodo con el Numero ({0}) Encontrado\n", h.dato );
                        Console.WriteLine("\n Nombre Encontrado ({0} )\n", h.nombre);
                        encontrado = true;
                    }
                    h = h.siguiente;
                } while (h  != head && encontrado != true);
                if (!encontrado)
                {
                    Console.WriteLine("\n Nodo no encontrado\n");
                }
            }
            else
            {
                Console.WriteLine("\n La lista se encuentra vacia\n");
            }
        }

        public void modificarNodo()
        {
            Nodo h = head;
            bool encontrado = false;
            Console.Write(" Ingrese el dato del nodo a Modificar: ");
            int nodoBuscado = int.Parse(Console.ReadLine());
            if (h != null)
            {
                do
                {
                    if (h.dato == nodoBuscado)
                    {
                        Console.WriteLine("\n Nodo con el dato ({0}) Encontrado\n", h.dato);
                        Console.Write(" Ingrese el nuevo dato para este nodo: ");
                        h.nombre = (Console.ReadLine());
                        Console.WriteLine("\n Nodo modificado con exito");
                        encontrado = true;
                    }
                    h = h.siguiente;
                } while (h != head && encontrado != true);
                if (!encontrado)
                {
                    Console.WriteLine("\n Nodo no encontrado\n");
                }
            }
            else
            {
                Console.WriteLine("\n La lista se encuentra vacia\n");
            }
        }

        public void eliminarNodo(int d)
        {
            if (head == null)
            {
                return;
            }
            Nodo h = head;
            if (head.dato == d)
            {
                if (head.siguiente == head)
                {
                    head = null;
                    return;
                }
                while (h.siguiente != head)
                {
                    h.anterior = h;
                    h = h.siguiente;
                }
                h.anterior = head;
                h.siguiente = head.siguiente;
                head.anterior = head;
                head = head.siguiente;
                return;
            }

            while (h.siguiente != head)
            {
                if (h.siguiente.dato == d)
                {
                    break;
                }
                h.anterior = h;
                h = h.siguiente;
            }
            if (h.siguiente != head)
            {
                h.anterior = h.siguiente;
                h.siguiente = h.siguiente.siguiente;
            }
        }


        public void desplegarListaPU()
        {
            Nodo h = head;            
            if (h != null)
            {
                do
                {
                    Console.WriteLine(" " + h.dato + " " + h.nombre );
                    h = h.siguiente;
                } while (h != head);
            }
            else
            {
                Console.WriteLine("\n La lista se encuentra vacia\n");
            }
        }
        public void Guardar()
        {
            Nodo h = head;
            if (head == null)
            {
                return;
            }
            string path = @"D:\ListaDobleCircular.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                do
                {
                    sw.WriteLine(h.dato + " " + h.nombre);
                    h = h.siguiente;
                } while (h != head);
            }
            return;
        }
        public void Cargar(string nombreArchivo)
        {
            nombreArchivo = "ListaDobleCircular";
            string[] lineas = File.ReadAllLines(@"D:\"+ nombreArchivo + ".txt");
            foreach (string linea in lineas)
            {
                if (linea.Length == 0)
                {
                    continue;
                }
                string[] datos = linea.Split('-');
                int dato = int.Parse(datos[0]);
                string nombre = datos[1];
                Nodo n = new Nodo(dato,nombre);
                agregarNodo(n);
            }
        }
        public override string ToString()
        {
            string lista = "Nodos:\n ";
            Nodo h = head;
            if (head == null)
            {
                return lista;
            }
            do
            {
                lista += h.dato + h.nombre + "\n ";
                h = h.siguiente;
            } while (h != head);
            return lista;
        }
    }
}
