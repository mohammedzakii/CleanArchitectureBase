using CleanArchitectureBase.Application.Customers.Commands.Create;
using CleanArchitectureBase.Application.Customers.Commands.Delete;
using CleanArchitectureBase.Application.Customers.Commands.Update;
using CleanArchitectureBase.Application.Customers.Queries;
using CleanArchitectureBase.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureBase.WebApi.Areas.Cusromers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController<CustomerController>
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("addNewCustomer")]
        public async Task<IActionResult> addNewCustomers(AddNewCustomerCommand commmand)
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
        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> updateCustomers(UpdateCustomerCommand command)
        {
            try
            {
                return await MediatorExecute(command);
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
        [HttpPost("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomers([Required] int Id)
        {
            try
            {
                var command = new DeleteCustomerCommand() { Id = Id};
                return await MediatorExecute(command);
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
        [HttpPost("GetCustomerByID")]
        public async Task<IActionResult> GetCustomerByID([Required]int Id)
        {
            try
            {
                var command = new GetCustomerById() { Id = Id};
                return await MediatorExecute(command);
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
        [HttpPost("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var command = new GetAllCustomerQuery();
                return await MediatorExecute(command);
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
    }
}
