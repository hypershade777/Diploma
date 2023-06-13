using AutoMapper;
using MediatR;
using Notes.Application.Common.Extensions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Users.Commands
{
    public class AddUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(INotesDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Surname = request.Surname,
                Password = request.Password.ToMD5Hash()
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
