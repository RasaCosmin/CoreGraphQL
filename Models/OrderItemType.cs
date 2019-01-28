using CoreGraphQL.GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGraphQL.Models
{
    public class OrderItemType: ObjectGraphType<OrderItem>
    {
        public OrderItemType(IDataStore dataStore)
        {
            Field(i => i.ItemId);
            Field<ItemType, Item>()
                .Name("Item")
                .ResolveAsync(ctx =>
                {
                    return dataStore.GetItemByIdAsync(ctx.Source.ItemId);
                });
            Field(i => i.Quantity);
            Field(i => i.OrderId);
            Field<OrderType, Order>()
                .Name("Order")
                .ResolveAsync(ctx =>
                {
                    return dataStore.GetOrderByIdAsync(ctx.Source.OrderId);
                });
        }
    }
}
