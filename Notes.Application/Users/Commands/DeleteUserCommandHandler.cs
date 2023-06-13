using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Application.Users.Commands;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Users.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly INotesDbContext _dbContext;

        public DeleteUserCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            var relatedNoteIds = await _dbContext.Notes
                .Where(note => note.UserId == entity.Id).ToListAsync();

            if (relatedNoteIds.Any())
            {
                foreach (var relatedNoteId in relatedNoteIds)
                {
                    _dbContext.Notes.Remove(relatedNoteId);
                }

                 await _dbContext.SaveChangesAsync(cancellationToken);
            }

            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
