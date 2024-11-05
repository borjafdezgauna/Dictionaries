using Common;

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

        private void CompareDictionaries<TKey, TValue>(Common.IDictionary<TKey, TValue> dictionary1, Common.IDictionary<TKey, TValue> dictionary2)
        {
            Assert.Equal(dictionary1.Count(), dictionary2.Count());

            foreach (TKey key in dictionary1.Keys())
            {
                Assert.Equal(dictionary1.Get(key), dictionary2.Get(key));
            }
        }

        [Fact]
        public void BinaryTreeReaderWriter()
        {
            BinaryTreeDictionary<string, int> numbers = new BinaryTreeDictionary<string, int>();
            numbers.Add("bat", 1);
            numbers.Add("zortzi", 8);
            numbers.Add("hamar", 10);
            numbers.Add("bederatzi", 9);
            numbers.Add("zero", 0);

            DictionaryReaderWriter readerWriter = new DictionaryReaderWriter();
            bool success = readerWriter.Write(numbers, "number-dictionary.txt", (word) => word, (number) => number.ToString());
            Assert.True(success);

            BinaryTreeDictionary<string, int> numbersFromFile = new BinaryTreeDictionary<string, int>();
            success = readerWriter.Read(numbersFromFile, "number-dictionary.txt", (wordString) => wordString, (numberString) => int.Parse(numberString));
            Assert.True(success);

            CompareDictionaries(numbers, numbersFromFile);

            BinaryTreeDictionary<int, double> grades = new BinaryTreeDictionary<int, double>();
            grades.Add(1234, 4.25);
            grades.Add(2133, 1.35);
            grades.Add(3312, 8.71);
            grades.Add(6544, 9.1);
            grades.Add(7092, 6.25);

            success = readerWriter.Write(grades, "grades-dictionary.txt", (id) => id.ToString(), (grade) => grade.ToString());
            Assert.True(success);

            BinaryTreeDictionary<int, double> gradesReadFromFile = new BinaryTreeDictionary<int, double>();
            success = readerWriter.Read(gradesReadFromFile, "grades-dictionary.txt", (idString) => int.Parse(idString), (gradeString) => double.Parse(gradeString));
            Assert.True(success);

            CompareDictionaries(grades, gradesReadFromFile);
        }

        [Fact]
        public void HashTableReaderWriter()
        {
            HashTableDictionary<string, int> numbers = new HashTableDictionary<string, int>();
            numbers.Add("bat", 1);
            numbers.Add("zortzi", 8);
            numbers.Add("hamar", 10);
            numbers.Add("bederatzi", 9);
            numbers.Add("zero", 0);

            DictionaryReaderWriter readerWriter = new DictionaryReaderWriter();
            bool success = readerWriter.Write(numbers, "number-dictionary-2.txt", (word) => word, (number) => number.ToString());
            Assert.True(success);

            BinaryTreeDictionary<string, int> numbersFromFile = new BinaryTreeDictionary<string, int>();
            success = readerWriter.Read(numbersFromFile, "number-dictionary-2.txt", (wordString) => wordString, (numberString) => int.Parse(numberString));
            Assert.True(success);

            CompareDictionaries(numbers, numbersFromFile);

            HashTableDictionary<int, double> grades = new HashTableDictionary<int, double>();
            grades.Add(1234, 4.25);
            grades.Add(2133, 1.35);
            grades.Add(3312, 8.71);
            grades.Add(6544, 9.1);
            grades.Add(7092, 6.25);

            success = readerWriter.Write(grades, "grades-dictionary-2.txt", (id) => id.ToString(), (grade) => grade.ToString());
            Assert.True(success);

            BinaryTreeDictionary<int, double> gradesReadFromFile = new BinaryTreeDictionary<int, double>();
            success = readerWriter.Read(gradesReadFromFile, "grades-dictionary-2.txt", (idString) => int.Parse(idString), (gradeString) => double.Parse(gradeString));
            Assert.True(success);

            CompareDictionaries(grades, gradesReadFromFile);
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

            CompareDictionaries(texts, readFromFile);
        }
    }
}