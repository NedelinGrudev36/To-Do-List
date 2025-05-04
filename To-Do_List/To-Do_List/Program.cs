using System;
using System.Collections.Generic;
using System.Linq;

namespace To_Do_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter items in To-Do List");
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
                    string input = Console.ReadLine().ToLower();
                    todolist.Add(input);
                    ListItem(todolist);
                }
                else if (command == "2")
                {
                    Console.Write("Enter item to remove: ");
                    string input = Console.ReadLine().ToLower();
                    
                    Contains(todolist, input);
                    todolist.Remove(input);
                    ListItem(todolist);
                }
                else if (command == "3")
                {
                    Console.Write("Select item as completed: ");
                    string input = Console.ReadLine().ToLower();
                    SetColorProperty(todolist, input);
                }

            } while (command != "end");

            Console.WriteLine("Program ended.");
        }

        private static void SetColorProperty(List<string> todolist, string input)
        {
            Console.WriteLine("\nUPDATE LIST");
            foreach (var item in todolist)
            {
                if (item == input)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"-- {item}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"-- {item}");
                }
                Console.ResetColor();
            }
        }

        private static void Contains(List<string> todolist, string item)
        {
            if (!todolist.Contains(item))
            {
                Console.WriteLine("This name is not valid in list!!!"); 
            }
        }

        private static void Menu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Remove");
            Console.WriteLine("3. Completed");
            Console.WriteLine("Type 'end' to exit.");
            Console.Write("Select option: ");
        }

        private static void ListItem(List<string> todolist)
        {
            Console.WriteLine("\nUPDATE LIST");
            foreach (string item in todolist)
            {
                Console.WriteLine($"-- {item}");
            }
        }
    }
}
