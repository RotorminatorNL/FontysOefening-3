using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Circustrein.Tests
{
    [TestClass()]
    public class AnimalTests
    {
        [TestMethod()]
        public void CompatibleWithTest()
        {
            // Arrange
            bool expected = true;

            // Act
            Animal primaryAnimal = new Animal(Sizes.middelgrote,Types.vleeseter);
            Animal secundairyAnimal = new Animal(Sizes.grote, Types.planteter);
            bool actual = primaryAnimal.CompatibleWith(secundairyAnimal);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}