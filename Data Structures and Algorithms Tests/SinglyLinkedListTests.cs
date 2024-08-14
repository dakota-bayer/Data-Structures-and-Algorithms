using DataStructures.SinglyLinkedList;

namespace DataStructureTests
{
    public class SinglyLinkedListTests
    {
        #region Random
        [Fact]
        public void GivenNewList_ReturnsProper()
        {
            var list = new SinglyLinkedList();

            Assert.Null(list.head);
            Assert.Equal(0, list.length);
            Assert.Equal(string.Empty, list.ToString());
        }

        #endregion Random

        #region Insert

        [Fact]
        public void Insert_GivenNewList_InsertsAtBeginning()
        {
            // Arrange
            var list = new SinglyLinkedList();

            // Act
            list.Insert(10);

            // Assert
            Assert.NotNull(list.head);
            Assert.False(list.head.HasNext());

            Assert.Equal(1, list.length);

            Assert.Equal("10", list.ToString());
        }

        [Fact]
        public void Insert_GivenExistingList_InsertsAtEnd()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);

            // Act
            list.Insert(40);

            // Assert
            Assert.Equal(4, list.length);
            Assert.Equal("10 20 30 40", list.ToString());
        }

        #endregion Insert

        #region InsertAt

        [Fact]
        public void InsertAt_GivenNegativeIndex_ThrowsException()
        {
            // Arrange
            var list = new SinglyLinkedList();

            // Act
            var func = () => list.InsertAt(-1, 10);

            // Assert
            Assert.Throws<IndexOutOfRangeException>(func);
        }

        [Fact]
        public void InsertAt_GivenIndexGreaterThanLength_ThrowsException()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(0);
            list.Insert(1);
            // Act
            var func = () => list.InsertAt(7, 10);

            // Assert
            Assert.Throws<IndexOutOfRangeException>(func);
        }

        [Fact]
        public void InsertAt_GivenNewList_InsertsAtBeginning()
        {
            // Arrange
            var list = new SinglyLinkedList();

            // Act
            list.InsertAt(0, 10);

            // Assert
            Assert.NotNull(list.head);
            Assert.False(list.head.HasNext());

            Assert.Equal(1, list.length);

            Assert.Equal("10", list.ToString());
        }

        [Fact]
        public void InsertAt_GivenExistingList_InsertsAtBeginning()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(20);
            list.Insert(30);
            list.Insert(40);

            // Act
            list.InsertAt(0, 10);

            // Assert
            Assert.Equal(4, list.length);
            Assert.Equal("10 20 30 40", list.ToString());

        }

        [Fact]
        public void InsertAt_GivenExistingList_InsertsInMiddle()
        {
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(40);

            // Act
            list.InsertAt(2, 30);

            // Assert
            Assert.Equal(4, list.length);
            Assert.Equal("10 20 30 40", list.ToString());
        }

        [Fact]
        public void InsertAt_GivenExistingList_InsertAtEnd()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);

            // Act
            list.InsertAt(3, 40);

            // Assert
            Assert.Equal(4, list.length);
            Assert.Equal("10 20 30 40", list.ToString());
        }
        #endregion InsertAt

        #region RemoveFirst

        [Fact]
        public void RemoveFirst_GivenNotFound_ReturnsFalse()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);
            list.Insert(40);

            // Act
            bool isDeleted = list.RemoveFirst(75);

            // Assert
            Assert.False(isDeleted);

            Assert.Equal(4, list.length);
            Assert.Equal("10 20 30 40", list.ToString());
        }

        [Fact]
        public void RemoveFirst_GivenEmptyList_ReturnsFalse()
        {
            // Arrange
            var list = new SinglyLinkedList();

            // Act
            bool isDeleted = list.RemoveFirst(10);

            // Assert
            Assert.False(isDeleted);

            Assert.Equal(0, list.length);
            Assert.Equal(string.Empty, list.ToString());
        }

        [Fact]
        public void RemoveFirst_GivenSingleElementList_RemovesFromStart()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);

            // Act
            bool isDeleted = list.RemoveFirst(10);

            // Assert
            Assert.True(isDeleted);

            Assert.Equal(0, list.length);
            Assert.Equal(string.Empty, list.ToString());
        }

        [Fact]
        public void RemoveFirst_GivenMultipleElementList_RemovesFromStart()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);
            list.Insert(40);

            // Act
            bool isDeleted = list.RemoveFirst(10);

            // Assert
            Assert.True(isDeleted);

            Assert.Equal(3, list.length);
            Assert.Equal("20 30 40", list.ToString());
        }

        [Fact]
        public void RemoveFirst_GivenMultipleElementList_RemovesFromEnd()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);
            list.Insert(40);

            // Act
            bool isDeleted = list.RemoveFirst(40);

            // Assert
            Assert.True(isDeleted);

            Assert.Equal(3, list.length);
            Assert.Equal("10 20 30", list.ToString());
        }

        [Fact]
        public void RemoveFirst_GivenDuplicatesList_RemovesOnlyOne()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(20);
            list.Insert(30);

            // Act
            bool isDeleted = list.RemoveFirst(20);

            // Assert
            Assert.True(isDeleted);

            Assert.Equal(3, list.length);
            Assert.Equal("10 20 30", list.ToString());
        }

        #endregion RemoveFirst

        #region RemoveAll

        [Fact]
        public void RemoveAll_GivenNotFound_RemovesNone()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);
            list.Insert(40);

            // Act
            list.RemoveAll(9999);

            // Act
            Assert.Equal(4, list.length);
            Assert.Equal("10 20 30 40", list.ToString());
        }

        [Fact]
        public void RemoveAll_GivenSingleFoundAtHead_ReassignsHead()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(9999);
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);
            list.Insert(40);

            // Act
            list.RemoveAll(9999);

            // Act
            Assert.Equal(4, list.length);
            Assert.Equal("10 20 30 40", list.ToString());
        }

        [Fact]
        public void RemoveAll_GivenMultipleFoundAtHead_ReassignsHead()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(9999);
            list.Insert(9999);
            list.Insert(9999);
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);
            list.Insert(40);

            // Act
            list.RemoveAll(9999);

            // Act
            Assert.Equal(4, list.length);
            Assert.Equal("10 20 30 40", list.ToString());
        }

        [Fact]
        public void RemoveAll_GivenSingleFoundAtTail_RemovesTail()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);
            list.Insert(40);
            list.RemoveAll(9999);

            // Act
            list.RemoveAll(9999);

            // Act
            Assert.Equal(4, list.length);
            Assert.Equal("10 20 30 40", list.ToString());
        }

        [Fact]
        public void RemoveAll_GivenMultipleFoundAtTail_RemovesTail()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);
            list.Insert(40);
            list.RemoveAll(9999);
            list.RemoveAll(9999);
            list.RemoveAll(9999);

            // Act
            list.RemoveAll(9999);

            // Act
            Assert.Equal(4, list.length);
            Assert.Equal("10 20 30 40", list.ToString());
        }

        [Fact]
        public void RemoveAll_GivenSingleFound_RemovesOne()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(9999);
            list.Insert(30);
            list.Insert(40);

            // Act
            list.RemoveAll(9999);

            // Act
            Assert.Equal(4, list.length);
            Assert.Equal("10 20 30 40", list.ToString());
        }

        [Fact]
        public void RemoveAll_GivenMultipleFoundTogether_RemovesAll()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);
            list.Insert(9999);
            list.Insert(9999);
            list.Insert(9999);
            list.Insert(40);
            list.Insert(50);
            list.Insert(60);
            list.Insert(70);
            list.Insert(80);

            // Act
            list.RemoveAll(9999);

            // Act
            Assert.Equal(8, list.length);
            Assert.Equal("10 20 30 40 50 60 70 80", list.ToString());
        }

        [Fact]
        public void RemoveAll_GivenMultipleFoundApart_RemovesAll()
        {
            // Arrange
            var list = new SinglyLinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);
            list.Insert(9999);
            list.Insert(40);
            list.Insert(50);
            list.Insert(9999);
            list.Insert(9999);
            list.Insert(60);
            list.Insert(70);
            list.Insert(80);

            // Act
            list.RemoveAll(9999);

            // Act
            Assert.Equal(8, list.length);
            Assert.Equal("10 20 30 40 50 60 70 80", list.ToString());
        }

        #endregion RemoveAll
    }
}