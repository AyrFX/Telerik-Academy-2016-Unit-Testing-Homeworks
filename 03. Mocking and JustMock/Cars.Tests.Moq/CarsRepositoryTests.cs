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
            mockedDatabase.Setup(x => x.Cars).Returns(new List<Car>());

            //Act
            var repository = new CarsRepository(mockedDatabase.Object);

            //Assert
            mockedDatabase.Verify();
        }

        [TestMethod]
        public void CarsRepositoryTotalShouldReturnExpectedNumberOfCards()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Cars).Returns(new List<Car>());

            var repository = new CarsRepository(mockedDatabase.Object);
            for (int i = 0; i < 10; i++)
            {
                repository.Add(new Car());
            }
            
            //Act & Assert
            Assert.AreEqual(repository.TotalCars, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CarsRepositoryShouldThrowArgumentExceptionByPassingNullCarToAdd()
        {
            //Arrange
            var repository = new CarsRepository();

            //Act & Assert
            repository.Add(null);
        }

        [TestMethod]
        public void CarsRepositoryShouldAddToDatabaseEachTimeWhenAddingCars()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Cars).Returns(new List<Car>());
            mockedDatabase.Setup(x => x.Cars.Add(It.IsAny<Car>())).Verifiable();
            
            var repository = new CarsRepository(mockedDatabase.Object);

            //Act
            repository.Add(new Car());
            repository.Add(new Car());
            repository.Add(new Car());

            //Assert
            mockedDatabase.Verify(x => x.Cars.Add(It.IsAny<Car>()), Times.Exactly(3));
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
        public void CarsRepositoryShouldRemoveFromDatabaseWhenRemovingCars()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Cars).Returns(new List<Car>());

            var repository = new CarsRepository(mockedDatabase.Object);

            //Act
            var car = new Car();
            repository.Add(car);
            repository.Remove(car);

            //Assert
            Assert.AreEqual(mockedDatabase.Object.Cars.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CarsRepositoryGetByIdShouldReturnThrowArgumentExceptionByPassingNullCar()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Cars).Returns(new List<Car>());

            var repository = new CarsRepository(mockedDatabase.Object);

            //Act & Assert
            var result = repository.GetById(10);
        }

        [TestMethod]
        public void CarsRepositoryGetByIdShouldReturnExistingCar()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Cars).Returns(new List<Car>());

            var car = new Car();
            car.Id = 5;

            var repository = new CarsRepository(mockedDatabase.Object);
            repository.Add(car);

            //Act
            var result = repository.GetById(5);

            //Assert
            Assert.AreSame(car, result);
        }

        [TestMethod]
        public void CarsRepositoryAllShouldCallDatabase()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Cars).Returns(new List<Car>());

            var repository = new CarsRepository(mockedDatabase.Object);

            for (int i = 0; i < 10; i++)
            {
                repository.Add(new Car());
            }

            //Act
            var result = repository.All();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ICollection<Car>));
            //mockedDatabase.Verify();
        }

        [TestMethod]
        public void CarsRepositorySortedByMakeShouldReturnSortedList()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Cars).Returns(new List<Car>());

            var repository = new CarsRepository(mockedDatabase.Object);

            repository.Add(new Car()
            {
                Id = 1,
                Make = "Citroen",
                Model = "C4",
                Year = 2012
            });
            repository.Add(new Car()
            {
                Id = 2,
                Make = "Audi",
                Model = "S6",
                Year = 2015
            });
            repository.Add(new Car()
            {
                Id = 3,
                Make = "BMW",
                Model = "X1",
                Year = 2014
            });
            repository.Add(new Car()
            {
                Id = 4,
                Make = "Fiat",
                Model = "Panda",
                Year = 2016
            });

            //Act
            var result = (List<Car>)repository.SortedByMake();
            bool areSorted = true;

            //Assert
            for (int i = 1; i < result.Count; i++)
            {
                if (result[i - 1].Make.CompareTo(result[i].Make) < 0)
                {
                    continue;
                }
                else
                {
                    areSorted = false;
                    break;
                }
            }

            Assert.IsTrue(areSorted);
        }

        [TestMethod]
        public void CarsRepositorySortedByYearShouldReturnSortedList()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Cars).Returns(new List<Car>());

            var repository = new CarsRepository(mockedDatabase.Object);

            repository.Add(new Car()
            {
                Id = 1,
                Make = "Citroen",
                Model = "C4",
                Year = 2012
            });
            repository.Add(new Car()
            {
                Id = 2,
                Make = "Audi",
                Model = "S6",
                Year = 2015
            });
            repository.Add(new Car()
            {
                Id = 3,
                Make = "BMW",
                Model = "X1",
                Year = 2014
            });
            repository.Add(new Car()
            {
                Id = 4,
                Make = "Fiat",
                Model = "Panda",
                Year = 2016
            });

            //Act
            var result = (List<Car>)repository.SortedByYear();
            bool areSorted = true;

            //Assert
            for (int i = 1; i < result.Count; i++)
            {
                if (result[i - 1].Year > result[i].Year)
                {
                    continue;
                }
                else
                {
                    areSorted = false;
                    break;
                }
            }

            Assert.IsTrue(areSorted);
        }

        [TestMethod]
        public void CarsRepositorySearchShouldReturnListWithPassingItems()
        {
            //Arrange
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(x => x.Cars).Returns(new List<Car>());

            var repository = new CarsRepository(mockedDatabase.Object);

            repository.Add(new Car()
            {
                Id = 1,
                Make = "Citroen",
                Model = "C4",
                Year = 2012
            });
            repository.Add(new Car()
            {
                Id = 2,
                Make = "Audi",
                Model = "S6",
                Year = 2015
            });
            repository.Add(new Car()
            {
                Id = 3,
                Make = "BMW",
                Model = "X1",
                Year = 2014
            });
            repository.Add(new Car()
            {
                Id = 4,
                Make = "Fiat",
                Model = "Panda",
                Year = 2016
            });

            //Act
            var result = (List<Car>)repository.Search("X1");
            bool allPassing = true;

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Make.IndexOf("X1") > -1 || result[i].Model.IndexOf("X1") > -1)
                {
                    continue;
                }
                else
                {
                    allPassing = false;
                    break;
                }
            }

            Assert.IsTrue(allPassing);
        }
    }
}
