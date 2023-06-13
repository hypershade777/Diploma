using Microsoft.AspNetCore.Mvc;
using Notes.Domain;
using Notes.Application.Users.Commands;
using Notes.Application.Users.Queries;
using NotesWEBApi.Models;
using System.Linq;

namespace NotesWEBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {

        [HttpPost("login")]
        public async Task<ActionResult<int?>> Login([FromBody] LoginUserDto logicUserDto)
        {
            var command = Mapper.Map<LoginUserCommand>(logicUserDto);
            var userId = await Mediator.Send(command);

            return Ok(userId);
        }

        [HttpGet("id")]
        public async Task<ActionResult<User?>> Get([FromQuery] int id)
        {
            var list = await Mediator.Send(new GetUsersListQuery());
            var user = list.FirstOrDefault(user => user.Id == id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateUserDto createUserDto)
        {
            var command = Mapper.Map<CreateUserCommand>(createUserDto);
            var userId = await Mediator.Send(command);

            return Ok(userId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            int id;
            int.TryParse(_userId, out id);

            updateUserDto.Id = id;

            var command = Mapper.Map<UpdateUserCommand>(updateUserDto);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
