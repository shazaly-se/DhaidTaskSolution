using CustomerAppApi.Models;
using CustomerAppApi.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerAppApi.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly CustomerDbContext _context;

        public GetCustomerByIdHandler(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request.customerId);
            return customer;
        }
    }
}
