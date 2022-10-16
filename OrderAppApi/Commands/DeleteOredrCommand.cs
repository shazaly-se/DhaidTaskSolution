
using MediatR;
using OrderAppApi.Models;

namespace OrderAppApi.Commands
{
    public record DeleteOredrCommand(string orderId) : IRequest<Order>;
    
}
