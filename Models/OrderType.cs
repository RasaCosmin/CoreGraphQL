using CoreGraphQL.GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGraphQL.Models
{
    public class OrderType: ObjectGraphType<Order>
    {
        public OrderType(IDataStore dataStore)
        {
            Field(o => o.Tag);
            Field(o => o.CreatedAt);
            Field<CustomerType, Customer>()
                .Name("Customer")
                .ResolveAsync(ctx =>
                {
                    return dataStore.GetCustomerByIdAsync(ctx.Source.CustomerId);
                });
        }
    }
}
