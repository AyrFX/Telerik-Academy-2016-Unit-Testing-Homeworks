namespace School.Tests
{
	using System;
	using NUnit.Framework;
	using StudentsAndCourses;

	[TestFixture]
	public class CourseTests
	{
		[Test]
		public void TestMethod()
		{
			var course = new Course();
			for (int i = 0; i < 30; i++)
			{
				course.JoinStudent(new Student("A", 10000+i));
			}
			
			//Assert.That(() => { course.JoinStudent(new Student("A", 10031)); }, Throws.ArgumentException);
			Assert.That(() => { course.JoinStudent(new Student("A", 10031)); }, Throws.Exception.TypeOf<OverflowException>());
		}
	}
}
