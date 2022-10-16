using CustomerAppApi.Models;
using MediatR;

namespace CustomerAppApi.Commands
{
    public record UpdateCustomerCommand(Customer customer) : IRequest<Customer>; 
}
