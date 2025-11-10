using Common;

namespace UnitTests
{
    public class UnitTests
    {
        [Fact]
        public void Test1_BinaryTreeDict_AddGetCount()
        {
            TimeoutHandler.Test(Common.Tests.Test1_AddGetCount, new BinaryTreeDictionary<int, string>(), 1, Console.WriteLine, Assert.Fail);
        }

        [Fact]
        public void Test2_BinaryTreeDict_AddDuplicate()
        {
            TimeoutHandler.Test(Common.Tests.Test2_AddDuplicate, new BinaryTreeDictionary<int, string>(), 1, Console.WriteLine, Assert.Fail);
        }

        [Fact]
        public void Test3_BinaryTreeDict_Remove()
        {
            TimeoutHandler.Test(Common.Tests.Test3_Remove, new BinaryTreeDictionary<int, string>(), 1, Console.WriteLine, Assert.Fail);
        }

        [Fact]
        public void Test4_BinaryTreeDict_RemoveNonExistent()
        {
            TimeoutHandler.Test(Common.Tests.Test4_RemoveNonExistent, new BinaryTreeDictionary<int, string>(), 1, Console.WriteLine, Assert.Fail);
        }

        [Fact]
        public void Test5_BinaryTreeDict_Performance()
        {
            Common.Tests.TestPerformanceWithTimeout(new BinaryTreeDictionary<int, int>(), Console.WriteLine, Assert.Fail);
        }

        
        [Fact]
        public void Test6_HashTableDict_AddGetCount()
        {
            TimeoutHandler.Test(Common.Tests.Test1_AddGetCount, new HashTableDictionary<int, string>(), 1, Console.WriteLine, Assert.Fail);
        }
        [Fact]
        public void Test7_HashTableDict_AddDuplicate()
        {
            TimeoutHandler.Test(Common.Tests.Test2_AddDuplicate, new HashTableDictionary<int, string>(), 1, Console.WriteLine, Assert.Fail);
        }
        [Fact]
        public void Test8_HashTableDict_Remove()
        {
            TimeoutHandler.Test(Common.Tests.Test3_Remove, new HashTableDictionary<int, string>(), 1, Console.WriteLine, Assert.Fail);
        }
        [Fact]
        public void Test9_HashTableDict_RemoveNonExistent()
        {
            TimeoutHandler.Test(Common.Tests.Test4_RemoveNonExistent, new HashTableDictionary<int, string>(), 1, Console.WriteLine, Assert.Fail);
        }

        [Fact]
        public void Test10_HashTableDict_Performance()
        {
            Common.Tests.TestPerformanceWithTimeout(new HashTableDictionary<int, int>(), Console.WriteLine, Assert.Fail);
        }

        [Fact]
        public void Test9_ReaderWriter_BinaryTreeDict()
        {
            BinaryTreeDictionary<string, int> numbers = new BinaryTreeDictionary<string, int>();
            TimeoutHandler.Test(Common.Tests.TestReaderWriterStringInt, numbers, "numbers-dictionary-bin-tree.txt", 1, Console.WriteLine, Assert.Fail);

            BinaryTreeDictionary<int, double> grades = new BinaryTreeDictionary<int, double>();
            TimeoutHandler.Test(Common.Tests.TestReaderWriterIntDouble, grades, "grades-dictionary-bin-tree.txt", 1, Console.WriteLine, Assert.Fail);
        }


        [Fact]
        public void Test10_ReaderWriter_HashTableDict()
        {
            HashTableDictionary<string, int> numbers = new HashTableDictionary<string, int>();
            TimeoutHandler.Test(Common.Tests.TestReaderWriterStringInt, numbers, "numbers-dictionary-hash-table.txt", 1, Console.WriteLine, Assert.Fail);

            HashTableDictionary<int, double> grades = new HashTableDictionary<int, double>();
            TimeoutHandler.Test(Common.Tests.TestReaderWriterIntDouble, grades, "grades-dictionary-hash-table.txt", 1, Console.WriteLine, Assert.Fail);
        }
        
        

        [Fact]
        public void Test10_ReaderWriter_Special_BinaryTreeDict()
        {
            string filename = "special-characters-binary-tree.txt";
            Common.Tests.TestReaderWriterSpecialCharacters(new BinaryTreeDictionary<string, string>(),
                new BinaryTreeDictionary<string, string>(), filename, Assert.Fail);
        }
        [Fact]
        public void Test11_ReaderWriter_Special_HashTableDict()
        {
            string filename = "special-characters-hash-table.txt";
            Common.Tests.TestReaderWriterSpecialCharacters(new HashTableDictionary<string, string>(),
                new HashTableDictionary<string, string>(), filename, Assert.Fail);
        }
        
    }
}