using System;
using System.Collections.Generic;

namespace Tvn.Cosine.Expressions
{
    public interface IFunction
    {
        Action<Stack<ExpressionObject>> F { get; }
    }
}
