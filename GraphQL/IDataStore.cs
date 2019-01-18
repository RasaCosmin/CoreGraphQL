using System.Collections.Generic;
using System.Threading.Tasks;
using CoreGraphQL.Models;

namespace CoreGraphQL.GraphQL
{
    public interface IDataStore
    {
        IEnumerable<Item> GetItems();
        Item GetItemByBarcode(string barcode);

        Task<Item> AddItemAsync(Item item);
    }
}