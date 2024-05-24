using Microsoft.VisualBasic;
using System;

namespace SystemZarządzaniaBiblioteką
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> initialBooks = new List<Book>
            {
                new Book("Harry Potter", "J.K. Rowling", 1997),
                new Book("Wiedźmin", "Andrzej Sapkowski", 1993),
                new Book("Lśnienie", "Stephen King", 1977),
                new Book("Duma i uprzedzenie", "Jane Austen", 1813)
            };

            List<User> initialUsers = new List<User>
            {
                new User("Jan", "Kowalski1", 12345678),
                new User("Jan", "Nowak", 12345678),
                new User("Jan", "Sa", 12345678),
                new User("Jan", "Elo", 12345678),
                new User("Jan", "ss", 12345678)
            };
            Library library = new Library(initialBooks, initialUsers);
            Console.WriteLine("System zarządzania Biblioteką");
                            while (true)
                            {
                                Console.WriteLine("Co chcesz zrobić?");
                                Console.WriteLine("1. Wyświetl dostępne książki");
                                Console.WriteLine("2. Dodaj nowe książki");
                                Console.WriteLine("3. Usuń książki");
                                Console.WriteLine("4. Szukaj książki");
                                Console.WriteLine("5. Wyświetl listę czytelników");
                                Console.WriteLine("6. Dodaj użtkownika");
                                Console.WriteLine("7. Szukaj użtkownika");
                                Console.WriteLine("8. Wypożycz czytelnikowi książke");
                                Console.WriteLine("9. Wyświetl czytelników z wypożyczonymi książkami");
                                Console.WriteLine("10. Zwrot książki");
                                int choice = int.Parse(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        Console.Clear();
                                        library.DisplayBooks();
                                        Console.WriteLine("Naciśnij Enter, aby powrócić do menu...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.Write("Podaj tytuł książki: ");
                                        string newTitle = Console.ReadLine();
                                        Console.Write("Podaj autora książki: ");
                                        string newAuthor = Console.ReadLine();
                                        Console.Write("Podaj rok wydania książki: ");
                                        int newYear;
                                        while (!int.TryParse(Console.ReadLine(), out newYear) || newYear <= 0)
                                        {
                                            Console.WriteLine("Nieprawidłowy rok. Podaj poprawny rok.");
                                        }

                                        library.AddBook(new Book(newTitle, newAuthor, newYear));
                                        Console.WriteLine("Książka została dodana");
                                        Console.WriteLine("Naciśnij Enter, aby powrócić do menu...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        library.DisplayBooks();
                                        Console.WriteLine("Podaj tytuł książki która chcesz usunąć z biblioteki");
                                        string remove = Console.ReadLine();
                                        library.RemoveBooks(remove);
                                        Console.WriteLine("Naciśnij Enter, aby powrócić do menu...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        Console.WriteLine("Wpisz tytuł lub autora książki do wyszukania:");
                                        string query = Console.ReadLine();
                                        library.Search(query);
                                        Console.WriteLine("Naciśnij Enter, aby powrócić do menu...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case 5:
                                        Console.Clear();
                                        library.DisplayUsers();
                                        Console.WriteLine("Naciśnij Enter, aby powrócić do menu...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case 6:
                                        Console.Clear();
                                        Console.Write("Podaj imię: ");
                                        string newName = Console.ReadLine();
                                        Console.Write("Podaj nazwisko: ");
                                        string newLastName = Console.ReadLine();
                                        Console.Write("Podaj PESEL: ");
                                        int newPesel;
                                        while (!int.TryParse(Console.ReadLine(), out newPesel) || newPesel <= 0)
                                        {
                                            Console.WriteLine("Nieprawidłowy PESEL. Podaj poprawny.");
                                        }

                                        library.AddUser(new User(newName, newLastName, newPesel));
                                        Console.WriteLine("Czytelnik został dodany");
                                        Console.WriteLine("Naciśnij Enter, aby powrócić do menu...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case 7:
                                        Console.Clear();
                                        Console.WriteLine("Wpisz nazwisko czytelnika do wyszukania:");
                                        string query1 = Console.ReadLine();
                                        library.SearchUser(query1);
                                        Console.WriteLine("Naciśnij Enter, aby powrócić do menu...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case 8:
                                        Console.Clear();
                                        Console.WriteLine("Wprowadź nazwisko studenta, który chce wypożyczyć książkę:");
                                        string lastName = Console.ReadLine();
                                        Console.WriteLine("Dostępne książki:");
                                        library.DisplayBooks();
                                        Console.WriteLine("Wprowadź tytuł książki do wypożyczenia:");
                                        string bookTitle = Console.ReadLine();
                                        library.BorrowBooks(lastName, bookTitle);
                                        Console.WriteLine("Naciśnij Enter, aby powrócić do menu...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case 9:
                                        Console.Clear();
                                        Console.WriteLine($"Lista czytelników z wypożyczonymi książkami");
                                        library.DisplayUsersWithBorrowed();
                                        Console.WriteLine("Naciśnij Enter, aby powrócić do menu...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case 10:
                                        Console.Clear();
                                        Console.WriteLine("Wprowadź nazwisko czytelnika, który zwraca książke");
                                        string lastName1 = Console.ReadLine();
                                        Console.WriteLine("Wprowadź tytuł książki która jest zwracana");
                                        string bookTitle1 = Console.ReadLine();
                                        library.ReturnBook(lastName1, bookTitle1);
                                        Console.WriteLine("Naciśnij Enter, aby powrócić do menu...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                }
                            }

        }
    }
}
