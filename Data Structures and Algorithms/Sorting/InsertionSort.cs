namespace DataStructuresAndAlgorithms.Sorting
{
    public class InsertionSort : ISorter
    {
        // MORE CONFUSING OF THE SORTING ALGORITHMS -- DEFINITELY DRAW IT OUT
        public int[] Sort(int[] array)
        {
            ArgumentNullException.ThrowIfNull(array);

            if (array.Length < 2) return array;

            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && key < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }

            return array;
        }

        // 1 3 5 8
    }
}