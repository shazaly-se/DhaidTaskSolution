using CustomerAppApi.Models;
using CustomerAppApi.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerAppApi.Handlers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
    {
        private readonly CustomerDbContext _context;

        public GetCustomersHandler(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Customers.ToList());
        }
    }
}
