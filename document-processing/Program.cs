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

// Documento de Texto
public class DocumentoTexto : Documento
{
    public string Conteudo { get; set; }

    public DocumentoTexto(string titulo, string autor, string conteudo)
        : base(titulo, autor)
    {
        Conteudo = conteudo;
    }

    public override void Imprimir()
    {
        base.Imprimir();
        Console.WriteLine("Conteúdo do Texto:");
        Console.WriteLine(Conteudo);
    }

    public override string ConteudoFormatado()
    {
        return $"[Texto]\n{Conteudo}";
    }

    public int ContarPalavras()
    {
        return Conteudo.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }
}