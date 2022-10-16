using CustomerAppApi.Models;
using MediatR;
namespace CustomerAppApi.Queries
{
    public record GetCustomersQuery : IRequest<List<Customer>>;
}
