using MediatR;


namespace Notes.Application.Users.Commands
{
    public record DeleteUserCommand(int Id) : IRequest;
}
