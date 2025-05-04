using System;
using System.Collections.Generic;
using System.Linq;

namespace To_Do_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> todolist = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            do
            {
                Menu();
                command = Console.ReadLine();

                if (command == "1")
                {
                    Console.Write("Enter item to add: ");
                    string input = Console.ReadLine();
                    todolist.Add(input);
                    ReloadMenu(todolist);
                }
                else if (command == "2")
                {
                    Console.Write("Enter item to remove: ");
                    string input = Console.ReadLine();
                    try
                    {
                        Contains(todolist, input);
                        todolist.Remove(input);
                        ReloadMenu(todolist);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command != "end")
                {
                    Console.WriteLine("Invalid option. Try again.");
                }

            } while (command != "end");

            Console.WriteLine("Program ended.");
        }

        private static void Contains(List<string> todolist, string item)
        {
            if (!todolist.Contains(item))
            {
                throw new ArgumentException("This name is not valid in list!!!");
            }
        }

        private static void Menu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Remove");
            Console.WriteLine("Type 'end' to exit.");
            Console.Write("Select option: ");
        }

        private static void ReloadMenu(List<string> todolist)
        {
            Console.WriteLine("\nUPDATE LIST");
            foreach (string item in todolist)
            {
                Console.WriteLine($"-- {item}");
            }
        }
    }
}
