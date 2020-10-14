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

            // Act
            List<Animal> animals = new List<Animal>
            {
                new Animal(Sizes.grote, Types.vleeseter),
                new Animal(Sizes.grote, Types.vleeseter)
            };

            Wagon wagon = new Wagon(1);
            wagon.AddAnimalToWagon(animals, animals[0]);

            bool actual = wagon.AddAnimalToWagon(animals, animals[0]);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddAnimalToWagon_ShouldReturnTrue()
        {
            // Arrange
            bool expected = true;

            // Act
            List<Animal> animals = new List<Animal>
            {
                new Animal(Sizes.grote, Types.planteter),
                new Animal(Sizes.middelgrote, Types.vleeseter)
            };

            Wagon wagon = new Wagon(1);
            wagon.AddAnimalToWagon(animals, animals[0]);

            bool actual = wagon.AddAnimalToWagon(animals, animals[0]);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAnimalsInWagon_ShouldBeEqual()
        {
            Animal smallMeatEater = new Animal(Sizes.kleine, Types.vleeseter);
            Animal bigPlantEater = new Animal(Sizes.grote, Types.planteter);
            Animal mediumPlantEater = new Animal(Sizes.middelgrote, Types.planteter);

            // Arrange
            List<Animal> expected = new List<Animal>()
            {
                smallMeatEater,
                bigPlantEater,
                mediumPlantEater
            };

            // Act
            List<Animal> animals = new List<Animal>
            {
                smallMeatEater,
                bigPlantEater,
                mediumPlantEater
            };

            Wagon wagon = new Wagon(1);
            wagon.AddAnimalToWagon(animals, animals[0]);
            wagon.AddAnimalToWagon(animals, animals[0]);
            wagon.AddAnimalToWagon(animals, animals[0]);

            List<Animal> actual = wagon.GetAnimalsInWagon();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}