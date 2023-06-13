using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Users.Commands;

namespace NotesWEBApi.Models
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>();
        }
    }
}
