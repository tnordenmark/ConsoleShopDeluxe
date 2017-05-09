using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShopDeluxe
{
    class ShoppingCart : ItemStorage<Item>
    {
        #region Constructor
        public ShoppingCart(Dictionary<Item, int> items, int id) : base(items, id)
        {
        }
        #endregion

        protected internal void Checkout()
        {
            // Code for checkout
        }

        protected internal void GetReceipt()
        {

        }
    }
}
