using Register;

Console.WriteLine("📚 Book Registration");

Console.Write("Enter the title of the book: ");
string bookTitle = Console.ReadLine();

Console.Write("Enter the genre of the book: ");
string bookGenre = Console.ReadLine();

Console.Write("Enter the author's name: ");
string authorName = Console.ReadLine();

Console.Write("Enter the author's nationality: ");
string authorNationality = Console.ReadLine();

Book RegisterBook = new Book(bookTitle, bookGenre);
Author RegisterAuthor = new Author(authorName, authorNationality);

RegisterBook.ShowInfo();
RegisterAuthor.ShowInfo();
