using MediatR;
using Notes.Domain;


namespace Notes.Application.Users.Queries
{
    public record GetUsersListQuery() : IRequest<IEnumerable<User>>;
}
