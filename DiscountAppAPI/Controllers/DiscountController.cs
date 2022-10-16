using DiscountAppAPI.Commands;
using DiscountAppAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscountAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly DiscountCodeDbContext _context;
        private readonly IMediator _mediator;

        public DiscountController(DiscountCodeDbContext context,IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
      
        [HttpPost]
        public async Task<DiscountCode> Create(DiscountCode discount)
        {
            return await _mediator.Send(new CreateDiscountCommand(discount));
        }
    }
}
