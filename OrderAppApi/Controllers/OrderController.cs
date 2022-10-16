using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OrderAppApi.Commands;
using OrderAppApi.Models;
using OrderAppApi.Queries;

namespace OrderAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private readonly OrderDbContext _context;
        private readonly IMongoCollection<Order> _orderCollection;
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
           
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
             return await _mediator.Send(new GetOrderQuery());
            //  return await _orderCollection.Find(Builders<Order>.Filter.Empty).ToListAsync();
        }
        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetOrderById(string orderId)
        {
            return await _mediator.Send(new GetOrderByIdQuery(orderId));
        }
        [HttpPost]
       
        public async Task<Order> Create(Order order)
        {

            return await _mediator.Send(new CreateOrderCommand(order));
        }
        [HttpPut]
        public async Task<Order> Update(Order order)
        {
            return await _mediator.Send(new UpdateOrderCommand(order));
        }
        [HttpDelete("{orderId}")]
        public async Task<Order> Delete(string orderId)
        {
            return await _mediator.Send(new DeleteOredrCommand(orderId));
        }
    }
}

