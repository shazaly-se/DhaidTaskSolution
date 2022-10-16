using CustomerAppApi.Commands;
using CustomerAppApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerAppApi.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Customer>
    {
        private readonly CustomerDbContext _context;

        public DeleteCustomerHandler(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request.customerId);
                _context.Customers.Remove(customer);
                 _context.SaveChanges();
                return await Task.FromResult(customer);
        }
    }
}
