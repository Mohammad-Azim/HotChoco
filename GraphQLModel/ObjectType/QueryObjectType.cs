using HotChoco.GprahQL.Jwt.Auth.GraphQLCore;
using HotChocolate.Types;

namespace HotChoco.GprahQL.Jwt.Auth.GraphQLModel.ObjectType
{
    public class QueryObjectType : HotChocolate.Types.ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(_ => _.Welcome()).Name("Welcome").Type<StringType>();
        }
    }
}