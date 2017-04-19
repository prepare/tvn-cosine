using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// boxaa.h
    /// </summary>
    public class Boxaa : LeptonicaObjectBase
    {
        public Boxaa(IntPtr pointer)
            : base(pointer)
        { }

        /// <summary>
        ///  Boxaa creation
        /// </summary>
        /// <param name="n">n size of boxa ptr array to be alloc'd; 0 for default</param>
        /// <returns>baa, or NULL on error</returns>
        public static Boxaa Create(int n)
        {
            return (Boxaa)Native.DllImports.boxaaCreate(n);
        }

        /// <summary>
        ///  (1) L_COPY makes a copy of each boxa in baas.
        ///  L_CLONE makes a clone of each boxa in baas.
        /// </summary>
        /// <param name="copyflag">copyflag L_COPY, L_CLONE</param>
        /// <returns>baad new boxaa, composed of copies or clones of the boxa in baas, or NULL on error</returns>
        public Boxaa Copy(InsertionType copyflag)
        {
            return (Boxaa)Native.DllImports.boxaaCopy((HandleRef)this, copyflag);
        }

        /// <summary>
        /// pbaa will be set to null before returning
        /// </summary>
        public void Destroy()
        {
            var toDestroy = (IntPtr)this;
            Native.DllImports.boxaaDestroy(ref toDestroy);
        }

        /// <summary>
        /// boxaaAddBoxa()
        /// </summary>
        /// <param name="boxa">to be added</param>
        /// <param name="copyflag">copyflag  L_INSERT, L_COPY, L_CLONE</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryAddBoxa(Boxa boxa, InsertionType copyflag)
        {
            return Native.DllImports.boxaaAddBoxa((HandleRef)this, (HandleRef)boxa, copyflag) == 0;
        }

        /// <summary>
        /// boxaaExtendArray()
        /// </summary>
        /// <returns>true if OK, false on error</returns>
        public bool TryExtendArray()
        {
            return Native.DllImports.boxaaExtendArray((HandleRef)this) == 0;
        }

        /// <summary>
        /// (1) If necessary, reallocs the boxa ptr array to %size.
        /// </summary>
        /// <param name="size">size new size of boxa array</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryExtendArrayToSize(int size)
        {
            return Native.DllImports.boxaaExtendArrayToSize((HandleRef)this, size) == 0;
        }

        /// <summary>
        /// count number of boxa, or 0 if no boxa or on error
        /// </summary>
        /// <returns>count number of boxa, or 0 if no boxa or on error</returns>
        public int GetCount()
        {
            return Native.DllImports.boxaaGetCount((HandleRef)this);
        }

        /// <summary>
        /// count number of boxes, or 0 if no boxes or on error
        /// </summary>
        /// <returns>count number of boxes, or 0 if no boxes or on error</returns>
        public int GetBoxCount()
        {
            return Native.DllImports.boxaaGetBoxCount((HandleRef)this);
        }

        /// <summary>
        /// boxaaGetBoxa()
        /// </summary>
        /// <param name="index">index  to the index-th boxa</param>
        /// <param name="accessflag">accessflag   L_COPY or L_CLONE</param>
        /// <returns>boxa, or NULL on error</returns>
        public Boxa GetBoxa(int index, InsertionType accessflag)
        {
            return (Boxa)Native.DllImports.boxaaGetBoxa((HandleRef)this, index, accessflag);
        }

        /// <summary>
        /// boxaaGetBox()
        /// </summary>
        /// <param name="iboxa">iboxa  index into the boxa array in the boxaa</param>
        /// <param name="ibox">ibox  index into the box array in the boxa</param>
        /// <param name="accessflag">accessflag   L_COPY or L_CLONE</param>
        /// <returns>box, or NULL on error</returns>
        public Box GetBox(int iboxa, int ibox, InsertionType accessflag)
        {
            return (Box)Native.DllImports.boxaaGetBox((HandleRef)this, iboxa, ibox, accessflag);
        }

        /// <summary>
        ///       (1) This initializes a boxaa by filling up the entire boxa ptr array
        ///           with copies of %boxa.Any existing boxa are destroyed.
        /// 
        /// After this operation, the number of boxa is equal to
        ///           the number of allocated ptrs.
        ///       (2) Note that we use boxaaReplaceBox() instead of boxaInsertBox().
        ///           They both have the same effect when inserting into a NULL ptr
        ///           in the boxa ptr array
        ///       (3) Example usage.This function is useful to prepare for a
        ///  random insertion (or replacement) of boxa into a boxaa.
        /// 
        /// To randomly insert boxa into a boxaa, up to some index "max":
        ///              Boxaa* baa = boxaaCreate(max);
        ///                // initialize the boxa
        ///              Boxa* boxa = boxaCreate(...);
        ///              ...  [optionally fix with boxes]
        ///  boxaaInitFull(baa, boxa);
        ///           A typical use is to initialize the array with empty boxa,
        ///           and to replace only a subset that must be aligned with
        ///  something else, such as a pixa.
        /// </summary>
        /// <param name="boxa">boxa to be replicated into the entire ptr array</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryInitFull(Boxa boxa)
        {
            return Native.DllImports.boxaaInitFull((HandleRef)this, (HandleRef)boxa) == 0;
        }

        /// <summary>
        ///      (1) This should be used on an existing boxaa that has been
        /// fully loaded with boxa.It then extends the boxaa,
        ///          loading all the additional ptrs with copies of boxa.
        /// Typically, boxa will be empty.
        /// </summary>
        /// <param name="maxindex">maxindex</param>
        /// <param name="boxa">boxa to be replicated into the extended ptr array</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryExtendWithInit(int maxindex, Boxa boxa)
        {
            return Native.DllImports.boxaaExtendWithInit((HandleRef)this, maxindex, (HandleRef)boxa) == 0;
        }

        /// <summary>
        /// (1) Any existing boxa is destroyed, and the input one
        ///     is inserted in its place.
        /// (2) If the index is invalid, return 1 (error)
        /// </summary>
        /// <param name="index">index  to the index-th boxa</param>
        /// <param name="boxa">boxa insert and replace any existing one</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryReplaceBoxa(int index, Boxa boxa)
        {
            return Native.DllImports.boxaaReplaceBoxa((HandleRef)this, index, (HandleRef)boxa) == 0;
        }

        /// <summary>
        /// (1) This shifts boxa[i] --> boxa[i + 1] for all i >= index,
        ///     and then inserts boxa as boxa[index].
        /// (2) To insert at the beginning of the array, set index = 0.
        /// (3) To append to the array, it's easier to use boxaaAddBoxa().
        /// (4) This should not be used repeatedly to insert into large arrays,
        ///     because the function is O(n). 
        /// </summary>
        /// <param name="index">index location in boxaa to insert new boxa</param>
        /// <param name="boxa">boxa new boxa to be inserted</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryInsertBoxa(int index, Boxa boxa)
        {
            return Native.DllImports.boxaaInsertBoxa((HandleRef)this, index, (HandleRef)boxa) == 0;
        }

        /// <summary>
        /// (1) This removes boxa[index] and then shifts
        ///     boxa[i] --> boxa[i - 1] for all i > index.
        /// (2) The removed boxaa is destroyed.
        /// (2) This should not be used repeatedly on large arrays,
        ///     because the function is O(n).
        /// </summary>
        /// <param name="index">index  of the boxa to be removed</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryRemoveBoxa(int index)
        {
            return Native.DllImports.boxaaRemoveBoxa((HandleRef)this, index) == 0;
        }

        /// <summary>
        ///  (1) Adds to an existing boxa only.
        /// </summary>
        /// <param name="index">index of boxa with boxaa</param>
        /// <param name="box">box to be added</param>
        /// <param name="accessflag">accessflag L_INSERT, L_COPY or L_CLONE</param>
        /// <returns></returns>
        public bool TryAddBox(int index, Box box, InsertionType accessflag)
        {
            return Native.DllImports.boxaaAddBox((HandleRef)this, index, (HandleRef)box, accessflag) == 0;
        }

        /// <summary>
        ///       (1) The files must be serialized boxa files(e.g., *.ba).
        ///           If some files cannot be read, warnings are issued.
        ///       (2) Use %substr to filter filenames in the directory.If
        ///           %substr == NULL, this takes all files.
        ///       (3) After filtering, use %first and %nfiles to select
        ///  a contiguous set of files, that have been lexically
        /// sorted in increasing order.
        /// </summary>
        /// <param name="dirname">dirname directory</param>
        /// <param name="substr">substr [optional] substring filter on filenames; can be NULL</param>
        /// <param name="first">first 0-based</param>
        /// <param name="nfiles">nfiles use 0 for everything from %first to the end</param>
        /// <returns>baa, or NULL on error or if no boxa files are found.</returns>
        public static Boxaa ReadFromFiles(string dirname, string substr, int first, int nfiles)
        {
            return (Boxaa)Native.DllImports.boxaaReadFromFiles(dirname, substr, first, nfiles);
        }

        /// <summary>
        /// boxaaRead()
        /// </summary>
        /// <param name="filename">filename</param>
        /// <returns>boxaa, or NULL on error</returns>
        public static Boxaa Read(string filename)
        {
            return (Boxaa)Native.DllImports.boxaaRead(filename);
        }

        /// <summary>
        /// boxaaWrite()
        /// </summary>
        /// <param name="filename">filename</param>
        /// <returns></returns>
        public bool TryWrite(string filename)
        {
            return Native.DllImports.boxaaWrite(filename, (HandleRef)this) == 0;
        }

        /// <summary>
        /// Explicitly cast IntPtr to Boxa
        /// </summary>
        /// <param name="pointer"></param>
        public static explicit operator Boxaa(IntPtr pointer)
        {
            if (pointer != IntPtr.Zero)
            {
                return new Boxaa(pointer);
            }
            else
            {
                return null;
            }
        }
    }
}
