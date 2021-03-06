﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShopDeluxe
{
    class ItemStorage<T> : IEnumerable<T>
    {
        #region Values
        protected Dictionary<Item, int> items = null;
        protected int ID { get; set; }
        #endregion

        #region Properties
        public Dictionary<Item, int> Items
        {
            get { return items; }
            private set { items = value; }
        }
        #endregion

        #region Methods
        protected internal void AddItem(Item item)
        {
            if(items.ContainsKey(item))
            {
                items[item] += 1;
            }
            else
            {
                items.Add(item, 1);
            }
        }

        protected internal Item GetItemByPartNo(string pPartNo)
        {
            Item result = null;

            foreach(Item item in items.Keys)
            {
                if(item.PartNo == pPartNo)
                {
                    result = item;
                }
            }
            return result;
        }

        protected internal virtual Item RemoveItem(Item item)
        {
            Item result = null;

            if(items.ContainsKey(item) && items[item] > 0)
            {
                items[item] -= 1;
                result = item;
            }

            return result;
        }

        public IEnumerable<KeyValuePair<Item, int>> Sort(SortProp pSortProp)
        {
            Dictionary<Item, int> sorted = new Dictionary<Item, int>(items);

            switch(pSortProp)
            {
                case SortProp.price:
                    return sorted.OrderBy(price => price.Key.Price);
                case SortProp.name:
                    return from kvp in sorted
                           orderby kvp.Key.Name
                           select kvp;
                case SortProp.priceAndName:
                    return sorted.OrderBy(price => price.Key.Price).ThenBy(name => name.Key.Name);
                case SortProp.priceAndCategory:
                    return (from kvp in sorted
                            orderby kvp.Key.Price
                            group kvp by kvp.Key.Category into catGroup
                            select catGroup).SelectMany(cat => cat);
                default:
                    break;
            }

            return sorted;
        }

        public IEnumerable<KeyValuePair<Item, int>> Search(SearchProp pSearchProp, string pName, decimal pPrice = 0, string pCategory = "")
        {
            switch(pSearchProp)
            {
                case SearchProp.name:
                    return from kvp in items
                           where kvp.Key.Name.Contains(pName)
                           orderby kvp.Key.Name
                           select kvp;
                case SearchProp.priceHigher:
                    return from kvp in items
                           where pPrice < kvp.Key.Price
                           orderby kvp.Key.Price
                           select kvp;
                case SearchProp.priceLower:
                    return from kvp in items
                           where pPrice > kvp.Key.Price
                           orderby kvp.Key.Price
                           select kvp;
                case SearchProp.priceAndName:
                    return from kvp in items
                           where (kvp.Key.Name.Contains(pName) &&
                                 (kvp.Key.Price < pPrice))
                                 orderby kvp.Key.Price
                           select kvp;
                case SearchProp.nameByCategory:
                    return from kvp in items
                           where kvp.Key.Category.ToString() == pCategory &&
                           kvp.Key.Name.Contains(pName)
                           select kvp;
                case SearchProp.priceByCategory:
                    return from kvp in items
                               where (kvp.Key.Category.ToString() == pCategory &&
                                      kvp.Key.Price < pPrice)
                                      select kvp;
                default:
                    break;
            }

            return Enumerable.Empty<KeyValuePair<Item, int>>();
        }
        #endregion

        #region Constructors
        public ItemStorage(Dictionary<Item, int> items, int id)
        {
            Items = items;
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