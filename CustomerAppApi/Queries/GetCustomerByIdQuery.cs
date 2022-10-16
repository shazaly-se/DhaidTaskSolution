using CustomerAppApi.Models;
using MediatR;

namespace CustomerAppApi.Queries
{
    public record GetCustomerByIdQuery (int customerId) : IRequest<Customer>;
   
}
