namespace SystemZarządzaniaBiblioteką;
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }
    public static IBookBuilder CreateBuilder()
    {
        return new BookBuilder();
    }

    public override string ToString()
    {
        return $"{Title}, {Author}, {Year}";
    }
    
}
public interface IBookBuilder
{
    IBookBuilder SetTitle(string title);
    IBookBuilder SetAuthor(string author);
    IBookBuilder SetYear(int year);
    Book Build();
}


public class BookBuilder : IBookBuilder
{
    private string _title;
    private string _author;
    private int _year;

    public IBookBuilder SetTitle(string title)
    {
        _title = title;
        return this;
    }

    public IBookBuilder SetAuthor(string author)
    {
        _author = author;
        return this;
    }

    public IBookBuilder SetYear(int year)
    {
        _year = year;
        return this;
    }

    public Book Build()
    {
        return new Book(_title, _author, _year);
    }
}
