using GraphQL.Types;

namespace CoreGraphQL.GraphQL
{
    public class InventorySchema : Schema
    {
        public InventorySchema(InventoryQuery query, InventoryMutation mutation)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}