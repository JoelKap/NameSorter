using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter.Service;

namespace NameSorter.Test
{
    [TestClass]
    public class NameSorterTests
    {
        private NameProcessor processor;

        [TestInitialize]
        public void Setup()
        {
            processor = new();
        }

        [TestMethod]
        public void SortByLastName_SortsCorrectly()
        {
            // Arrange
            string inputNames = "Janet Parsons\r\nVaughn Lewis\r\nAdonis Julius Archer";
            List<NameModel> expected = new List<NameModel>
            {
                new NameModel { GivenNames = "Adonis Julius", LastName = "Archer" },
                new NameModel { GivenNames = "Vaughn", LastName = "Lewis" },
                new NameModel { GivenNames = "Janet", LastName = "Parsons" }
            };

            // Act
            var result = processor.SortByLastName(inputNames);

            // Assert
            CollectionAssert.AreEqual(expected, result, new NameModelComparer());
        }

        [TestMethod]
        public void SaveSortedNames_SaveToFileCorrectly()
        { 
            // Arrange
            string expectedFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-output.txt");
            var names = new List<NameModel> { new NameModel { GivenNames = "Janet", LastName = "Parsons" } };

            var processor = new NameProcessor(); 

            if (File.Exists(expectedFilePath))
                File.Delete(expectedFilePath);

            // Act
            processor.SaveSortedNames(names, expectedFilePath);

            // Assert
            Assert.IsTrue(File.Exists(expectedFilePath));
            string[] lines = File.ReadAllLines(expectedFilePath);
            Assert.AreEqual("Janet Parsons", lines[0]);

            // Clean up
            File.Delete(expectedFilePath); 
        }

        [TestMethod]
        public void ExtractLastNameAndGivenNames_ReturnsCorrectNames()
        {
            // Arrange
            string fullName = "Janet Parsons";

            // Act
            var (lastName, givenNames) = processor.ExtractLastNameAndGivenNames(fullName);

            // Assert
            Assert.AreEqual("Parsons", lastName);
            Assert.AreEqual("Janet", givenNames);
        }
    }

    public class NameModelComparer : Comparer<NameModel>
    {
        public override int Compare(NameModel x, NameModel y)
        {
            if (x.LastName != y.LastName) return x.LastName.CompareTo(y.LastName);
            return x.GivenNames.CompareTo(y.GivenNames);
        }
    }
}
