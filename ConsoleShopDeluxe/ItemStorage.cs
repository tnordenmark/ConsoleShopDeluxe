using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShopDeluxe
{
    class ItemStorage<T> : IEnumerable<T>
    {
        #region Values
        //private Dictionary<Item, int> items = new Dictionary<Item, int>();
        private Dictionary<Item, int> items = new Dictionary<Item, int>();
        public int ID { get; set; }
        #endregion

        #region Properties
        public Dictionary<Item, int> Items
        {
            get { return items; }
            set { items = value; }
        }
        #endregion

        #region Methods
        public void AddItem(Item item)
        {
            if(Items.ContainsKey(item))
                Items[item] += 1;
            else
                Items.Add(item, 1);
        }
        #endregion

        #region Constructors
        public ItemStorage() { }
        public ItemStorage(Dictionary<Item, int> items, int id)
        {
            this.Items = items;
            ID = id;
        }
        #endregion

        #region Interface Implementations
        public IEnumerator<T> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
