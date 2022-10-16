using OrderAppApi.Models;
using MediatR;

namespace OrderAppApi.Queries
{
    public record GetOrderQuery : IRequest<List<Order>>;
}
