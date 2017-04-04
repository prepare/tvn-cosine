using System;

namespace Leptonica
{
    /// <summary>
    /// affinecompose.c
    /// </summary>
    public static class AffineCompose
    {
        // Composable coordinate transforms 
        /// <summary>
        ///  Notes:
        ///       (1) The translation is equivalent to:
        ///              v' = Av
        ///           where v and v' are 1x3 column vectors in the form
        ///              v = [x, y, 1]^    ^ denotes transpose
        ///           and the affine tranlation matrix is
        ///              A = [ 1   0   tx
        ///                    0   1   ty
        ///                    0   0    1  ]
        /// 
        ///       (2) We consider translation as with respect to a fixed origin.
        ///  In a clipping operation, the origin moves and the points
        ///  are fixed, and you use(-tx, -ty) where(tx, ty) is the
        ///          translation vector of the origin.
        /// </summary>
        /// <param name="transx">transx  x component of translation wrt. the origin</param>
        /// <param name="transy">transy  y component of translation wrt. the origin</param>
        /// <returns>3x3 transform matrix, or NULL on error</returns>
        public static float[] createMatrix2dTranslate(float transx, float transy)
        {
            return Native.DllImports.createMatrix2dTranslate(transx, transy);
        }

        /// <summary>
        ///  Notes:
        ///       (1) The scaling is equivalent to:
        ///              v' = Av
        ///          where v and v' are 1x3 column vectors in the form
        ///               v = [x, y, 1]^    ^ denotes transpose
        ///          and the affine scaling matrix is
        ///              A = [sx  0    0
        ///                    0   sy   0
        ///                    0   0    1  ]
        /// 
        ///       (2) We consider scaling as with respect to a fixed origin.
        ///  In other words, the origin is the only point that doesn't
        ///  move in the scaling transform.
        /// </summary>
        /// <param name="scalex">scalex  horizontal scale factor</param>
        /// <param name="scaley"> scaley  vertical scale factor</param>
        /// <returns>3x3 transform matrix, or NULL on error</returns>
        public static float[] createMatrix2dScale(float scalex, float scaley)
        {
            return Native.DllImports.createMatrix2dScale(scalex, scaley);
        }

        /// <summary>
        /// Notes:
        ///      (1) The rotation is equivalent to:
        ///             v' = Av
        ///          where v and v' are 1x3 column vectors in the form
        ///             v = [x, y, 1]^    ^ denotes transpose
        ///          and the affine rotation matrix is
        ///             A = [cosa   -sina    xc*1-cosa + yc*sina
        ///                   sina    cosa    yc*1-cosa - xc*sina
        ///                     0       0                 1         ]
        /// 
        /// If the rotation is about the origin, xc, yc) = (0, 0 and
        /// his simplifies to
        ///             A = [cosa - sina    0
        /// ina    cosa    0
        ///        0     1]
        /// 
        /// ese relations follow from the following equations, which
        /// ou can convince yourself are correct as follows.Draw a
        ///          circle centered on xc, yc) and passing through (x,y), with
        ///          (x',y') on the arc at an angle 'a' clockwise from (x,y).
        ///           [Hint: cosa + b = cosa * cosb - sina * sinb
        ///                   sina + b = sina * cosb + cosa * sinb]
        /// 
        ///            x' - xc =  x - xc) * cosa - (y - yc * sina
        ///            y' - yc =  x - xc) * sina + (y - yc * cosa
        /// </summary>
        /// <param name="xc">xc, yc  location of center of rotation</param>
        /// <param name="yc">xc, yc  location of center of rotation</param>
        /// <param name="angle">angle  rotation in radians; clockwise is positive</param>
        /// <returns>3x3 transform matrix, or NULL on error</returns>
        public static float[] createMatrix2dRotate(float xc, float yc, float angle)
        {
            return Native.DllImports.createMatrix2dRotate(xc, yc, angle);
        }



