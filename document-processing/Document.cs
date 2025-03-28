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

  public virtual Print() 
  {
    Console.WriteLine($"Title of document: {title}, Name of the author: {author}, Date: {date}");
  }

  public virtual string FormatedDocument();
}