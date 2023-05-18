using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Utils.Expressions
{
    public class WhereExpression<T>
    {
        public Expression<Func<T, bool>> Predicate { get; private set; } = x => true;
        public Expression<Func<T, object>>[] Include { get; private set; } = null!;
        public void Where(Expression<Func<T, bool>> predicate)
        {
            var visitor = new ReplaceParameter()
            {
                Target = predicate.Parameters[0],
                Replacement = Predicate.Parameters[0],
            }; 
            var rewrittenRight = visitor.Visit(predicate.Body);
            var andExpression = Expression.AndAlso(Predicate.Body, rewrittenRight);
            Predicate = Expression.Lambda<Func<T, bool>>(andExpression, Predicate.Parameters);
        }
    }
}
