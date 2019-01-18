using CoreGraphQL.Models;
using GraphQL.Types;

namespace CoreGraphQL.GraphQL
{
    public class InventoryQuery : ObjectGraphType
    {
        public InventoryQuery(IDataStore datastore)
        {
            Field<StringGraphType>(
                name: "hello",
                resolve: context => "world!!!"
            );

            Field<StringGraphType>(
                name: "howdy",
                resolve: context => "universe"
            );

            Field<ItemType>(
                "item",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "barcode" }),
                resolve: context =>
                {
                    var barcode = context.GetArgument<string>("barcode");
                    return datastore.GetItemByBarcode(barcode);
                }
            );

            Field<ListGraphType<ItemType>>(
                "items",
                resolve: context =>
                {
                    return datastore.GetItems();
                }
            );
        }
    }
}