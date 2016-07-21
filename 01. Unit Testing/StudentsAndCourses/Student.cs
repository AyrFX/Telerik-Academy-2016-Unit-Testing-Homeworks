namespace StudentsAndCourses
{
	using System;
	
	public class Student
	{
		//Fields
		private string name;
		private int number;
		
		//Properties
		public string Name {
			get {
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
			set
			{
				if (10000 <= value && value < 99999)
				{
					this.number = value;
				}
				else
				{
					throw new ArgumentException("The number should be between 10000 and 99999");
				}
			}
		}
		
		//Constructors
		public Student()
		{
						
		}
	}
}
