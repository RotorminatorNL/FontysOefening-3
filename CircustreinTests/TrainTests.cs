using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Circustrein.Tests
{
    [TestClass()]
    public class TrainTests
    {
        [TestMethod()]
        public void SortingListTest()
        {
            Animal bigMeatEater = new Animal(Sizes.grote, Types.vleeseter);
            Animal mediumMeatEater = new Animal(Sizes.middelgrote, Types.vleeseter);
            Animal smallMeatEater = new Animal(Sizes.kleine, Types.vleeseter);

            Animal bigPlantEater = new Animal(Sizes.grote, Types.planteter);
            Animal mediumPlantEater = new Animal(Sizes.middelgrote, Types.planteter);
            Animal smallPlantEater = new Animal(Sizes.kleine, Types.planteter);

            // Arrange
            List<Animal> expected = new List<Animal>
            {
                bigMeatEater,
                mediumMeatEater,
                smallMeatEater,
                bigPlantEater,
                mediumPlantEater,
                smallPlantEater
            };

            // Act
            List<Animal> actual = new List<Animal>
            {
                bigMeatEater,
                smallPlantEater,
                bigPlantEater,
                smallMeatEater,
                mediumMeatEater,
                mediumPlantEater
            };

            actual = Train.SortingList(actual);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}