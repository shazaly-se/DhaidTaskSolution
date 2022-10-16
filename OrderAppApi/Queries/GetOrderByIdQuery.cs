using OrderAppApi.Models;
using MediatR;

namespace OrderAppApi.Queries
{
    public record GetOrderByIdQuery (string orderId) : IRequest<Order>;
   
}
