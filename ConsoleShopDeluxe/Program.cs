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
            // Create a shopping cart object for later
            ShoppingCart cart = new ShoppingCart(new Dictionary<Item, int>(), 0);
            // Populate the shop storage with some test items
            ShopStorage storage = new ShopStorage(new Dictionary<Item, int>
            {
                { new Item("1001", "Juice", Category.Drinks, 24.90m), 20 },
                { new Item("2001", "Bacon", Category.Meat, 12.90m), 100 },
                { new Item("2002", "Sausage", Category.Meat, 29.90m), 50 },
                { new Item("3001", "Potato Chips", Category.Snacks, 18.90m), 150 },
                { new Item("4001", "Lettuce", Category.Vegetables, 14.50m), 80 },
                { new Item("4002", "Tomato", Category.Vegetables, 21.90m), 70 },
                { new Item("1002", "Beer", Category.Drinks, 12.50m), 30 },
                { new Item("3002", "Cashew Nuts", Category.Snacks, 48.50m), 55 },
                { new Item("2003", "Beef", Category.Meat, 129.90m), 25 },
                { new Item("4003", "Cucumber", Category.Vegetables, 8.50m), 40 },
                { new Item("1003", "Coffee", Category.Drinks, 39.90m), 42 },
                { new Item("3003", "Popcorn", Category.Snacks, 8.90m), 37 }
            }, 0);

            // Show Main menu unless false
            bool showMainMenu = true;

            // Main menu
            do
            {
                Menu.ShowMenu();
                Console.Write("$: ");
                int choice = Menu.GetMainMenuChoice();
                // Show sub menu unless false
                bool showSubMenu = true;

                switch(choice)
                {
                    case 1:
                        // List sub menu
                        do
                        {
                            Menu.ShowListMenu();
                            Console.Write("$: ");
                            choice = Menu.GetListMenuChoice();

                            switch(choice)
                            {
                                case 1:
                                    Menu.PrintHeader();
                                    foreach(var kvp in storage.Sort(SortProp.price))
                                        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    Console.WriteLine("Enter 1 - 3 part numbers separated by space to add to cart.");
                                    Console.Write("Part #: ");
                                    string partNo = Console.ReadLine();
                                    string partOne = partNo.Substring(0, 4);
                                    string partTwo = partNo.Substring(5, 4);
                                    string partThree = partNo.Substring(10, 4);
                                    // Do some shizzle manizzle with partOne, partTwo and partThree
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Menu.PrintHeader();
                                    foreach(var kvp in storage.Sort(SortProp.name))
                                        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    Menu.PrintHeader();
                                    foreach(var kvp in storage.Sort(SortProp.priceAndName))
                                        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    Menu.PrintHeader();
                                    foreach(var kvp in storage.Sort(SortProp.priceAndCategory))
                                        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    Console.WriteLine();
                                    break;
                                case 5:
                                    Menu.PrintHeader();
                                    foreach(var kvp in storage.Items)
                                        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    Console.WriteLine();
                                    break;
                                case 0:
                                    Console.Clear();
                                    showSubMenu = false;
                                    break;
                                default:
                                    break;
                            }
                        } while(showSubMenu != false);
                        break; // List sub menu end
                    case 2:
                        // Search sub menu
                        do
                        {
                            Menu.ShowSearchMenu();
                            Console.Write("$: ");
                            choice = Menu.GetSearchMenuChoice();

                            switch(choice)
                            {
                                case 1:
                                    Console.Write("Name of item: ");
                                    string input = Console.ReadLine();
                                    Menu.PrintHeader();
                                    
                                    foreach(var kvp in storage.Search(SearchProp.name, input))
                                        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Console.Write("Price of item: ");
                                    input = Console.ReadLine();
                                    decimal price;
                                    
                                    if(decimal.TryParse(input, out price))
                                    {
                                        foreach(var kvp in storage.Search(SearchProp.priceHigher, "", price))
                                            Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    }
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    Console.Write("Price of item: ");
                                    input = Console.ReadLine();

                                    if(decimal.TryParse(input, out price))
                                    {
                                        foreach(var kvp in storage.Search(SearchProp.priceLower, "", price))
                                            Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    }
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    Console.Write("Name of item: ");
                                    input = Console.ReadLine();
                                    Console.Write("Price lower than: ");
                                    string priceInput;
                                    priceInput = Console.ReadLine();

                                    if(decimal.TryParse(priceInput, out price))
                                    {
                                        var result = storage.Search(SearchProp.priceAndName, input, price);

                                        if(result.Count() == 0)
                                            Console.WriteLine("No match found.");
                                        else
                                            foreach(var kvp in result)
                                            {
                                                Menu.PrintHeader();
                                                Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                            }
                                    }
                                    Console.WriteLine();
                                    break;
                                case 5:
                                    // Print available categories from Enum
                                    Console.Write("Available categories: ");
                                    Console.WriteLine("{0}, {1}, {2}, {3}",
                                        Enum.GetName(typeof(Category), 0),
                                        Enum.GetName(typeof(Category), 1),
                                        Enum.GetName(typeof(Category), 2),
                                        Enum.GetName(typeof(Category), 3));
                                    
                                    Console.Write("Category: ");
                                    string catInput = Console.ReadLine();
                                    Console.Write("Name or price? (n/p): ");
                                    string nameOrPrice = Console.ReadLine();

                                    // Search for name or price within the category
                                    if(nameOrPrice[0] == 'n')
                                    {
                                        Console.Write("Name of item: ");
                                        input = Console.ReadLine();
                                        foreach(var kvp in storage.Search(SearchProp.nameByCategory, input, 0, catInput))
                                            Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                    }
                                    else if(nameOrPrice[0] == 'p')
                                    {
                                        Console.Write("Price lower than: ");
                                        priceInput = Console.ReadLine();

                                        if(decimal.TryParse(priceInput, out price))
                                        {
                                            foreach(var kvp in storage.Search(SearchProp.priceByCategory, "", price, catInput))
                                                Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                                        }
                                    }
                                    else
                                        Console.WriteLine("Please input 'n' or 'p' fool.");
                                    Console.WriteLine();
                                    break;
                                case 0:
                                    Console.Clear();
                                    showSubMenu = false;
                                    break;
                                default:
                                    break;
                            }
                        } while(showSubMenu != false);
                        break; // Search sub menu end
                    case 3:
                        break;
                    case 4:
                        break;
                    case 0:
                        Console.WriteLine("Press any key to exit application.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while(showMainMenu != false);
        }
    }
}
