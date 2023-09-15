using WebApplication1.Services;

namespace WebApplication1.Schema.PostType;

public class PostType : ObjectType<Post>
{
    protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
    {
        descriptor.Field(f => f.Id);
        
        descriptor.Field("comments")
            .Resolve(async context =>
            {
                var post = context.Parent<Post>();
                var service = context.Services.GetService<IUserService>();
                if (service != null)
                {
                    return await service.GetCommets(post);
                }

                return new Error("failed to load the service");
            })
            .Type<ListType<CommentType.CommentType>>();
        descriptor
            .Field(f => f.Content);
        
        descriptor.Field(f => f.Author)
            .Resolve(async context =>
            {
                var post = context.Parent<Post>();
                var service = context.Services.GetService<IUserService>();
                if (service != null)
                {
                    return await service.GetAuthor(post);
                }

                return new Error("failed to load the service");
            })
            .Type<UserType.UserType>();
    }
}