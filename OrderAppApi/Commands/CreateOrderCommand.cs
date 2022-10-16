
using MediatR;
using OrderAppApi.Models;

namespace OrderAppApi.Commands
{
    public record CreateOrderCommand(Order order) : IRequest<Order>;


}
