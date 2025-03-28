namespace Register
{
  public class Book
  {
    public string Title { get; set; }
    public string Genre { get; set; }

    public Book (string title, string genre)
    {
      Title = title;
      Genre = genre;
    }

    public void ShowInfo()
    {
      Console.WriteLine("\n📖 Book Information:");
      Console.WriteLine($"Title: {Title}");
      Console.WriteLine($"Genre: {Genre}");
    }
  }
}
