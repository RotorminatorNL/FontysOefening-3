using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Circustrein.Tests
{
    [TestClass()]
    public class WagonTests
    {
        [TestMethod()]
        public void AddAnimalToWagon_TwoMeateaters_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;

            Wagon wagon = new Wagon(1);
            wagon.AddAnimalToWagon(new Animal(Sizes.grote, Types.vleeseter));

            // Act
            bool actual = wagon.AddAnimalToWagon(new Animal(Sizes.middelgrote, Types.vleeseter));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddAnimalToWagon_OneBigMeateaterOneMediumPlanteater_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;

            Wagon wagon = new Wagon(1);
            wagon.AddAnimalToWagon(new Animal(Sizes.grote, Types.vleeseter));

            // Act
            bool actual = wagon.AddAnimalToWagon(new Animal(Sizes.middelgrote, Types.planteter));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddAnimalToWagon_OneBigPlanteaterOneMediumMeateater_ShouldReturnTrue()
        {
            // Arrange
            bool expected = true;

            Wagon wagon = new Wagon(1);
            wagon.AddAnimalToWagon(new Animal(Sizes.grote, Types.planteter));

            // Act
            bool actual = wagon.AddAnimalToWagon(new Animal(Sizes.middelgrote, Types.vleeseter));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddAnimalToWagon_TwoBigPlanteaters_ShouldReturnTrue()
        {
            // Arrange
            bool expected = true;

            Wagon wagon = new Wagon(1);
            wagon.AddAnimalToWagon(new Animal(Sizes.grote, Types.planteter));

            // Act
            bool actual = wagon.AddAnimalToWagon(new Animal(Sizes.grote, Types.planteter));

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}