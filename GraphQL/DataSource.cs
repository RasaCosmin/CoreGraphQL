using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoreGraphQL.Models;

namespace CoreGraphQL.GraphQL
{
    public class DataSource
    {
        public IList<Item> Items { get; set; }

        public DataSource()
        {
            Items = new List<Item>(){
                new Item { Barcode = "123", Title = "Headphone", SellingPrice= 50},
                new Item { Barcode = "456", Title = "Keyboard", SellingPrice= 20},
                new Item { Barcode = "789", Title = "Monitor", SellingPrice= 150}
            };
        }

        public Item GetItemByBarcode(string barcode)
        {
            return Items.First(i => i.Barcode.Equals(barcode));
        }
    }
}