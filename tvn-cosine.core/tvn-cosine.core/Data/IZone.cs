using Tvn.Cosine.Geometry;

namespace Tvn.Cosine.Data
{
    public interface IZone : IPoint<double>, ISize<double>
    {
        bool IsSelected { get; }
    }
}
