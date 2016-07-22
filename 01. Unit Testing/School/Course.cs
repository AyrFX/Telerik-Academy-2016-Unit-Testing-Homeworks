namespace StudentsAndCourses
{
	using System;
	using System.Collections.Generic;
	
	public class Course
	{
		//Fields
		List<Student> students;
		
		//Properties
		public List<Student> Students {
			get
			{
				return this.students;
			}
		}
		
		//Constructors
		public Course()
		{
			this.students = new List<Student>();
		}
		
		//Methods
		public void JoinStudent(Student student)
		{
			if (this.students.Count < 30)
			{
				this.students.Add(student);
			}
			else
			{
				throw new OverflowException("The participants in the course are reached maximal number of 30!");
			}
		}
		
		public void LeaveStudent(Student student)
		{
			this.students.Remove(student);
		}
	}
}
