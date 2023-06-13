using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.UpdateNote;

namespace NotesWEBApi.Models
{
    public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>();
        }
    }
}
