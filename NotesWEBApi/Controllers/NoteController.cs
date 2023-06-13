using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using NotesWEBApi.Models;

namespace NotesWEBApi.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            int id;
            int.TryParse(_userId, out id);

            var query = new GetNoteListQuery() { UserId = id};
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("id")]
        public async Task<ActionResult<NoteListVm>> Get([FromQuery] int id)
        {   
            var query = new GetNoteDetailsQuery()
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateNoteDto createNoteDto)
        {
            int id;
            int.TryParse(_userId, out id);
            var command = Mapper.Map<CreateNoteCommand>(createNoteDto);
            command.UserId = id;
            var noteId = await Mediator.Send(command);

            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = Mapper.Map<UpdateNoteCommand>(updateNoteDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteNoteCommand()
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
