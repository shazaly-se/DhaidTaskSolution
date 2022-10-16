
using MediatR;
using OrderAppApi.Models;

namespace OrderAppApi.Commands
{
    public record UpdateOrderCommand(Order order) : IRequest<Order>; 
}
