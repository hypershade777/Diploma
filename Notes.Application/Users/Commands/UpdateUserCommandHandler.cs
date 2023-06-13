using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Common.Extensions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(INotesDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.Name = request.Name;
            entity.Surname = request.Surname;
            entity.Email = request.Email;
            if(entity.Password != request.Password.ToMD5Hash())
            {
                entity.Password = request.Password.ToMD5Hash();
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
