using WebApplication1.Services;

namespace WebApplication1.Schema;

public class QueryType : ObjectType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Name(OperationTypeNames.Query);

        descriptor
            .Field("user")
            .Argument("username", a => a.Type<NonNullType<StringType>>())
            .Resolve(async context =>
            {
                var username = context.ArgumentValue<string>("username");
                var service = context.Services.GetService<IUserService>();
                if (service == null)
                {
                    return new Error("Invalid Service");
                }
                return await service.GetUser(username);
            }).Type<UserType.UserType>();
    }
}





