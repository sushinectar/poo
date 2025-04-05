// Classe base
public abstract class Documento
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public DateTime DataCriacao { get; set; }

    public Documento(string titulo, string autor)
    {
        Titulo = titulo;
        Autor = autor;
        DataCriacao = DateTime.Now;
    }

    public virtual void Imprimir()
    {
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Data de Criação: {DataCriacao}");
    }

    public virtual string ConteudoFormatado()
    {
        return $"Título: {Titulo}\nAutor: {Autor}";
    }
}