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
                .Trim()
                .ToLower()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command, input;
            do
            {
                Menu();
                command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        Console.Write("Enter item to add: ");
                        input = Console.ReadLine().ToLower();
                        todolist.Add(input);
                        ListItem(todolist);
                        break;
                    case "2":
                        Console.Write("Enter item to remove: ");
                        input = Console.ReadLine().ToLower();

                        Contains(todolist, input);
                        todolist.Remove(input);
                        ListItem(todolist);
                        break;
                    case "3":
                        Console.Write("Select item as completed: ");
                        input = Console.ReadLine().ToLower();
                        SetColorProperty(todolist, input);
                        break;   
                }
            } while (command != "end");

            Console.WriteLine("Program ended.");
        }

        private static void SetColorProperty(List<string> todolist, string input)
        {
            Console.WriteLine(Environment.NewLine + "UPDATE LIST");
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
            Console.WriteLine(Environment.NewLine + "Menu:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Remove");
            Console.WriteLine("3. Completed");
            Console.WriteLine("Type 'end' to exit.");
            Console.Write("Select option: ");
        }

        private static void ListItem(List<string> todolist)
        {
            Console.WriteLine(Environment.NewLine + "UPDATE LIST");
            foreach (string item in todolist)
            {
                Console.WriteLine($"-- {item}");
            }
        }
    }
}
