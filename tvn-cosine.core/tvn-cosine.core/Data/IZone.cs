using Tvn.Cosine.Geometry;
using Tvn.Cosine.Imaging;

namespace Tvn.Cosine.Data
{
    public interface IZone : IPoint<double>, ISize<double>
    { 
        bool IsSelected { get; }
        int Order { get; }
        string ZoneType { get; }
        IColor FillColor { get; }
        double XProportional { get; }
        double YProportional { get; }
        double WidthProportional { get; }
        double HeightProportional { get; }
    }
}
