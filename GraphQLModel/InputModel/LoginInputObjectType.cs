using HotChoco.GprahQL.Jwt.Auth.Models;
using HotChocolate.Types;

namespace HotChoco.GprahQL.Jwt.Auth.GraphQLModel.InputModel
{
    public class LoginInputObjectType : InputObjectType<LoginInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<LoginInput> descriptor)
        {
            descriptor.Field(_ => _.Email).Type<StringType>().Name("Email");
            descriptor.Field(_ => _.Password).Type<StringType>().Name("Password");
        }
    }
}