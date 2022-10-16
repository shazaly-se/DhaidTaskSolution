using CustomerAppApi.Commands;
using CustomerAppApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAppApi.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly CustomerDbContext _context;

        public CreateCustomerHandler(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
             _context.Customers.Add(request.customer);
             _context.SaveChanges();
             return await Task.FromResult(request.customer);
        }
    }
}
