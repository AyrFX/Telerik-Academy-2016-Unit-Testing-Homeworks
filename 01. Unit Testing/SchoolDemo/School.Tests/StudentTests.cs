namespace School.Tests
{
	using System;
	using NUnit.Framework;
	using StudentsAndCourses;
	using School;
	
	[TestFixture]
	public class StudentTests
	{
		[Test]
		public void StudentNameShouldNotBeEmpty()
		{
			Assert.That(() => { var student = new Student(""); }, Throws.ArgumentException);
		}
		
		[Test]
		public void AssignedStudentNumberIncrementsCorrectly()
		{
			Student.InitializeNumber();
			var firstStudent = new Student("ABCD");
			var secondStudent = new Student("ABCD");
			Assert.That(firstStudent.Number, Is.EqualTo(secondStudent.Number - 1));
		}
		
		[Test]
		public void CreateStudentByValidData()
		{
			Student.InitializeNumber();
			Assert.That(() => { var student = new Student("A"); }, Throws.Nothing);
		}
		
		[Test]
		public void TheNameOfTheStudentEqualsToGivenStudentName()
		{
			Student.InitializeNumber();
			var student = new Student("ABCD");
			Assert.That(student.Name, Is.EqualTo("ABCD"));
		}
		
		[Test]
		public void AddingMoreThan89999StudentThrowsException()
		{
			Student.InitializeNumber();
			Student student;
			for (int i = 0; i < 89999; i++) {
				student = new Student("ABCD"); 
			}
			Assert.That(() => { student = new Student("ABCD"); }, Throws.ArgumentException);
		}
	}
}
