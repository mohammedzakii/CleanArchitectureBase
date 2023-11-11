using CleanArchitectureBase.Application.Interfaces.Users.Commands;
using CleanArchitectureBase.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBase.WebApi.Areas.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<UsersController>
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("addNewUSer")]
        public async Task<IActionResult> addNewUSer(AddNewUserCommand commmand)
        {
            try
            {
                return await MediatorExecute(commmand);
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
