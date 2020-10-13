using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Circustrein.Tests
{
    [TestClass()]
    public class WagonTests
    {
        [TestMethod()]
        public void EnoughSpaceTest()
        {
            // Arrange
            bool expected = false;

            // Act
            List<Animal> animals = new List<Animal>
            {
                new Animal(Sizes.grote, Types.planteter),
                new Animal(Sizes.middelgrote, Types.planteter)
            };

            int wagonID = 1;
            Wagon wagon = new Wagon(wagonID);
            wagon.AddAnimalToWagon(animals, animals[0]);
            wagon.AddAnimalToWagon(animals, animals[0]);

            Animal animalThatWantsToEnter = new Animal(Sizes.middelgrote, Types.planteter);

            bool actual = wagon.EnoughSpace(animalThatWantsToEnter);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}