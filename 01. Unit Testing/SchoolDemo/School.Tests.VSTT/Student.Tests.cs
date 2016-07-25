namespace School.Tests.VSTT
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;
    using StudentsAndCourses;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void StudentNameShouldNotBeEmpty()
        {
            var student = new Student("");
        }

        [TestMethod]
        public void AssignedStudentNumberIncrementsCorrectly()
        {
            Student.InitializeNumber();
            var firstStudent = new Student("ABCD");
            var secondStudent = new Student("ABCD");
            Assert.AreEqual(firstStudent.Number, secondStudent.Number - 1);
        }

        [TestMethod]
        public void CreateStudentByValidData()
        {
            Student.InitializeNumber();
            var student = new Student("A");
            Assert.IsNotNull(student);
        }

        [TestMethod]
        public void TheNameOfTheStudentEqualsToGivenStudentName()
        {
            Student.InitializeNumber();
            var student = new Student("ABCD");
            Assert.AreEqual(student.Name, "ABCD");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void AddingMoreThan89999StudentThrowsException()
        {
            Student.InitializeNumber();
            Student student;
            for (int i = 0; i < 89999; i++)
            {
                student = new Student("ABCD");
            }
           student = new Student("ABCD");
        }
    }
}
