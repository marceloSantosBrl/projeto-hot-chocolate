using WebApplication1.Services;

namespace WebApplication1.Schema.CommentType;

public class CommentType : ObjectType<Comment>
{
    protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
    {
        descriptor
            .Field(f => f.Id);
        descriptor
            .Field(f => f.Content);
        
        descriptor
            .Field(f => f.Author)
            .Resolve(async context =>
            {
                var comment = context.Parent<Comment>();
                var service = context.Services.GetService<IUserService>();
                if (service == null) return new Error("failed to load the service");
                var user = await service.GetCommentAuthor(comment);
                return user;
            })
            .Type<UserType.UserType>();
    }
}