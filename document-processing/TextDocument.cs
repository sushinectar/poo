public class TextDocument : Document
{
  public string Content { get; set; }

  public TextDocument(string title, string author, DateTime date, string content) : base(title, author, date)
  {
    Content = content;
  }
}