using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShopDeluxe
{
    class ShopStorage : ItemStorage<Item>
    {
        #region Constructors
        public ShopStorage(Dictionary<Item, int> items, int id) : base(items, id)
        {
        }
        #endregion
    }
}
