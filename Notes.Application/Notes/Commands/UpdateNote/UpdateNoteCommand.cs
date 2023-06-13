using System;
using MediatR;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
    }
}