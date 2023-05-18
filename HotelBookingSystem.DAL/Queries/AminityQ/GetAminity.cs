using HotelBookingSystem.DAL.Contexts;
using HotelBookingSystem.Models.Entities;
using HotelBookingSystem.Utils.Expressions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelBookingSystem.DAL.Queries.AminityQ
{
    public class GetAminity : WhereExpression<Aminity>, IRequest<IEnumerable<Aminity>>
    {
        public GetAminity(Expression<Func<Aminity, bool>>? filter = null)
        {
            Filter = filter;
        }

        public Expression<Func<Aminity, bool>>? Filter { get; }
    }
    public class GetAminityHandler : IRequestHandler<GetAminity, IEnumerable<Aminity>>
    {
        public GetAminityHandler(HotelBookingContext context)
        {
            Context = context;
        }

        public HotelBookingContext Context { get; }

        public async Task<IEnumerable<Aminity>> Handle(GetAminity request, CancellationToken cancellationToken)
        {
            var res = Context.Aminities;
            if(request.Filter != null)
            {
                res.Where(request.Filter);
            }
            return await res.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
