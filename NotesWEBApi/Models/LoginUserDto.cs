using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Users.Commands;

namespace NotesWEBApi.Models
{
    public class LoginUserDto : IMapWith<CreateUserCommand>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginUserDto, LoginUserCommand>();
        }
    }
}

