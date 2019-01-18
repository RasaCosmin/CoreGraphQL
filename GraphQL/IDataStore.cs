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
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Order> AddOrderAsync(Order order);

        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<Order>> GetOrdersByCustomerIDAsunc(int customerId);
    }
}