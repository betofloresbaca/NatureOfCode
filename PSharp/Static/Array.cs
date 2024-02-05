using static PSharp.Static.Math;

namespace PSharp.Static
{
    public static class Array
    {
        public static T[] Append<T>(T[] array, T value)
        {
            T[] newArray = Expand(array, array.Length + 1);
            newArray[newArray.Length - 1] = value;
            return newArray;
        }

        public static void ArrayCopy<T>(
            T[] srcArray,
            int srcPosition,
            T[] dstArray,
            int dstPosition,
            int length
        )
        {
            System.Array.Copy(srcArray, srcPosition, dstArray, dstPosition, length);
        }

        public static T[] Concat<T>(T[] array1, T[] array2)
        {
            T[] newArray = Expand(array1, array1.Length + array2.Length);
            System.Array.Copy(array2, 0, newArray, array1.Length, array2.Length);
            return newArray;
        }

        public static T[] Expand<T>(T[] array, int? newSize = null)
        {
            var size = newSize ?? array.Length * 2;
            T[] newArray = new T[size];
            System.Array.Copy(array, 0, newArray, 0, Min(array.Length, size));
            return newArray;
        }

        public static T[] Reverse<T>(T[] array)
        {
            T[] newArray = Expand(array, array.Length);
            System.Array.Reverse(newArray, 0, newArray.Length);
            return newArray;
        }

        public static T[] Shorten<T>(T[] array)
        {
            return Expand(array, array.Length - 1);
        }

        public static T[] Sort<T>(T[] array)
        {
            T[] newArray = Expand(array, array.Length);
            System.Array.Sort(newArray);
            return newArray;
        }

        public static T[] Splice<T>(T[] array, T[] value, int index)
        {
            T[] newArray = new T[array.Length + value.Length];
            System.Array.Copy(array, 0, newArray, 0, index);
            System.Array.Copy(value, 0, newArray, index, value.Length);
            System.Array.Copy(array, index, newArray, index + value.Length, array.Length - index);
            return newArray;
        }

        public static T[] Subset<T>(T[] array, int start, int count)
        {
            T[] newArray = new T[count];
            System.Array.Copy(array, start, newArray, 0, count);
            return newArray;
        }
    }
}
