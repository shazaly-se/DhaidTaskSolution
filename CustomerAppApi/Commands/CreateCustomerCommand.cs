using CustomerAppApi.Models;
using MediatR;
namespace CustomerAppApi.Commands
{
    public record CreateCustomerCommand(Customer customer) : IRequest<Customer>;


}
