using DiscountAppAPI.Models;
using MediatR;

namespace DiscountAppAPI.Commands
{
    public record CreateDiscountCommand(DiscountCode discount) : IRequest<DiscountCode>;
   
}
