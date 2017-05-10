using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShopDeluxe
{
    public static class Menu
    {
        /// <summary>
        /// Main menu.
        /// </summary>
        internal static void ShowMenu()
        {
            Console.WriteLine("### Console Shop Deluxe ###");
            Console.WriteLine("1) List items");
            Console.WriteLine("2) Search items");
            Console.WriteLine("3) View cart");
            Console.WriteLine("4) Check out");
            Console.WriteLine("0) Exit");
        }

        /// <summary>
        /// List items sub menu.
        /// </summary>
        internal static void ShowListMenu()
        {
            Console.WriteLine("### List items by... ###");
            Console.WriteLine("1) Price");
            Console.WriteLine("2) Name");
            Console.WriteLine("3) Price and Name");
            Console.WriteLine("4) Price, grouped by Category");
            Console.WriteLine("5) Default order");
            Console.WriteLine("0) Back to Main");
        }

        /// <summary>
        /// Search item sub menu.
        /// </summary>
        internal static void ShowSearchMenu()
        {
            Console.WriteLine("### Search for  items by... ###");
            Console.WriteLine("1) Name");
            Console.WriteLine("2) Price higher than");
            Console.WriteLine("3) Price lower than");
            Console.WriteLine("4) Price and Name");
            Console.WriteLine("5) Price or Name from Category");
            Console.WriteLine("0) Back to Main");
        }

        /// <summary>
        /// Handle user input for Main menu.
        /// </summary>
        /// <returns></returns>
        internal static int GetMainMenuChoice()
        {
            string input = Console.ReadLine();
            int choice;

            if(!int.TryParse(input, out choice) && choice < 0 || choice > 4)
            {
                Console.WriteLine("Please enter a valid choice.\n");
            }
            return choice;
        }

        /// <summary>
        /// Handle user input for List items submenu.
        /// </summary>
        /// <returns></returns>
        internal static int GetListMenuChoice()
        {
            string input = Console.ReadLine();
            int choice;

            if(!int.TryParse(input, out choice) && choice < 0 || choice > 5)
            {
                Console.WriteLine("Please enter a valid choice.\n");
            }
            return choice;
        }

        /// <summary>
        /// Handle user input for Search menu.
        /// </summary>
        /// <returns></returns>
        internal static int GetSearchMenuChoice()
        {
            string input = Console.ReadLine();
            int choice;

            if(!int.TryParse(input, out choice) && choice < 0 || choice > 5)
            {
                Console.WriteLine("Please enter a valid choice.\n");
            }
            return choice;
        }

        /// <summary>
        /// Print product header.
        /// </summary>
        internal static void PrintHeader()
        {
            Console.WriteLine(string.Format("{0,-6}{1,-20}{2,-12}{3,-13}{4,-10}",
                                            "Part#", "Name", "Category", "Price", "Amount"));
            Console.WriteLine("---------------------------------------------------------");
        }
    }
}