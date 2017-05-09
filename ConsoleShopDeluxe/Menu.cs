using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShopDeluxe
{
    public static class Menu
    {
        // Show main menu
        public static void ShowMenu()
        {
            Console.WriteLine("### Console Shop Deluxe ###");
            Console.WriteLine("1) List items");
            Console.WriteLine("2) Search items");
            Console.WriteLine("3) View cart");
            Console.WriteLine("4) Check out");
            Console.WriteLine("0) Exit\n");
        }

        // Submenu for the Run test option
        public static void ShowListMenu()
        {
            Console.WriteLine("### List items by... ###");
            Console.WriteLine("1) Price");
            Console.WriteLine("2) Name");
            Console.WriteLine("3) Price and Name");
            Console.WriteLine("4) Price, grouped by Category");
        }

        // Handle user main menu choice
        public static int GetMainMenuChoice()
        {
            string input = Console.ReadLine();
            int choice;

            if(!int.TryParse(input, out choice) && choice < 0 || choice > 4)
            {
                Console.WriteLine("Please enter a valid choice.\n");
            }
            return choice;
        }

        // Handle user input for List items submenu
        public static int GetListMenuChoice()
        {
            string input = Console.ReadLine();
            int choice;

            if(!int.TryParse(input, out choice) && choice < 1 || choice > 4)
            {
                Console.WriteLine("Please enter a valid choice.\n");
            }
            return choice;
        }
    }
}