using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; } = new List<string>();
        static void Main(string[] args)
        {
            
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the options for Task 
        /// </summary>
        /// <returns>Returns option selected by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                
                ShowTaskList();

                string taskNumberToDelete = Console.ReadLine();
                // Remove one position because the array starts in 0
                int indexToRemove = Convert.ToInt32(taskNumberToDelete) - 1;

                if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
                {
                    Console.WriteLine("Numero de tarea seleccionado no existe");
                }
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {                   
                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea {task} eliminada");                   
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea:");
                Console.WriteLine(ex.Message);
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al crear la tarea:");
                Console.WriteLine(ex.Message);
            }
        }

        public static void ShowMenuTaskList()
        {
            
            if (TaskList?.Count > 0)
            {
                ShowTaskList();
            } 
            else
            {
                Console.WriteLine("No hay tareas por realizar");
            }
        }

        public static void ShowTaskList()
        {
            Console.WriteLine("----------------------------------------");
            var indexTask = 1;                
            TaskList.ForEach(p=> Console.WriteLine($"{indexTask++} . {p}"));
            
            Console.WriteLine("----------------------------------------");
        }
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit  = 4      
    }
}
