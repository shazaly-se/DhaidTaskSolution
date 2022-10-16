using DiscountAppAPI.Commands;
using DiscountAppAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiscountAppAPI.Handlers
{
    public class CreateDiscountHandler : IRequestHandler<CreateDiscountCommand, DiscountCode>
    {
        private readonly DiscountCodeDbContext _context;

        public CreateDiscountHandler(DiscountCodeDbContext context)
        {
            _context = context;
        }
        public async Task<DiscountCode> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            _context.DiscountCodes.Add(request.discount);
            _context.SaveChanges();
             return await Task.FromResult(request.discount);
        }
    }
}
