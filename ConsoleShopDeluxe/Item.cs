using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShopDeluxe
{
    class Item : IEquatable<Item>, IComparable<Item>
    {
        public string PartNo { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }

        #region Constructor
        public Item(string pPartNo, string pName, Category pCategory, double pPrice)
        {
            PartNo = pPartNo;
            Name = pName;
            Category = pCategory;
            Price = pPrice;
        }
        #endregion

        #region Interface Implementations
        public bool Equals(Item other)
        {
            if(other == null)
                return false;

            if(this.PartNo == other.PartNo)
                return true;
            else
                return false;

            //return string.Compare(this.PartNo, other.PartNo, true) == 0;
        }

        public int CompareTo(Item other)
        {
            if(other == null)
                return 1;

            return Price.CompareTo(other.Price);
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return string.Format("{0,-6}{1,-20}{2,-12}{3,-12:C2}", PartNo, Name, Category, Price);
        }
        #endregion
    }

    public enum Category
    {
        Drinks,
        Snacks,
        Meat,
        Vegetables
    }

    public enum SortProp
    {
        price,
        name,
        priceAndName,
        priceAndCategory
    }
}