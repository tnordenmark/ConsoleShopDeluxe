using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShopDeluxe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Populate the shop storage with some test items
            ShopStorage storage = new ShopStorage(new Dictionary<Item, int>
            {
                { new Item("1001", "Juice", Category.Drinks, 24.90), 20 },
                { new Item("2001", "Bacon", Category.Meat, 12.90), 100 },
                { new Item("2002", "Sausage", Category.Meat, 29.90), 50 },
                { new Item("3001", "Potato Chips", Category.Snacks, 18.90), 150 },
                { new Item("4001", "Lettuce", Category.Vegetables, 14.50), 80 },
                { new Item("4002", "Tomato", Category.Vegetables, 21.90), 70 },
                { new Item("1002", "Beer", Category.Drinks, 12.50), 30 },
                { new Item("3002", "Cashew Nuts", Category.Snacks, 48.50), 55 },
                { new Item("2003", "Beef", Category.Meat, 129.90), 25 },
                { new Item("4003", "Cucumber", Category.Vegetables, 8.50), 40 },
                { new Item("1003", "Coffee", Category.Drinks, 39.90), 42 },
                { new Item("3003", "Popcorn", Category.Snacks, 8.90), 37 }
            }, 0);

            bool showMainMenu = true;

            do
            {
                Menu.ShowMenu();
                Console.Write("$: ");
                int choice = Menu.GetMainMenuChoice();
                bool showListItemMenu = true;

                switch (choice)
                {
                    case 1:
                        do
                        {
                            Menu.ShowListMenu();
                            Console.Write("$: ");
                            choice = Menu.GetListMenuChoice();

                            switch (choice)
                            {
                                case 1:
                                    Menu.PrintHeader();
                                    foreach (var kvp in storage.Sort(SortProp.price))
                                        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Menu.PrintHeader();
                                    foreach (var kvp in storage.Sort(SortProp.name))
                                        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    Menu.PrintHeader();
                                    foreach (var kvp in storage.Sort(SortProp.priceAndName))
                                        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    Menu.PrintHeader();
                                    foreach (var kvp in storage.Sort(SortProp.priceAndCategory))
                                        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    Console.WriteLine();
                                    break;
                                case 5:
                                    Menu.PrintHeader();
                                    foreach (var kvp in storage.Items)
                                        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    Console.WriteLine();
                                    break;
                                case 0:
                                    Console.Clear();
                                    showListItemMenu = false;
                                    break;
                                default:
                                    break;
                            }
                        } while (showListItemMenu != false);
                        break;
                    case 0:
                        Console.WriteLine("Press any key to exit application.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (showMainMenu != false);
        }
    }
}
