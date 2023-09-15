using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;

namespace WebApplication1.Schema;


public class QueryType: ObjectType
{

    
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor
            .Field("user")
            .Argument("username", a => a.Type<NonNullType<StringType>>())
            .Resolve( async context =>
            {
                var username = context.ArgumentValue<string>("username");
                var service = context.Services.GetService<UserService>();
                
                if (service == null)
                {
                    return new Error("Invalid Service");
                }
                
                return await service.GetUser(username);
            }).Type<UserType>();
    }
}

public class CommentType : ObjectType<Comment>
{
    protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
    {
        descriptor.Field(f => f.Id);
        descriptor.Field(f => f.Content);
        descriptor.Field(f => f.AuthorId);
    }
}

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Field(f => f.Id);
        descriptor.Field(f => f.Username);
        descriptor.Field(f => f.Email);
        descriptor.Field(f => f.Comments).Type<ListType<CommentType>>();
        descriptor.Field(f => f.Posts).Type<ListType<PostType>>();
        descriptor.Field(f => f.Followers).Type<ListType<UserType>>();
        descriptor.Field(f => f.Followed).Type<ListType<UserType>>();
    }
}

public class PostType : ObjectType<Post>
{
    protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
    {
        descriptor.Field(f => f.Id);
        descriptor.Field(f => f.CommentsCollection).Type<ListType<CommentType>>();
        descriptor.Field(f => f.Content);
        descriptor.Field(f => f.Author).Type<UserType>();
    }
}