using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Lista_Doble_Circular
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista l = new Lista();
            int opcionMenu = 0;
            do
            {
                Console.WriteLine("\n |-----------------------------------|");
                Console.WriteLine("\n |      °LISTA CIRCULAR DOBLE°       |");
                Console.WriteLine("\n |-----------------|-----------------|");
                Console.WriteLine("\n | 1. Agregar      | 5. Desplegar lst|");
                Console.WriteLine("\n | 2. Buscar       | 6. Cargar       |");
                Console.WriteLine("\n | 3. Modificar    | 7. Salir        |");
                Console.WriteLine("\n | 4. Eliminar     |                 |");
                Console.WriteLine("\n |-----------------|-----------------|");
                Console.Write(" Escoja una Opcion: ");
                opcionMenu = int.Parse(Console.ReadLine());
                switch (opcionMenu)
                {
                    case 1:
                        Console.WriteLine("\n\n AGREGAR NODO EN LA LISTA \n");
                        int numero = int.Parse(Console.ReadLine());
                        string nombre = Console.ReadLine();
                        Nodo n = new Nodo(numero);
                        l.agregarNodo(n);
                        l.Guardar();
                        break;
                    case 2:
                        Console.WriteLine("\n\n BUSCAR UN NODO EN LA LISTA \n");
                        l.buscarNodo();
                        break;
                    case 3:
                        Console.WriteLine("\n\n MODIFICAR UN NODO EN LA LISTA \n");
                        l.modificarNodo();
                        break;
                    case 4:
                        Console.WriteLine("\n\n ELIMINAR UN NODO EN LA LISTA \n");
                        int d = int.Parse(Console.ReadLine());
                        l.eliminarNodo(d);
                        break;
                    case 5:
                        Console.WriteLine("\n\n DESPLEGAR LISTA DE NODOS DEL PRIMERO AL ULTIMO \n");
                        l.desplegarListaPU();
                        break;
                    case 6:
                        l.Cargar("ListaDobleCircular");
                        Console.WriteLine(l.ToString());
                        Console.WriteLine("\n\n Nodos Cargados \n");
                        break;
                    case 7:
                        Console.WriteLine("\n\n Opcion no valida \n");
                        break;


                    default:
                        break;
                }
            } while (opcionMenu !=7);
           
          
        }
    }
}
