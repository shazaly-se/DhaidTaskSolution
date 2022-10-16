using CustomerAppApi.Models;
using MediatR;

namespace CustomerAppApi.Commands
{
    public record DeleteCustomerCommand(int customerId) : IRequest<Customer>;
    
}
