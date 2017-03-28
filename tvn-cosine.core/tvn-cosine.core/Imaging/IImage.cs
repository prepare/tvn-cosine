using System;

namespace Tvn.Cosine.Imaging
{
    public interface IImage : ICloneable
    {
        string Path { get; }
    }
}
