namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void BinaryTreeDictionary()
        {
            Assert.True(Common.Tests.TestDictionaryIntString(new BinaryTreeDictionary<int, string>()));
        }
        [Fact]
        public void HashTableDictionary()
        {
            Assert.True(Common.Tests.TestDictionaryIntString(new HashTableDictionary<int, string>()));
        }
    }
}