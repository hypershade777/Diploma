using MediatR;

namespace Notes.Application.Users.Commands
{
    public record LoginUserCommand(string Email, string Password) : IRequest<int?>;
}
