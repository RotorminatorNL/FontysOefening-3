using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Circustrein.Tests
{
    [TestClass()]
    public class WagonTests
    {
        [TestMethod()]
        public void AddAnimalToWagon_ShouldReturnFalse()
        {
            // Arrange
            bool expected = false;

            List<Animal> animals = new List<Animal>
            {
                new Animal(Sizes.grote, Types.vleeseter),
                new Animal(Sizes.grote, Types.vleeseter)
            };

            Wagon wagon = new Wagon(1);
            wagon.AddAnimalToWagon(animals[0]);
            animals.Remove(animals[0]);

            // Act
            bool actual = wagon.AddAnimalToWagon(animals[0]);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddAnimalToWagon_ShouldReturnTrue()
        {
            // Arrange
            bool expected = true;

            List<Animal> animals = new List<Animal>
            {
                new Animal(Sizes.grote, Types.planteter),
                new Animal(Sizes.middelgrote, Types.vleeseter)
            };

            Wagon wagon = new Wagon(1);
            wagon.AddAnimalToWagon(animals[0]);
            animals.Remove(animals[0]);

            // Act
            bool actual = wagon.AddAnimalToWagon(animals[0]);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}