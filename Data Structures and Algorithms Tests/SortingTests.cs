using DataStructuresAndAlgorithms.Sorting;

namespace AlgorithmTests
{
    public class SortingTests
    {
        [Theory]
        [MemberData(nameof(GetSorters))]
        public void Sort_ShouldSortSmallArrayCorrectly(ISorter sorter)
        {
            // Arrange
            var array = new int[] { 3, 2, 1, 5, 4 };
            var expected = new int[] { 1, 2, 3, 4, 5 };

            // Act
            var result = sorter.Sort(array);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetSorters))]
        public void Sort_ShouldSortLargeArrayCorrectly(ISorter sorter)
        {
            // Arrange
            var array = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            var result = sorter.Sort(array);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetSorters))]
        public void Sort_ShouldHandleEmptyArray(ISorter sorter)
        {
            // Arrange
            var array = new int[] { };
            var expected = new int[] { };

            // Act
            var result = sorter.Sort(array);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetSorters))]
        public void Sort_ShouldHandleSingleElementArray(ISorter sorter)
        {
            // Arrange
            var array = new int[] { 42 };
            var expected = new int[] { 42 };

            // Act
            var result = sorter.Sort(array);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetSorters))]
        public void Sort_ShouldHandleNullInput(ISorter sorter)
        {
            // Arrange
            int[] array = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(array));
        }

        public static IEnumerable<object[]> GetSorters()
        {
            yield return new object[] { new BubbleSort() };
            yield return new object[] { new SelectionSort() };
            yield return new object[] { new InsertionSort() };
        }
    }
}