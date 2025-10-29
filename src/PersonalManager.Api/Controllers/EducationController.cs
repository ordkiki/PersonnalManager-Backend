using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PersonalManager.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EducationController(IMediator _mediator) : ControllerBase
    {
    }
}
