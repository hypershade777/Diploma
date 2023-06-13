using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Domain;
using System.Collections.Generic;

namespace Notes.Application.Users.Queries
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, IEnumerable<User>>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(INotesDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<IEnumerable<User>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Users.ToListAsync(cancellationToken);
        }
    }
}
