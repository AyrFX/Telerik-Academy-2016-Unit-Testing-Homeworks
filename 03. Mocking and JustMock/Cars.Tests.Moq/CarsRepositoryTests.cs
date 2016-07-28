using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Cars.Contracts;
using Cars.Data;
using Cars.Models;

namespace Cars.Tests.Moq
{
    [TestClass]
    public class CarsRepositoryTests
    {
        [TestMethod]
        public void ConstructorWithParameterShouldCreateObjectsProperly()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();

            //Act
            var repository = new CarsRepository(mockedDatabase.Object);

            //Assert
            Mock.Verify(mockedDatabase);
        }

        [TestMethod]
        public void ConstructorWithoutParameterShouldCreateObjectsProperly()
        {
            //Arrange
            var mockedCarsRepository = new Mock<ICarsRepository>();

            //Act
            mockedCarsRepository.Setup(x => x.Add(It.IsAny<Car>()));

            //Assert
            mockedCarsRepository.Setup(x => x.All());
        }
    }
}
