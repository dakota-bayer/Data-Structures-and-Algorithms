namespace DataStructuresAndAlgorithms.Sorting
{
    public class BubbleSort : ISorter
    {
        public BubbleSort()
        { }

        /*
         *  After the first pass, the largest element is guaranteed to be at the end of the array,
         *      after the second pass, the second largest element is in position, and so on.
         *  That is why the upper bound in the inner loop (n-1-i) decreases with each pass: we don't have to re-visit the end of the array.
         */

        public int[] Sort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (array.Length < 2)
            {
                return array;
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            return array;
        }
    }
}