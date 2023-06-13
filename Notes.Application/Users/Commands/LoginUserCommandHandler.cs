using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Common.Extensions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Users.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, int?>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(INotesDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<int?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Email == request.Email, cancellationToken);

            if (entity == null || entity.Email != request.Email)
            {
                throw new NotFoundException(nameof(User), request.Email);
            }

            if(entity.Password == request.Password.ToMD5Hash()) {
                return entity.Id;
            }

            return null;
             
        }
    }
}
