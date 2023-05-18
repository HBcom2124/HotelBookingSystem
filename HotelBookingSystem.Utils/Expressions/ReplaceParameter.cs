using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Utils.Expressions
{
    internal class ReplaceParameter : ExpressionVisitor
    {
        public ParameterExpression Replacement { get; set; } = null!;
        public ParameterExpression Target { get; set; } = null!;
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == Target ? Replacement : base.VisitParameter(node);
        }
        internal Expression VisitAndConvert<T, TOutput>(Expression<T> root)
        {
            return (Expression<TOutput>)VisitLambda(root);
        }

        //protected override Expression VisitLambda<T>(Expression<T> node)
        //{
        //    // Leave all parameters alone except the one we want to replace.
        //    var parameters = node.Parameters
        //                         .Where(p => p != _source);

        //    return Expression.Lambda<TOutput>(Visit(node.Body), parameters);
        //}
    }
}
