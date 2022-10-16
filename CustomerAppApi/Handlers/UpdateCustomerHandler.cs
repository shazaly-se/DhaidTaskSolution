using CustomerAppApi.Commands;
using CustomerAppApi.Models;
using MediatR;

namespace CustomerAppApi.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly CustomerDbContext _context;

        public UpdateCustomerHandler(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            _context.Customers.Update(request.customer);
            _context.SaveChanges();
             return await Task.FromResult(request.customer);
        }
    }
}
