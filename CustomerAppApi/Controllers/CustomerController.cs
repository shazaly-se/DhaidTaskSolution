using CustomerAppApi.Commands;
using CustomerAppApi.Models;
using CustomerAppApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _context;
        private readonly IMediator _mediator;

        public CustomerController(CustomerDbContext context,IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult <List<Customer>>> GetCustomers()
        {
            return await _mediator.Send(new GetCustomersQuery());
        }
        [HttpGet("{customerId:int}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int customerId)
        {
            return await _mediator.Send(new GetCustomerByIdQuery(customerId));
        }
        [HttpPost]
        public async Task<Customer> Create(Customer customer)
        {
            return await _mediator.Send(new CreateCustomerCommand(customer));
        }
        [HttpPut]
        public async Task<Customer> Update(Customer customer)
        {
            return await _mediator.Send(new UpdateCustomerCommand(customer));
           
        }
        [HttpDelete("{customerId:int}")]
        public async Task<Customer> Delete(int customerId)
        {
            return await _mediator.Send(new DeleteCustomerCommand(customerId));
        }
    }
}
