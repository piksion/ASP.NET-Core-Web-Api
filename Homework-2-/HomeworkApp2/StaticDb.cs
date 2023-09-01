using HomeworkApp2.Model;

namespace HomeworkApp2
{
	public static class StaticDb
	{
		public static List<Book> Books = new List<Book>()
		{
			new Book()
			{
				Id = 1,	
				Author = "Joseph Murphy",
				Title = "The Power of your subconscious mind",
			},
			new Book()
			{
				Id = 2,
				Author = "J.K. Rowling",
				Title = "Harry Potter and the Prisoner of Azkaban"
			},
			new Book()
			{
				Id = 3,
				Author = "J.R.R Tolkien",
				Title = "The Lord of the Rings: The Two Towers"
			}
		};

	}
}
