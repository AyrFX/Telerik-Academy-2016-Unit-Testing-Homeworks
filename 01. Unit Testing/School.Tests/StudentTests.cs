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
			Assert.That(() => { var student = new Student("", 3); }, Throws.ArgumentException);
		}
		
		[Test]
		public void StudentNumberShouldBeGreatherThan9999()
		{
			Assert.That(() => { var student = new Student("A", 3); }, Throws.ArgumentException);
		}
		
		[Test]
		public void StudentNumberShouldBeLessThan100000()
		{
			Assert.That(() => { var student = new Student("A", 100000); }, Throws.ArgumentException);
		}
		
		[Test]
		public void CreateStudentByValidData()
		{
			Assert.That(() => { var student = new Student("A", 55555); }, Throws.Nothing);
		}
		
		[Test]
		public void TheNameOfTheStudentEqualsToGivenStudentName()
		{
			var student = new Student("ABCD", 20000);
			Assert.That(student.Name, Is.EqualTo("ABCD"));
		}
		
		[Test]
		public void TheNumberOfTheStudentEqualsToGivenStudentNumber()
		{
			var student = new Student("ABCD", 20000);
			Assert.That(student.Number, Is.EqualTo(20000));
		}
	}
}
