using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Circustrein.Tests
{
    [TestClass()]
    public class AnimalTests
    {
        [TestMethod()]
        public void CompatibleWith_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;

            // Act
            Animal primaryAnimal = new Animal(Sizes.middelgrote, Types.planteter);
            Animal secundairyAnimal = new Animal(Sizes.middelgrote, Types.vleeseter);
            bool actual = primaryAnimal.CompatibleWith(secundairyAnimal);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompatibleWith_ShouldReturnTrue()
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