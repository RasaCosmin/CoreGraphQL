using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGraphQL.Models;

namespace CoreGraphQL.GraphQL
{
    public class DataStore : IDataStore
    {
        private ApplicationDbContext _applicationDbContext;

        public DataStore(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Item> AddItemAsync(Item item)
        {
            var addedItem = await _applicationDbContext.Items.AddAsync(item);
            await _applicationDbContext.SaveChangesAsync();
            return addedItem.Entity;
        }

        public Item GetItemByBarcode(string barcode)
        {
            return _applicationDbContext.Items.First(i => i.Barcode.Equals(barcode));
        }

        public IEnumerable<Item> GetItems()
        {
            return _applicationDbContext.Items;
        }
    }
}