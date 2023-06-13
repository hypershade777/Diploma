using MediatR;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Users.Commands
{
    public record UpdateUserCommand(int Id = 0, string Name = "", string Surname = "", string Email = "", string Password = "") : IRequest;
}