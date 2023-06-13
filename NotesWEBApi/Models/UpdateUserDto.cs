using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Users.Commands;

namespace NotesWEBApi.Models
{
    public class UpdateUserDto : IMapWith<CreateUserCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>();
        }
    }
}
