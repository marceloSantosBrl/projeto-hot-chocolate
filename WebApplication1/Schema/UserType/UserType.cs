using WebApplication1.Services;

namespace WebApplication1.Schema.UserType;

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Field(f => f.Id);
        descriptor.Field(f => f.Username);
        descriptor.Field(f => f.Email);
        
        descriptor.Field(f => f.Comments)
            .Resolve(async context =>
            {
                var user = context.Parent<User>();
                var service = context.Services.GetService<IUserService>();
                if (service == null)
                {
                    return new Error("Falha ao injetar");
                }

                return await service.GetUserComments(user);
            })
            .Type<ListType<CommentType.CommentType>>();
        
        descriptor.Field(f => f.Posts)
            .Resolve(async context =>
            {
                var parent = context.Parent<User>();
                var service = context.Services.GetService<IUserService>();
                if (service == null)
                {
                    return new Error("Falha ao injetar");
                }

                return await service.GetPosts(parent);
            })
            .Type<ListType<PostType.PostType>>();
        
        descriptor.Field(f => f.Followers)
            .Resolve(async context =>
            {
                var parent = context.Parent<User>();
                var service = context.Services.GetService<IUserService>();
                if (service == null)
                {
                    return new Error("Falha ao injetar");
                }

                return await service.GetFollowers(parent);
            })
            .Type<ListType<UserType>>();
        descriptor.Field(f => f.Followed)
            .Resolve(async context =>
            {
                var parent = context.Parent<User>();
                var service = context.Services.GetService<IUserService>();
                if (service == null)
                {
                    return new Error("Falha ao injetar");
                }

                return await service.GetFollowed(parent);
            })
            .Type<ListType<UserType>>();
    }
}