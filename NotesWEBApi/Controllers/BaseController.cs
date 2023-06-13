using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NotesWEBApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        private IMapper _mapper;

        protected string _userId => HttpContext.Request.Cookies["userId"];

        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IMapper Mapper =>
            _mapper ??= HttpContext.RequestServices.GetService<IMapper>();

    }
}