namespace Leptonica
{
    public enum InsertionType
    {
        /// <summary>
        /// stuff it in; no copy, clone or copy-clone 
        /// </summary>
        INSERT = 0,
        /// <summary>
        ///  make/use a copy of the object    
        /// </summary>
        COPY = 1,
        /// <summary>
        /// make/use clone (count) of the object  
        /// </summary>
        CLONE = 2,
        /// <summary>
        ///  make a new object and fill with with clones
        ///  of each object in the array(s)     
        /// </summary>
        COPY_CLONE = 3
    }
}
