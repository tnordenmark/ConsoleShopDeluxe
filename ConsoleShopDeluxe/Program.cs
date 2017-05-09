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
            ItemStorage<Item> storage = new ItemStorage<Item>();
            int choice;

            Item item = new Item("1001", "Juice", Category.Drinks, 24.90);
            Item item2 = new Item("2001", "Bacon", Category.Meat, 12.90);
            Item item3 = new Item("2002", "Sausage", Category.Meat, 29.90);
            Item item4 = new Item("2001", "Bacon", Category.Meat, 12.90);
            
            storage.AddItem(item);
            storage.AddItem(item2);
            storage.AddItem(item3);
            storage.AddItem(item4);

            

            do{
                Menu.ShowMenu();
                Console.Write("#: ");
                choice = Menu.GetMainMenuChoice();
                
                switch(choice)
                {
                    case 1:
                        Menu.ShowListMenu();
                        Console.WriteLine("#: ");
                        choice = Menu.GetListMenuChoice();
                        switch(choice)
                        {
                            case 1:
                                foreach(KeyValuePair<Item, int> kvp in storage.Items)
                                    Console.WriteLine("Part #: {0} | Name: {1}", kvp.Key.PartNo, kvp.Key.Name, kvp.Key.Category, kvp.Key.Price, kvp.Value);
                                
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            default:
                                break;
                        }
                        break;
                    case 0:
                        Console.WriteLine("Press any key to exit application.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while(choice != 0);
        }
    }
}
