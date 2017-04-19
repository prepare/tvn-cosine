using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// boxa.h
    /// </summary>
    public class Boxa : LeptonicaObjectBase
    {
        public Boxa(IntPtr pointer)
            : base(pointer)
        { }

        /// <summary>
        /// boxaCreate()
        /// </summary>
        /// <param name="n">n  initial number of ptrs</param>
        /// <returns>boxa, or NULL on error</returns>
        public static Boxa Create(int n)
        {
            return (Boxa)Native.DllImports.boxaCreate(n);
        }

        /// <summary>
        /// (1) See pix.h for description of the copyflag.
        /// (2) The copy-clone makes a new boxa that holds clones of each box.
        /// </summary>
        /// <param name="copyflag">copyflag L_COPY, L_CLONE, L_COPY_CLONE</param>
        /// <returns>new boxa, or NULL on error</returns>
        public Boxa Copy(InsertionType copyflag)
        {
            return (Boxa)Native.DllImports.boxaCopy((HandleRef)this, copyflag);
        }

        /// <summary>
        /// boxaAddBox()
        /// </summary>
        /// <param name="box">box  to be added</param>
        /// <param name="copyflag">copyflag L_INSERT, L_COPY, L_CLONE</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryAddBox(Box box, InsertionType copyflag)
        {
            return Native.DllImports.boxaAddBox((HandleRef)this, (HandleRef)box, copyflag) == 0;
        }

        /// <summary>
        /// (1) Reallocs with doubled size of ptr array.
        /// </summary>
        /// <returns>true if OK, false on error</returns>
        public bool TryExtendArray()
        {
            return Native.DllImports.boxaExtendArray((HandleRef)this) == 0;
        }

        /// <summary>
        /// (1) If necessary, reallocs new boxa ptr array to %size.
        /// </summary>
        /// <param name="size">size new size of boxa array</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryExtendArrayToSize(int size)
        {
            return Native.DllImports.boxaExtendArrayToSize((HandleRef)this, size) == 0;
        }

        /// <summary>
        /// boxaGetCount()
        /// </summary>
        /// <returns>count of all boxes; 0 if no boxes or on error</returns>
        public int GetCount()
        {
            return Native.DllImports.boxaGetCount((HandleRef)this);
        }

        /// <summary>
        /// boxaGetValidCount()
        /// </summary>
        /// <returns>count of valid boxes; 0 if no valid boxes or on error</returns>
        public int GetValidCount()
        {
            return Native.DllImports.boxaGetValidCount((HandleRef)this);
        }

        /// <summary>
        /// boxaGetBox()
        /// </summary>
        /// <param name="index">index  to the index-th box</param>
        /// <param name="accessflag">accessflag  L_COPY or L_CLONE</param>
        /// <returns>box, or NULL on error</returns>
        public Box GetBox(int index, InsertionType accessflag)
        {
            return (Box)Native.DllImports.boxaGetBox((HandleRef)this, index, accessflag);
        }

        /// <summary>
        ///      (1) This returns NULL for an invalid box in a boxa.
        ///          For a box to be valid, both the width and height must be > 0.
        ///      (2) We allow invalid boxes, with w = 0 or h = 0, as placeholders
        ///          in boxa for which the index of the box in the boxa is important.
        /// This is an atypical situation; usually you want to put only
        ///          valid boxes in a boxa.
        /// </summary>
        /// <param name="index">index  to the index-th box</param>
        /// <param name="accessflag">accessflag  L_COPY or L_CLONE</param>
        /// <returns>box, or NULL on error</returns>
        public Box GetValidBox(int index, InsertionType accessflag)
        {
            return (Box)Native.DllImports.boxaGetValidBox((HandleRef)this, index, accessflag);
        }

        /// <summary>
        /// boxaFindInvalidBoxes()
        /// </summary>
        /// <returns>numa of invalid boxes; NULL if there are none or on error</returns>
        public Numa FindInvalidBoxes()
        {
            return (Numa)Native.DllImports.boxaFindInvalidBoxes((HandleRef)this);
        }

        /// <summary>
        /// boxaGetBoxGeometry()
        /// </summary>
        /// <param name="index">index  to the index-th box</param>
        /// <param name="px">px, py, pw, ph [optional]  each can be null</param>
        /// <param name="py">px, py, pw, ph [optional]  each can be null</param>
        /// <param name="pw">px, py, pw, ph [optional]  each can be null</param>
        /// <param name="ph">px, py, pw, ph [optional]  each can be null</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryGetBoxGeometry(int index, out int px, out int py, out int pw, out int ph)
        {
            return Native.DllImports.boxaGetBoxGeometry((HandleRef)this, index, out px, out py, out pw, out ph) == 0;
        }

        /// <summary>
        /// boxaIsFull()
        /// </summary>
        /// <param name="pfull">pfull 1 if boxa is full</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryIsFull(out bool pfull)
        {
            return Native.DllImports.boxaIsFull((HandleRef)this, out pfull) == 0;
        }

        /// <summary>
        ///      (1) In-place replacement of one box.
        ///      (2) The previous box at that location, if any, is destroyed.
        /// </summary>
        /// <param name="index">index  to the index-th box</param>
        /// <param name="box">box insert to replace existing one</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryReplaceBox(int index, Box box)
        {
            return Native.DllImports.boxaReplaceBox((HandleRef)this, index, (HandleRef)box) == 0;
        }

        /// <summary>
        /// (1) This shifts box[i] --> box[i + 1] for all i >= index,
        ///     and then inserts box as box[index].
        /// (2) To insert at the beginning of the array, set index = 0.
        /// (3) To append to the array, it's easier to use boxaAddBox().
        /// (4) This should not be used repeatedly to insert into large arrays,
        ///     because the function is O(n).
        /// </summary>
        /// <param name="index">index location in boxa to insert new value</param>
        /// <param name="box">box new box to be inserted</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryInsertBox(int index, Box box)
        {
            return Native.DllImports.boxaInsertBox((HandleRef)this, index, (HandleRef)box) == 0;
        }

        /// <summary>
        ///  (1) This removes box[index] and then shifts
        ///      box[i] --> box[i - 1] for all i > index.
        ///  (2) It should not be used repeatedly to remove boxes from
        ///      large arrays, because the function is O(n).
        /// </summary>
        /// <param name="index">index of box to be removed</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryRemoveBox(int index)
        {
            return Native.DllImports.boxaRemoveBox((HandleRef)this, index) == 0;
        }

        /// <summary>
        ///  (1) This removes box[index] and then shifts
        ///      box[i] --> box[i - 1] for all i > index.
        ///  (2) It should not be used repeatedly to remove boxes from
        ///      large arrays, because the function is O(n).
        /// </summary>
        /// <param name="index">index of box to be removed</param>
        /// <param name="pbox">pbox [optional] removed box</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryRemoveBoxAndSave(int index, out Box pbox)
        {
            IntPtr pboxPtr;
            var success = Native.DllImports.boxaRemoveBoxAndSave((HandleRef)this, index, out pboxPtr) == 0;

            if (success)
            {
                pbox = (Box)pboxPtr;
            }
            else
            {
                pbox = null;
            }

            return success;
        }

        /// <summary>
        /// (1) This makes a copy/clone of each valid box.
        /// </summary> 
        /// <param name="copyflag">copyflag L_COPY or L_CLONE</param>
        /// <returns>boxad if OK, NULL on error</returns>
        public Boxa SaveValid(InsertionType copyflag)
        {
            return (Boxa)Native.DllImports.boxaSaveValid((HandleRef)this, copyflag);
        }

        /// <summary>
        ///       (1) This initializes a boxa by filling up the entire box ptr array
        ///           with copies of %box.If %box == NULL, use a placeholder box
        ///           of zero size.Any existing boxes are destroyed.
        /// 
        /// After this opepration, the number of boxes is equal to
        ///           the number of allocated ptrs.
        ///       (2) Note that we use boxaReplaceBox() instead of boxaInsertBox().
        ///           They both have the same effect when inserting into a NULL ptr
        ///           in the boxa ptr array:
        ///       (3) Example usage.This function is useful to prepare for a
        ///  random insertion (or replacement) of boxes into a boxa.
        /// 
        /// To randomly insert boxes into a boxa, up to some index "max":
        ///              Boxa* boxa = boxaCreate(max);
        ///              boxaInitFull(boxa, NULL);
        ///           If you want placeholder boxes of non-zero size:
        ///              Boxa* boxa = boxaCreate(max);
        ///              Box* box = boxCreate(...);
        ///              boxaInitFull(boxa, box);
        ///              boxDestroy(box);
        ///           If we have an existing boxa with a smaller ptr array, it can
        ///           be reused for up to max boxes:
        ///              boxaExtendArrayToSize(boxa, max);
        ///              boxaInitFull(boxa, NULL);
        ///           The initialization allows the boxa to always be properly
        ///  filled, even if all the boxes are not later replaced.
        /// 
        /// If you want to know which boxes have been replaced,
        ///           and you initialized with invalid zero-sized boxes,
        ///           use boxaGetValidBox() to return NULL for the invalid boxes.
        /// </summary>
        /// <param name="box">box [optional] to be replicated into the entire ptr array</param>
        /// <returns>true if OK, false on error</returns>
        public bool InitFull(Box box)
        {
            return Native.DllImports.boxaInitFull((HandleRef)this, (HandleRef)box) == 0;
        }

        /// <summary>
        /// (1) This destroys all boxes in the boxa, setting the ptrs to null.  The number of allocated boxes, n, is set to 0.
        /// </summary>
        /// <returns>true if OK, false on error</returns>
        public bool Clear()
        {
            return Native.DllImports.boxaClear((HandleRef)this) == 0;
        }

        /// <summary>
        ///  (1) Decrements the ref count and, if 0, destroys the boxa.
        ///  (2) Always nulls the input ptr.
        /// </summary>
        public void Destroy()
        {
            var toDestroy = (IntPtr)this;
            Native.DllImports.boxaDestroy(ref toDestroy);
        }

        /// <summary>
        /// boxaRead()
        /// </summary>
        /// <param name="filename">filename</param>
        /// <returns>true if OK, false on error</returns>
        public static Boxa Read(string filename)
        {
            return (Boxa)Native.DllImports.boxaRead(filename);
        }

        /// <summary>
        /// boxaWrite()
        /// </summary>
        /// <param name="filename">filename</param>
        /// <returns>true if OK, false on error</returns>
        public bool TryWrite(string filename)
        {
            return Native.DllImports.boxaWrite(filename, (HandleRef)this) == 0;
        }

        /// <summary>
        /// Explicitly cast IntPtr to Boxa
        /// </summary>
        /// <param name="pointer"></param>
        public static explicit operator Boxa(IntPtr pointer)
        {
            if (pointer != IntPtr.Zero)
            {
                return new Boxa(pointer);
            }
            else
            {
                return null;
            }
        }
    }
}
