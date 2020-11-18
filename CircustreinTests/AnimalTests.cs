using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Circustrein.Tests
{
    [TestClass()]
    public class AnimalTests
    {
        [TestMethod()]
        public void CompatibleWith_TwoMeateaters_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;
            Animal primaryAnimal = new Animal(Sizes.grote, Types.vleeseter);
            Animal secundairyAnimal = new Animal(Sizes.grote, Types.vleeseter);

            // Act
            bool actual = primaryAnimal.CompatibleWith(secundairyAnimal);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompatibleWith_MediumMeateaterMediumPlanteater_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;
            Animal primaryAnimal = new Animal(Sizes.middelgrote, Types.vleeseter);
            Animal secundairyAnimal = new Animal(Sizes.middelgrote, Types.planteter);

            // Act
            bool actual = primaryAnimal.CompatibleWith(secundairyAnimal);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompatibleWith_MediumMeaterBigPlanteater_ShouldReturnTrue()
        {
            // Arrange
            bool expected = true;
            Animal primaryAnimal = new Animal(Sizes.middelgrote, Types.vleeseter);
            Animal secundairyAnimal = new Animal(Sizes.grote, Types.planteter);

            // Act
            bool actual = primaryAnimal.CompatibleWith(secundairyAnimal);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompatibleWith_TwoPlanteaters_ShouldReturnTrue()
        {
            // Arrange
            bool expected = true;
            Animal primaryAnimal = new Animal(Sizes.grote, Types.planteter);
            Animal secundairyAnimal = new Animal(Sizes.grote, Types.planteter);

            // Act
            bool actual = primaryAnimal.CompatibleWith(secundairyAnimal);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}