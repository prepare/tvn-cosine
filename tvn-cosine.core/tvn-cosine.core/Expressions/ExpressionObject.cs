using Tvn.Cosine.Data;

namespace Tvn.Cosine.Expressions
{
    public class ExpressionObject : IDescription
    {
        public ExpressionObject(string description)
        {
            Description = description;
        }
        public string Description { get; }

        public override string ToString()
        {
            return Description;
        }

        public static readonly ExpressionObject LeftParenthesis = new ExpressionObject("(");
        public static readonly ExpressionObject RightParenthesis = new ExpressionObject(")");
        public static readonly ExpressionObject FunctionSeperator = new ExpressionObject(";");
    }
}
