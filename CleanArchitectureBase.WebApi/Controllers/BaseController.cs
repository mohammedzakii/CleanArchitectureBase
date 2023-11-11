using MediatR;
using Microsoft.AspNetCore.Mvc;
using OurStore.Application.Exceptions;
using System.Net;

namespace CleanArchitectureBase.WebApi.Controllers
{

    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());


        public async Task<ActionResult> MediatorExecute<TRequest>(IRequest<TRequest> request)
        {
            try
            {
                var response = await Mediator.Send(request);
                return Ok(new JsonRespone<TRequest> { Data = response, Message = "", StatusCode = (int)HttpStatusCode.OK, Success = true });
            }
            catch (NotFoundException ex) { return NotFound(new JsonRespone<int> { Data = 0, Message = ex.Message, StatusCode = (int)HttpStatusCode.NotFound, Success = false }); }

            catch (KeyIsAlreadyExistsException ex) { return BadRequest(new JsonRespone<int> { Data = 0, Message = ex.Message, StatusCode = (int)HttpStatusCode.Conflict }); }

            catch (NameIsAlreadyExistsException ex) { return BadRequest(new JsonRespone<int> { Data = 0, Message = ex.Message, StatusCode = (int)HttpStatusCode.Conflict }); }

            catch (ValidationException ex)
            { return BadRequest(new JsonRespone<int> { Data = 0, Message = ex.Failures.First().Value.First(), StatusCode = (int)HttpStatusCode.BadRequest }); }

            catch (Exception ex) { return BadRequest(new JsonRespone<int> { Data = 0, Message = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest }); }
        }


        public class JsonRespone<T>
        {
            public string Message { get; set; }
            public T Data { get; set; }
            public bool Success { get; set; }
            public int StatusCode { get; set; }
        }
    }
}
