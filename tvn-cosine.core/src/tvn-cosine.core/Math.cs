namespace tvn.cosine
{
    public static class Math
    {
        #region Constants
        /// <summary>
        /// Represents the natural logarithmic base, specified by the constant, e.
        /// </summary>
        public const double E = 2.7182818284590451;

        /// <summary>
        /// Represents the ratio of the circumference of a circle to its diameter, specified by the constant, π.
        /// </summary>
        public const double PI = 3.1415926535897931;
        #endregion  

        #region Min 
        /// <summary>
        /// Returns the smaller of 64 bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two 64 bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two 64 bit unsigned integers to compare.</param>
        /// <returns>The smaller of 64 bit unsigned integers</returns>
        public static ulong Min(ulong val1, ulong val2)
        {
            return val1 < val2 ? val1 : val2;
        }

        /// <summary>
        /// Returns the smaller of 64 bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 64 bit signed integers to compare.</param>
        /// <param name="val2">The second of two 64 bit signed integers to compare.</param>
        /// <returns>The smaller of 64 bit signed integers</returns>
        public static long Min(long val1, long val2)
        {
            return val1 < val2 ? val1 : val2;
        }

        /// <summary>
        /// Returns the smaller of 32 bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 32 bit signed integers to compare.</param>
        /// <param name="val2">The second of two 32 bit signed integers to compare.</param>
        /// <returns>The smaller of 32 bit signed integers</returns>
        public static int Min(int val1, int val2)
        {
            return val1 < val2 ? val1 : val2;
        }

        /// <summary>
        /// Returns the smaller of 32 bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two 32 bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two 32 bit unsigned integers to compare.</param>
        /// <returns>The smaller of 32 bit unsigned integers</returns>
        public static uint Min(uint val1, uint val2)
        {
            return val1 < val2 ? val1 : val2;
        }

        /// <summary>
        /// Returns the smaller of 16 bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 16 bit signed integers to compare.</param>
        /// <param name="val2">The second of two 16 bit signed integers to compare.</param>
        /// <returns>The smaller of 16 bit signed integers</returns>
        public static short Min(short val1, short val2)
        {
            return val1 < val2 ? val1 : val2;
        }

        /// <summary>
        /// Returns the smaller of 16 bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two 16 bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two 16 bit unsigned integers to compare.</param>
        /// <returns>The smaller of 16 bit unsigned integers</returns>
        public static ushort Min(ushort val1, ushort val2)
        {
            return val1 < val2 ? val1 : val2;
        }

        /// <summary>
        /// Returns the smaller of 8 bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 8 bit signed integers to compare.</param>
        /// <param name="val2">The second of two 8 bit signed integers to compare.</param>
        /// <returns>The smaller of 8 bit signed integers</returns>
        public static sbyte Min(sbyte val1, sbyte val2)
        {
            return val1 < val2 ? val1 : val2;
        }

        /// <summary>
        /// Returns the smaller of 8 bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two 8 bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two 8 bit unsigned integers to compare.</param>
        /// <returns>The smaller of 8 bit unsigned integers</returns>
        public static byte Min(byte val1, byte val2)
        {
            return val1 < val2 ? val1 : val2;
        }

        /// <summary>
        /// Returns the smaller of 32 bit floating point number.
        /// </summary>
        /// <param name="val1">The first of two 32 bit floating point numbers to compare.</param>
        /// <param name="val2">The second of two 32 bit floating point numbers to compare.</param>
        /// <returns>The smaller of 32 bit floating point numbers</returns>
        public static float Min(float val1, float val2)
        {
            return val1 < val2 ? val1 : val2;
        }

        /// <summary>
        /// Returns the smaller of 64 bit floating point number.
        /// </summary>
        /// <param name="val1">The first of two 64 bit floating point numbers to compare.</param>
        /// <param name="val2">The second of two 64 bit floating point numbers to compare.</param>
        /// <returns>The smaller of 64 bit floating point numbers</returns>
        public static double Min(double val1, double val2)
        {
            return val1 < val2 ? val1 : val2;
        }

        /// <summary>
        /// Returns the smaller of 128 bit floating point number.
        /// </summary>
        /// <param name="val1">The first of two 128 bit floating point numbers to compare.</param>
        /// <param name="val2">The second of two 128 bit floating point numbers to compare.</param>
        /// <returns>The smaller of 128 bit floating point numbers</returns>
        public static decimal Min(decimal val1, decimal val2)
        {
            return val1 < val2 ? val1 : val2;
        }
        #endregion

        #region Max
        /// <summary>
        /// Returns the larger of 64 bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two 64 bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two 64 bit unsigned integers to compare.</param>
        /// <returns>The larger of 64 bit unsigned integers</returns>
        public static ulong Max(ulong val1, ulong val2)
        {
            return val1 > val2? val1 : val2;
        }

        /// <summary>
        /// Returns the larger of 64 bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 64 bit signed integers to compare.</param>
        /// <param name="val2">The second of two 64 bit signed integers to compare.</param>
        /// <returns>The larger of 64 bit signed integers</returns>
        public static long Max(long val1, long val2)
        {
            return val1 > val2? val1 : val2;
        }

        /// <summary>
        /// Returns the larger of 32 bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 32 bit signed integers to compare.</param>
        /// <param name="val2">The second of two 32 bit signed integers to compare.</param>
        /// <returns>The larger of 32 bit signed integers</returns>
        public static int Max(int val1, int val2)
        {
            return val1 > val2? val1 : val2;
        }

        /// <summary>
        /// Returns the larger of 32 bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two 32 bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two 32 bit unsigned integers to compare.</param>
        /// <returns>The larger of 32 bit unsigned integers</returns>
        public static uint Max(uint val1, uint val2)
        {
            return val1 > val2? val1 : val2;
        }

        /// <summary>
        /// Returns the larger of 16 bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 16 bit signed integers to compare.</param>
        /// <param name="val2">The second of two 16 bit signed integers to compare.</param>
        /// <returns>The larger of 16 bit signed integers</returns>
        public static short Max(short val1, short val2)
        {
            return val1 > val2? val1 : val2;
        }

        /// <summary>
        /// Returns the larger of 16 bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two 16 bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two 16 bit unsigned integers to compare.</param>
        /// <returns>The larger of 16 bit unsigned integers</returns>
        public static ushort Max(ushort val1, ushort val2)
        {
            return val1 > val2? val1 : val2;
        }

        /// <summary>
        /// Returns the larger of 8 bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 8 bit signed integers to compare.</param>
        /// <param name="val2">The second of two 8 bit signed integers to compare.</param>
        /// <returns>The larger of 8 bit signed integers</returns>
        public static sbyte Max(sbyte val1, sbyte val2)
        {
            return val1 > val2? val1 : val2;
        }

        /// <summary>
        /// Returns the larger of 8 bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two 8 bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two 8 bit unsigned integers to compare.</param>
        /// <returns>The larger of 8 bit unsigned integers</returns>
        public static byte Max(byte val1, byte val2)
        {
            return val1 > val2? val1 : val2;
        }

        /// <summary>
        /// Returns the larger of 32 bit floating point number.
        /// </summary>
        /// <param name="val1">The first of two 32 bit floating point numbers to compare.</param>
        /// <param name="val2">The second of two 32 bit floating point numbers to compare.</param>
        /// <returns>The larger of 32 bit floating point numbers</returns>
        public static float Max(float val1, float val2)
        {
            return val1 > val2? val1 : val2;
        }

        /// <summary>
        /// Returns the larger of 64 bit floating point number.
        /// </summary>
        /// <param name="val1">The first of two 64 bit floating point numbers to compare.</param>
        /// <param name="val2">The second of two 64 bit floating point numbers to compare.</param>
        /// <returns>The larger of 64 bit floating point numbers</returns>
        public static double Max(double val1, double val2)
        {
            return val1 > val2? val1 : val2;
        }

        /// <summary>
        /// Returns the larger of 128 bit floating point number.
        /// </summary>
        /// <param name="val1">The first of two 128 bit floating point numbers to compare.</param>
        /// <param name="val2">The second of two 128 bit floating point numbers to compare.</param>
        /// <returns>The larger of 128 bit floating point numbers</returns>
        public static decimal Max(decimal val1, decimal val2)
        {
            return val1 > val2? val1 : val2;
        }
        #endregion 
    }
}
