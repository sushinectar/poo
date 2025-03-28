public class Document 
{
  public string Title { get; set; }
  public string Author { get; set; }
  public DateTime Date { get; set; }

  public Document (string title, string author, DateTime date) 
  {
    Title = title;
    Author = author;
    Date = date;
  }
}