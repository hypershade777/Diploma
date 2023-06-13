using MediatR;
using Notes.Domain;

namespace Notes.Application.Users.Commands
{
    public record CreateUserCommand(string Name, string Surname, string Email, string Password) : IRequest<int>;
}