        // Special coordinate transforms on pta
        /// <summary>
        /// (1) See createMatrix2dTranslate() for details of transform.
        /// </summary>
        /// <param name="ptas">ptas for initial points</param>
        /// <param name="transx">transx  x component of translation wrt. the origin</param>
        /// <param name="transy">transy  y component of translation wrt. the origin</param>
        /// <returns>ptad  translated points, or NULL on error</returns>
        public static Pta ptaTranslate(Pta ptas, float transx, float transy)
        {
            if (ptas == null)
            {
                return null;
            }

            var pointer = Native.DllImports.ptaTranslate(ptas.handleRef, transx, transy);

            if (pointer != IntPtr.Zero)
            {
                return new Pta(pointer);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// (1) See createMatrix2dScale() for details of transform.
        /// </summary>
        /// <param name="ptas">ptas for initial points</param>
        /// <param name="scalex">scalex  horizontal scale factor</param>
        /// <param name="scaley">scaley  vertical scale factor</param>
        /// <returns>ptad  translated points, or NULL on error</returns>
        public static Pta ptaScale(Pta ptas, float scalex, float scaley)
        {
            if (ptas == null)
            {
                return null;
            }

            var pointer = Native.DllImports.ptaScale(ptas.handleRef, scalex, scaley);

            if (pointer != IntPtr.Zero)
            {
                return new Pta(pointer);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///  Notes;
        ///       (1) See createMatrix2dScale() for details of transform.
        ///       (2) This transform can be thought of as composed of the
        ///  sum of two parts:
        ///            a) an(x, y)-dependent rotation about the origin:
        ///               xr = x* cosa - y* sina
        ///               yr = x* sina + y* cosa
        ///            b) an(x, y)-independent translation that depends on the
        ///               rotation center and the angle:
        ///               xt = xc - xc* cosa + yc* sina
        ///               yt = yc - xc* sina - yc* cosa
        ///           The translation part(xt, yt) is equal to the difference
        ///           between the center(xc, yc) and the location of the
        ///  center after it is rotated about the origin.
        /// </summary>
        /// <param name="ptas">ptas for initial points</param>
        /// <param name="xc">xc, yc  location of center of rotation</param>
        /// <param name="yc">xc, yc  location of center of rotation</param>
        /// <param name="angle">angle  rotation in radians; clockwise is positive</param>
        /// <returns>ptad  translated points, or NULL on error</returns>
        public static Pta ptaRotate(Pta ptas, float xc, float yc, float angle)
        {
            if (ptas == null)
            {
                return null;
            }

            var pointer = Native.DllImports.ptaRotate(ptas.handleRef, xc, yc, angle);

            if (pointer != IntPtr.Zero)
            {
                return new Pta(pointer);
            }
            else
            {
                return null;
            }
        }




        // Special coordinate transforms on boxa
        /// <summary>
        /// (1) See createMatrix2dTranslate() for details of transform.
        /// </summary>
        /// <param name="boxas">boxas</param>
        /// <param name="transx">transx  x component of translation wrt. the origin</param>
        /// <param name="transy">transy  y component of translation wrt. the origin</param>
        /// <returns>boxad  translated boxas, or NULL on error</returns>
        public static Boxa boxaTranslate(Boxa boxas, float transx, float transy)
        {
            if (boxas == null)
            {
                return null;
            }

            var pointer = Native.DllImports.boxaTranslate(boxas.handleRef, transx, transy);

            if (pointer != IntPtr.Zero)
            {
                return new Boxa(pointer);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// (1) See createMatrix2dScale() for details of transform.
        /// </summary>
        /// <param name="boxas">boxas</param>
        /// <param name="scalex">scalex  horizontal scale factor</param>
        /// <param name="scaley">scaley  vertical scale factor</param>
        /// <returns>boxad  scaled boxas, or NULL on error</returns>
        public static Boxa boxaScale(Boxa boxas, float scalex, float scaley)
        {
            if (boxas == null)
            {
                return null;
            }

            var pointer = Native.DllImports.boxaScale(boxas.handleRef, scalex, scaley);

            if (pointer != IntPtr.Zero)
            {
                return new Boxa(pointer);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// (1) See createMatrix2dRotate() for details of transform.
        /// </summary>
        /// <param name="boxas">boxas</param>
        /// <param name="xc">xc, yc  location of center of rotation</param>
        /// <param name="yc">xc, yc  location of center of rotation</param>
        /// <param name="angle">angle  rotation in radians; clockwise is positive</param>
        /// <returns>boxad  scaled boxas, or NULL on error</returns>
        public static Boxa boxaRotate(Boxa boxas, float xc, float yc, float angle)
        {
            if (boxas == null)
            {
                return null;
            }

            var pointer = Native.DllImports.boxaRotate(boxas.handleRef, xc, yc, angle);

            if (pointer != IntPtr.Zero)
            {
                return new Boxa(pointer);
            }
            else
            {
                return null;
            }
        }



        // General coordinate transform on pta and boxa
        /// <summary>
        /// General affine coordinate transform 
        /// </summary>
        /// <param name="ptas">ptas for initial points</param>
        /// <param name="mat">mat  3x3 transform matrix; canonical form</param>
        /// <returns>ptad  transformed points, or NULL on error</returns>
        public static Pta ptaAffineTransform(Pta ptas, float[] mat)
        {
            if (ptas == null)
            {
                return null;
            }

            var pointer = Native.DllImports.ptaAffineTransform(ptas.handleRef, mat);

            if (pointer != IntPtr.Zero)
            {
                return new Pta(pointer);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// General affine coordinate transform 
        /// </summary>
        /// <param name="boxas">  boxas</param>
        /// <param name="mat">  mat  3x3 transform matrix; canonical form</param>
        /// <returns>boxad  transformed boxas, or NULL on error</returns>
        public static Boxa boxaAffineTransform(Boxa boxas, float[] mat)
        {
            if (boxas == null)
            {
                return null;
            }

            var pointer = Native.DllImports.boxaAffineTransform(boxas.handleRef, mat);

            if (pointer != IntPtr.Zero)
            {
                return new Boxa(pointer);
            }
            else
            {
                return null;
            }
        }



        // Matrix operations
        /// <summary>
        ///     Matrix operations  
        /// </summary>
        /// <param name="mat">mat  square matrix, as a 1-dimensional %size^2 array</param>
        /// <param name="vecs">vecs input column vector of length %size</param>
        /// <param name="vecd">vecd result column vector</param>
        /// <param name="size">size matrix is %size x %size; vectors are length %size</param>
        /// <returns>true if OK, false on error</returns>
        public static bool l_productMatVec(float[] mat, float[] vecs, float[] vecd, int size)
        {
            if (mat == null)
            {
                return false;
            }
            if (vecs == null)
            {
                return false;
            }
            if (vecd == null)
            {
                return false;
            }

            return Native.DllImports.l_productMatVec(mat, vecs,  vecd,  size) == 0;
        }

        /// <summary>
        /// l_productMat2()
        /// </summary>
        /// <param name="mat1">mat1  square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="mat2">mat2  square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="matd">matd  square matrix; product stored here</param>
        /// <param name="size">size of matrices</param>
        /// <returns>true if OK, false on error</returns>
        public static bool l_productMat2(float[] mat1, float[] mat2, float[] matd, int size)
        {
            if (mat1 == null)
            {
                return false;
            }
            if (mat2 == null)
            {
                return false;
            }
            if (matd == null)
            {
                return false;
            }

            return Native.DllImports.l_productMat2(mat1, mat2, matd, size) == 0;
        }

        /// <summary>
        ///  l_productMat3()
        /// </summary>
        /// <param name="mat1">mat1  square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="mat2">mat2  square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="mat3">mat3  square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="matd">matd  square matrix; product stored here</param>
        /// <param name="size">size  of matrices</param>
        /// <returns>true if OK, false on error</returns>
        public static bool l_productMat3(float[] mat1, float[] mat2, float[] mat3, float[] matd, int size)
        {
            if (mat1 == null)
            {
                return false;
            }
            if (mat2 == null)
            {
                return false;
            }
            if (mat3 == null)
            {
                return false;
            }
            if (matd == null)
            {
                return false;
            }

            return Native.DllImports.l_productMat3(mat1, mat2, mat3, matd, size) == 0;
        }

        /// <summary>
        /// l_productMat4()
        /// </summary>
        /// <param name="mat1">mat1  square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="mat2">mat2  square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="mat3">mat3  square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="mat4">mat4  square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="matd">matd  square matrix; product stored here</param>
        /// <param name="size">size  of matrices</param>
        /// <returns>true if OK, false on error</returns>
        public static bool l_productMat4(float[] mat1, float[] mat2, float[] mat3, float[] mat4, float[] matd, int size)
        {
            if (mat1 == null)
            {
                return false;
            }
            if (mat2 == null)
            {
                return false;
            }
            if (mat3 == null)
            {
                return false;
            }
            if (mat4 == null)
            {
                return false;
            }
            if (matd == null)
            {
                return false;
            }

            return Native.DllImports.l_productMat4(mat1, mat2, mat3, mat4, matd, size) == 0;
        } 
    }
}
