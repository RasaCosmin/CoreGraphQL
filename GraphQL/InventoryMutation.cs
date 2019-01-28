using CoreGraphQL.Models;
using GraphQL.Types;

namespace CoreGraphQL.GraphQL
{
    public class InventoryMutation : ObjectGraphType
    {
        public InventoryMutation(IDataStore store)
        {
            Field<ItemType, Item>()
                .Name("createItem")
                .Argument <NonNullGraphType<ItemInputType>>("item", "item input")
                .ResolveAsync(ctx =>                 {
                    var item = ctx.GetArgument<Item>("item");
                    return store.AddItemAsync(item);
                }
            );

            Field<OrderType, Order>()
                .Name("createOrder")
                .Argument<NonNullGraphType<OrderInputType>>("order", "order input")
                .ResolveAsync(ctx =>
                {
                    var order = ctx.GetArgument<Order>("order");
                    return store.AddOrderAsync(order);
                });

            Field<CustomerType, Customer>()
                .Name("createCustomer")
                .Argument<NonNullGraphType<CustomerInputType>>("customer", "customer input")
                .ResolveAsync(ctx =>
                {
                    var customer = ctx.GetArgument<Customer>("customer");
                    return store.AddCustomerAsync(customer);
                });

            Field<OrderItemType, OrderItem>()
            .Name("addOrderItem")
            .Argument<NonNullGraphType<OrderItemInputType>>("orderitem", "orderitem input")
            .ResolveAsync(ctx =>
            {
                var orderItem = ctx.GetArgument<OrderItem>("orderitem");
                return store.AddOrderItemAsync(orderItem);
            });
        }
    }
}