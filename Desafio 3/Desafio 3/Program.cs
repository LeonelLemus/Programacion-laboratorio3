using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTareas
{
    class Program
    {
        static string[] tareas = new string[100];
        static int contadorTareas = 0; 

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                MostrarMenu();
                string opcion = Console.ReadLine().Trim();

                switch (opcion)
                {
                    case "1":
                        MostrarTareas();
                        break;
                    case "2":
                        AgregarTarea();
                        break;
                    case "3":
                        EliminarTarea();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("----- MENÚ -----");
            Console.WriteLine("1. Mostrar Tareas");
            Console.WriteLine("2. Agregar Tarea");
            Console.WriteLine("3. Eliminar Tarea");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
        }

        static void MostrarTareas()
        {
            Console.WriteLine("----- TAREAS -----");
            if (contadorTareas == 0)
            {
                Console.WriteLine("No hay tareas por realizar.");
            }
            else
            {
                for (int i = 0; i < contadorTareas; i++)
                {
                    Console.WriteLine((i + 1) + ". " + tareas[i]);
                }
            }
        }

        static void AgregarTarea()
        {
            Console.Write("Ingrese la nueva tarea: ");
            string nuevaTarea = Console.ReadLine();
            tareas[contadorTareas] = nuevaTarea;
            contadorTareas++;
            Console.WriteLine("Tarea agregada con éxito.");
        }

        static void EliminarTarea()
        {
            MostrarTareas();
            if (contadorTareas == 0)
            {
                return;
            }

            Console.Write("Ingrese el número de la tarea que desea eliminar: ");
            int indice;
            if (int.TryParse(Console.ReadLine(), out indice))
            {
                if (indice >= 1 && indice <= contadorTareas)
                {
                    for (int i = indice - 1; i < contadorTareas - 1; i++)
                    {
                        tareas[i] = tareas[i + 1];
                    }
                    contadorTareas--;
                    Console.WriteLine("Tarea eliminada con éxito.");
                }
                else
                {
                    Console.WriteLine("Número de tarea no válido.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Debe ingresar un número.");
            }
        }
    }
}