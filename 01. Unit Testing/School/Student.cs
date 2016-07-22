namespace StudentsAndCourses
{
	using System;
	
	public class Student
	{
		//Fields
		private string name;
		private int number;
		private static int currentNumber = 10000;
		
		//Properties
		public string Name {
			get
			{
				return this.name;
			}
			set
			{
				if (value != string.Empty)
				{
					this.name = value;
				}
				else
				{
					throw new ArgumentException("The name can not be empty!");
				}
			}
		}
		
		public int Number
		{
			get
			{
				return this.number;
			}
		}
		
		//Constructors
		public Student(string name)
		{
			this.Name = name;
			if (10000 <= Student.currentNumber && Student.currentNumber < 99999)
				{
					this.number = currentNumber;
				}
				else
				{
					throw new ArgumentException("The number should be between 10000 and 99999");
				}
			Student.currentNumber++;
		}
		
		//Methods
		public static void InitializeNumber()
		{
			Student.currentNumber = 10000;
		}
	}
}
