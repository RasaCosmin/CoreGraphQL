using CoreGraphQL.Models;
using GraphQL.Types;

namespace CoreGraphQL.GraphQL
{
    public class InventoryMutation : ObjectGraphType
    {
        public InventoryMutation(IDataStore store)
        {
            Field<ItemType>(
                "createItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ItemInputType>> { Name = "item" }
                ),
                resolve: context =>
                {
                    var item = context.GetArgument<Item>("item");
                    return store.AddItemAsync(item);
                }
            );
        }
    }
}