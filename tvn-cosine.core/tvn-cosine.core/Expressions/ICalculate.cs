namespace Tvn.Cosine.Expressions
{
    public interface ICalculate<T>
    {
        Operand<T> Calculate();
    }
}
