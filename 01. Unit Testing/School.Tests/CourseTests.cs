namespace School.Tests
{
	using System;
	using NUnit.Framework;
	using StudentsAndCourses;

	[TestFixture]
	public class CourseTests
	{
		[Test]
		public void ToCouresCanNotBeJoinedMoreThan30Students()
		{
			var course = new Course();
			for (int i = 0; i < 30; i++)
			{
				course.JoinStudent(new Student("A"));
			}
			Assert.That(() => { course.JoinStudent(new Student("A")); }, Throws.Exception.TypeOf<OverflowException>());
		}
		
		[Test]
		public void StudentsListReturnRealJoinedStudentsNumber()
		{
			var course = new Course();
			for (int i = 0; i < 20; i++)
			{
				course.JoinStudent(new Student("A"));
			}
			Assert.That(course.Students.Count, Is.EqualTo(20));
		}
		
		[Test]
		public void ReturnedStudentsListIsCorrect()
		{
			var course = new Course();
			for (int i = 0; i < 10; i++)
			{
				course.JoinStudent(new Student("A"));
			}
			
			var studentsList = course.Students;
			Assert.That(course.Students, Is.EqualTo(studentsList));
		}
		
		[Test]
		public void StudentCanLeaveCourse()
		{
			var course = new Course();
			for (int i = 0; i < 10; i++)
			{
				course.JoinStudent(new Student("A"));
			}
			
			var studentToLeave = course.Students[4];
			course.LeaveStudent(studentToLeave);
			Assert.That(course.Students.IndexOf(studentToLeave), Is.EqualTo(-1));
		}
	}
}
