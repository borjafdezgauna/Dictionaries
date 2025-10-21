using Common;

namespace UnitTests
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



        [Fact]
        public void BinaryTreeDictionaryReaderWriter()
        {
            BinaryTreeDictionary<string, int> numbers = new BinaryTreeDictionary<string, int>();
            numbers.Add("bat", 1);
            numbers.Add("zortzi", 8);
            numbers.Add("hamar", 10);
            numbers.Add("bederatzi", 9);
            numbers.Add("zero", 0);

            Common.Tests.TestReaderWriter(numbers, "numbers-dictionary.txt", (word) => word, (number) => number.ToString(),
                (wordString) => wordString, (numberString) => int.Parse(numberString),
                (message) => Assert.Fail(message));


            BinaryTreeDictionary<int, double> grades = new BinaryTreeDictionary<int, double>();
            grades.Add(1234, 4.25);
            grades.Add(2133, 1.35);
            grades.Add(3312, 8.71);
            grades.Add(6544, 9.1);
            grades.Add(7092, 6.25);

            Common.Tests.TestReaderWriter(grades, "grades-dictionary.txt", (id) => id.ToString(), (grade) => grade.ToString(),
                (idString) => int.Parse(idString), (gradeString) => double.Parse(gradeString),
                (message) => Assert.Fail(message));
        }

        [Fact]
        public void HashTableDictionaryReaderWriter()
        {
            HashTableDictionary<string, int> numbers = new HashTableDictionary<string, int>();
            numbers.Add("bat", 1);
            numbers.Add("zortzi", 8);
            numbers.Add("hamar", 10);
            numbers.Add("bederatzi", 9);
            numbers.Add("zero", 0);

            Common.Tests.TestReaderWriter(numbers, "numbers-dictionary.txt", (word) => word, (number) => number.ToString(),
                (wordString) => wordString, (numberString) => int.Parse(numberString),
                (message) => Assert.Fail(message));


            HashTableDictionary<int, double> grades = new HashTableDictionary<int, double>();
            grades.Add(1234, 4.25);
            grades.Add(2133, 1.35);
            grades.Add(3312, 8.71);
            grades.Add(6544, 9.1);
            grades.Add(7092, 6.25);

            Common.Tests.TestReaderWriter(grades, "grades-dictionary.txt", (id) => id.ToString(), (grade) => grade.ToString(),
                (idString) => int.Parse(idString), (gradeString) => double.Parse(gradeString),
                (message) => Assert.Fail(message));
        }

        [Fact]
        public void DictionaryReaderWriterSpecialCharacters()
        {
            HashTableDictionary<string, string> texts = new HashTableDictionary<string, string>();
            texts.Add("Izena:\nJacinto", "Nombre:Jacinto");
            texts.Add("Abizena:\nRamírez", "Apellido:Ramírez");

            DictionaryReaderWriter readerWriter = new DictionaryReaderWriter();
            bool success = readerWriter.Write(texts, "special-characters.txt", (word) => word, (word) => word);
            Assert.True(success);

            BinaryTreeDictionary<string, string> readFromFile = new BinaryTreeDictionary<string, string>();
            success = readerWriter.Read(readFromFile, "special-characters.txt", (word) => word, (word) => word);
            Assert.True(success);

            Common.Tests.TestReaderWriter(texts, "special-characters.txt", (word) => word, (word) => word,
                (word) => word, (word) => word,
                (message) => Assert.Fail(message));
        }
    }
}