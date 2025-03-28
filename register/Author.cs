namespace Register
{
  public class Author
  {
    public string Name { get; set; }
    public string Nationality { get; set; }

    public Author (string name, string nationality)
    {
      Name = name;
      Nationality = nationality;
    }

    public void ShowInfo()
    {
      Console.WriteLine($"👤 Author: {Name} ({Nationality})");
    }
  }
}