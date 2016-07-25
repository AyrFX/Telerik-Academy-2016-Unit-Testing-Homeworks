namespace School.Tests.VSTT
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;
    using StudentsAndCourses;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.OverflowException))]
        public void ToCouresCanNotBeJoinedMoreThan30Students()
        {
            var course = new Course();
            for (int i = 0; i < 31; i++)
            {
                course.JoinStudent(new Student("A"));
            }
        }

        [TestMethod]
        public void StudentsListReturnRealJoinedStudentsNumber()
        {
            var course = new Course();
            for (int i = 0; i < 20; i++)
            {
                course.JoinStudent(new Student("A"));
            }
            Assert.AreEqual(course.Students.Count, 20);
        }

        [TestMethod]
        public void ReturnedStudentsListIsCorrect()
        {
            var course = new Course();
            for (int i = 0; i < 10; i++)
            {
                course.JoinStudent(new Student("A"));
            }

            var studentsList = course.Students;
            Assert.AreSame(course.Students, studentsList);
        }

        [TestMethod]
        public void StudentCanLeaveCourse()
        {
            var course = new Course();
            for (int i = 0; i < 10; i++)
            {
                course.JoinStudent(new Student("A"));
            }

            var studentToLeave = course.Students[4];
            course.LeaveStudent(studentToLeave);
            Assert.AreEqual(course.Students.IndexOf(studentToLeave), -1);
        }
    }
}
