namespace SystemZarządzaniaBiblioteką;

class Library
{
    private List<Book> books;
    private List<Book> borrowedBooks;
    private List<User> users;

    public Library(List<Book> initialBooks, List<User> initialUsers)
    {
        books = initialBooks;
        users = initialUsers;
        borrowedBooks = new List<Book>();
    }
    
    
    public void DisplayBooks()
    {
        Console.WriteLine("Dostępne książki w bibliotece:");
        foreach (Book book in books)
        {
            Console.WriteLine(book);
        }

        Console.WriteLine();
    }

    public void DisplayUsers()
    {
        Console.WriteLine("Czytelnicy:");
        foreach (User user in users)
        {
            Console.WriteLine(user);
        }

        Console.WriteLine();
    }
    public void AddBook(Book newBook)
    {
        books.Add(newBook);
    }

    public void AddUser(User newUser)
    {
        users.Add(newUser);
    }
    
    public void RemoveBooks(string bookTitle)
    {
        Book removedBook = books.Find(book => book.Title.Contains(bookTitle, StringComparison.Ordinal));
                                             
        if (removedBook != null)
        {
            books.Remove(removedBook);
            Console.WriteLine($"Ksiażka o tytule {bookTitle} została usunięta.");
        }
        else
        {
            Console.WriteLine("Nie ma książki o podanym tytule");
        }
    }

    

    public void DisplayBorrowed()
    {
        Console.WriteLine("Wypożyczone książki");
        foreach (var borrowedBooks in borrowedBooks)
        {
            Console.WriteLine(borrowedBooks);
        }
    }
    
    public void Search(string query)
    {
        List<Book> foundBooks = books.Where(book => book != null &&
                                             (book.Title.Contains(query, StringComparison.Ordinal) ||
                                              book.Author.Contains(query, StringComparison.Ordinal))).ToList();
        if (foundBooks.Any())
        {
            Console.WriteLine($"Znalezione książki dla {query}");
            foreach (var book in foundBooks)
            {   
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("Nie udało się wyszukać ksiązki");
        }
    }
    public void SearchUser(string query1)
    {
        List<User> foundusers = users.Where(user => user != null &&
                                             (user.LastName.Contains(query1, StringComparison.Ordinal) ||
                                              user.LastName.Contains(query1, StringComparison.Ordinal))).ToList();
        if (foundusers.Any())
        {
            Console.WriteLine($"Znalezieni czytelnicy dla {query1}");
            foreach (var book in foundusers)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("Nie udało się wyszukać czytelnika");
            return;
        }
    }

    public void BorrowBooks(string lastName, string bookTitle)
    {
        User user = users.Find(user => user.LastName.Contains(lastName, StringComparison.Ordinal));
        if (user != null)
        {
            Book book = books.Find(book => book.Title.Contains(bookTitle, StringComparison.Ordinal));
            if (book != null)
            {
                user.BorrowBook(book);
                borrowedBooks.Add(book);
                books.Remove(book);
                Console.WriteLine($"Użytkownik {user.Name} {user.LastName} wypożyczył książkę '{bookTitle}'.");
            }
            else
            {
                Console.WriteLine("Szukana książka nie została znaleziona");
                return;
            }
        }
        else
        {
            Console.WriteLine("Szukany czytelnik nie został znaleziony");
            return;
        }
    }

    public void DisplayUsersWithBorrowed()
    {
        foreach (var user in users)
        {
            Console.WriteLine($"Student {user.Name} {user.LastName} (PESEL: {user.Pesel}):");
            if (user.BorrowedBooks.Count == 0)
            {
                Console.WriteLine("Brak wypożyczonych książek.");
            }
            else
            {
                foreach (var book in user.BorrowedBooks)
                {
                    Console.WriteLine($"- {book}");
                }
            }
        }
    }

    public void ReturnBook(string lastName, string bookTitle)
    {
        User user = users.Find(user => user.LastName.Contains(lastName, StringComparison.Ordinal));
        if (user != null)
        {
            Book book = borrowedBooks.Find(book => book.Title.Contains(bookTitle, StringComparison.Ordinal));
            if (book != null)
            {
                user.ReturnBook(book);
                borrowedBooks.Remove(book);
                books.Add(book);
                Console.WriteLine($"Użytkownik {user.Name} {user.LastName} zwrócił książkę '{bookTitle}'.");
            }
            else
            {
                Console.WriteLine("Szukana książka nie została znaleziona");
                return;
            }
        }
        else
        {
            Console.WriteLine("Szukany czytelnik nie został znaleziony");
            return;
        }
    }
}