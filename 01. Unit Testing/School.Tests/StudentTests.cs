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
		public void TheNameOfTheStudentEqualsToRealStudentName()
		{
			voidMethodDelegate currentDelegate = CheckStudentNameGetter;
			Assert.That(currentDelegate("ABCD"), Is.EqualTo(true));
		}
		
		public delegate bool voidMethodDelegate(string name);
		public static bool CheckStudentNameGetter(string name)
		{
			var student = new Student(name, 20000);
			if (name != student.Name)
			{
				return false;
			}
			return true;
		}
	}
}
