namespace Tvn.Cosine.Imaging.Leptonica
{
    public enum RotateFlags
    {
        /// <summary>
        /// use area map rotation, if possible 
        /// </summary>
        ROTATE_AREA_MAP = 1,
        /// <summary>
        /// use shear rotation     
        /// </summary>
        ROTATE_SHEAR = 2,
        /// <summary>
        /// use sampling        
        /// </summary>
        ROTATE_SAMPLING = 3,
    }
}
