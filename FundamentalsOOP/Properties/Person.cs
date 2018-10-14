using System;

namespace Properties
{
	public class Person
	{
		public string Name { get; set; }
		public string UserName { get; set; }
		public DateTime BirthDate { get; private set; }

		public Person(DateTime birthdate)
		{
			this.BirthDate = birthdate;
		}

		public int Age
		{
			get
			{
				var timeSpan = DateTime.Today - BirthDate;
				var years = timeSpan.Days / 365;

				return years;
			}
		}
	}
}
