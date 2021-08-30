using System;

// Todo: Confirmacao de exclusion de book

namespace Books
{
    class Program
    {
        static BookRepository repository = new BookRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListBooks();
                        break;

                    case "2":
                        InsertBook();
                        break;

                    case "3":
                        UpdateBook();
                        break;

                    case "4":
                        DeleteBook();
                        break;

                    case "5":
                        ShowBook();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Please, enter a valid option...");
                        break;
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Thanks for using our services :)");
            Console.ReadLine();
        }

        private static void ListBooks()
        {
            ConsoleLine();
            Console.WriteLine("List books");
            ConsoleLine();

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("There's no registered books :c!");
                Console.ReadLine();
                return;
            }

            foreach (var book in list)
            {
                var deleted = book.GetDeleted();

                Console.WriteLine("#ID {0}: - {1} {2}", book.GetId(), book.GetTitle(), (deleted ? " *Deleted*" : ""));
            }
        }

        public static void InsertBook()
        {
            ConsoleLine();
            Console.WriteLine("Insert new book");
            ConsoleLine();

            Book newBook = SetNewBook(repository.NextId());

            repository.Insert(newBook);
        }

        public static void UpdateBook()
        {
            ConsoleLine();
            Console.WriteLine("Update book");
            ConsoleLine();

            Console.Write("Enter the book id: ");
            int bookIndex = int.Parse(Console.ReadLine());

            Book updatedBook = SetNewBook(bookIndex);
            
            repository.Update(bookIndex, updatedBook);
        }

        public static void DeleteBook()
        {
            Console.Write("Enter the book id: ");
            int bookIndex = int.Parse(Console.ReadLine());

            Console.Write("Confirm exclusion [Y] / [N]: ");
            string confirmDelete = Console.ReadLine().ToUpper();

            if (confirmDelete == "Y")
            {
                repository.Delete(bookIndex);
                Console.WriteLine("Successfully deleted book!");
            }
            else
                Console.WriteLine("Exclusion aborted!");
        }

        private static void ShowBook()
        {
            Console.Write("Enter the book id: ");
            int bookIndex = int.Parse(Console.ReadLine());

            var book = repository.ReturnById(bookIndex);

            Console.WriteLine(book);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            ConsoleLine();
            Console.WriteLine("Welcome to BookCase!!!");
            ConsoleLine();

            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - List all books");
            Console.WriteLine("2 - Insert new book");
            Console.WriteLine("3 - Update book");
            Console.WriteLine("4 - Delete book");
            Console.WriteLine("5 - Show book");

            ConsoleLine();
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Exit");
            ConsoleLine();

            Console.Write("Your option: ");
            string userOption = Console.ReadLine().ToUpper();

            return userOption;
        }

        private static Book SetNewBook(int bookId)
        {
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.Write("Enter the book genre between the options above: ");
            int userGenre = int.Parse(Console.ReadLine());


            Console.Write("Enter the book title here: ");
            string userTitle = Console.ReadLine();

            Console.Write("Enter the book author here: ");
            string userAuthor = Console.ReadLine();

            Console.Write("Enter the year of the book: ");
            int userYear = int.Parse(Console.ReadLine());
            
            Console.Write("Enter the book description here: ");
            string userDescription = Console.ReadLine();

            return new Book(id: bookId,
                            author: userAuthor,
                            title: userTitle,
                            genre: (Genre)userGenre,
                            year: userYear,
                            description: userDescription);
        }

        public static void ConsoleLine()
        {
            Console.WriteLine("************************");
        }
    }
}
