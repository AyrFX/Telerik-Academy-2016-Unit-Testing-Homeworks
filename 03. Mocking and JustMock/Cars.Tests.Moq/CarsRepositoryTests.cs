using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Cars.Contracts;
using Cars.Data;
using Cars.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cars.Tests.Moq
{
    [TestClass]
    public class CarsRepositoryTests
    {
        [TestMethod]
        public void CarRepositoryConstructorWithParameterShouldCreateObjectsProperly()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();

            //Act
            var repository = new CarsRepository(mockedDatabase.Object);

            //Assert
            Mock.Verify(mockedDatabase);
        }

        [TestMethod]
        public void CarRepositoryConstructorWithoutParameterShouldCreateObjectsProperly()
        {
            //Arrange
            var mockedCarsRepository = new Mock<ICarsRepository>();
            mockedCarsRepository.Setup(x => x.Add(It.IsAny<Car>()));

            //Act & Assert
            mockedCarsRepository.Setup(x => x.All());
        }

        [TestMethod]
        public void CarsRepositoryTotalShouldReturnExpectedNumberOfCards()
        {
            //Arrange
            var database = new Database();
            database.Cars = new List<Car>();

            var repository = new CarsRepository(database);

            //Act
            for (int i = 0; i < 10; i++)
            {
                repository.Add(new Car());
            }

            //Assert
            Assert.AreEqual(repository.TotalCars, 10);
        }

        [TestMethod]
        public void CarsRepositoryShouldAddToDatabaseWhenAddingCars()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();
            var car = new Car();
            mockedDatabase.Setup(x => x.Cars.Add(car));

            var repository = new CarsRepository(mockedDatabase.Object);

            //Act
            repository.Add(car);
            repository.Add(car);
            repository.Add(car);

            //Assert
            mockedDatabase.Verify(x => x.Cars.Add(car), Times.Exactly(3));
        }

        [TestMethod]
        public void CarsRepositoryShouldRemoveFromDatabaseWhenRemovingCars()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Cars.Remove(It.IsAny<Car>()));

            var repository = new CarsRepository(mockedDatabase.Object);

            //Act

            repository.Remove(new Car());

            //Assert
            mockedDatabase.Verify(x => x.Cars.Remove(It.IsAny<Car>()), Times.Exactly(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CarsRepositoryShouldThrowArgumentExceptionByPassingNullCarToRemove()
        {
            //Arrange
            var repository = new CarsRepository();

            //Act & Assert
            repository.Remove(null);
        }

        [TestMethod]
        public void CarsRepositoryGetByIdShouldReturnExistingCar()
        {
            //Arrange
            var database = new Database();
            database.Cars = new List<Car>();
            var car = new Car();
            car.Id = 5;

            var repository = new CarsRepository(database);
            repository.Add(car);

            //Act

            var result = repository.GetById(5);

            //Assert
            Assert.AreSame(car, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CarsRepositoryGetByIdShouldReturnThrowArgumentExceptionByPassingNullCar()
        {
            //Arrange
            var database = new Database();
            database.Cars = new List<Car>();
            var car = new Car();
            car.Id = 5;

            var repository = new CarsRepository(database);
            repository.Add(car);

            //Act & Assert
            var result = repository.GetById(10);
        }

        [TestMethod]
        public void CarsRepositoryAllShouldCallDatabase()
        {
            //Arrange
            var database = new Database();
            database.Cars = new List<Car>();
            var car = new Car();
            car.Id = 5;

            var repository = new CarsRepository(database);
            repository.Add(car);

            //Act
            var result = repository.All();

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Car>));
        }
    }
}
