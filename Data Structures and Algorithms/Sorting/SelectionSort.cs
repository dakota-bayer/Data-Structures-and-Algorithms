namespace DataStructuresAndAlgorithms.Sorting
{
    public class SelectionSort : ISorter
    {
        public int[] Sort(int[] array)
        {
            ArgumentNullException.ThrowIfNull(array);

            if (array.Length < 2) return array;

            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int minValue = array[minIndex];
                array[minIndex] = array[i];
                array[i] = minValue;
            }

            return array;
        }
    }
}