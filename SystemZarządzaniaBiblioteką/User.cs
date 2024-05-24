namespace SystemZarządzaniaBiblioteką;

public class User
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Pesel { get; set; }
    public List<Book> BorrowedBooks { get; set; }
    public User(string name, string lastName, int pesel)
    {
        Name = name;
        LastName = lastName;
        Pesel = pesel;
        BorrowedBooks = new List<Book>();

    }

    public override string ToString()
    {
        return $"{Name}, {LastName}, {Pesel}";
    }

    public void BorrowBook(Book book)
    {
        BorrowedBooks.Add(book);
    }

    public void ReturnBook(Book book)
    {
        BorrowedBooks.Remove(book);
    }
}