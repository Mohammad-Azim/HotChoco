//using HotChoco.GprahQL.Jwt.Auth.GraphQLCore;
using HotChoco.GprahQL.Jwt.Auth.GraphQLModel.InputModel;
using HotChoco.GprahQL.Mutations;
using HotChocolate.Types;

namespace HotChoco.GprahQL.Jwt.Auth.GraphQLModel.ObjectType
{
    public class MutationObjectType : HotChocolate.Types.ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(_ => _.UserLogin(default, default))
            .Type<StringType>()
            .Name("UserLogin")
            .Argument("login", a => a.Type<LoginInputObjectType>());
        }
    }
}