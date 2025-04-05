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
// Documento HTML
public class DocumentoHTML : Documento
{
    public string Html { get; set; }
    public string Css { get; private set; }

    public DocumentoHTML(string titulo, string autor, string html)
        : base(titulo, autor)
    {
        Html = html;
        Css = "";
    }

    public override void Imprimir()
    {
        base.Imprimir();
        Console.WriteLine("HTML:");
        Console.WriteLine(Html);
        if (!string.IsNullOrWhiteSpace(Css))
        {
            Console.WriteLine("Estilo CSS:");
            Console.WriteLine(Css);
        }
    }

    public override string ConteudoFormatado()
    {
        return $"<html>\n{Html}\n<style>{Css}</style>\n</html>";
    }

    public void AdicionarEstilo(string css)
    {
        Css += css;
    }
}
// Documento PDF
public class DocumentoPDF : Documento
{
    public string Texto { get; set; }
    public string MarcaDagua { get; private set; }

    public DocumentoPDF(string titulo, string autor, string texto)
        : base(titulo, autor)
    {
        Texto = texto;
        MarcaDagua = "";
    }

    public override void Imprimir()
    {
        base.Imprimir();
        Console.WriteLine("PDF:");
        Console.WriteLine(Texto);
        if (!string.IsNullOrWhiteSpace(MarcaDagua))
        {
            Console.WriteLine($"Marca d'água: {MarcaDagua}");
        }
    }

    public override string ConteudoFormatado()
    {
        return $"[PDF]\nTexto: {Texto}\nMarca d'água: {MarcaDagua}";
    }

    public void AdicionarMarcaDagua(string texto)
    {
        MarcaDagua = texto;
    }
}

// Processador de Documentos
public class ProcessadorDocumentos
{
    public void ProcessarLote(List<Documento> documentos)
    {
        foreach (var doc in documentos)
        {
            Console.WriteLine("========== Documento ==========");
            doc.Imprimir();
            Console.WriteLine("========== Fim ==========\n");
        }
    }
}

// Programa principal
public class Program
{
    public static void Main()
    {
        var docTexto = new DocumentoTexto("Texto Exemplo", "Luciano", "Este é um exemplo de texto.");
        var docHtml = new DocumentoHTML("HTML Exemplo", "Maria", "<h1>Título</h1><p>Parágrafo.</p>");
        var docPdf = new DocumentoPDF("PDF Exemplo", "João", "Conteúdo de um documento PDF.");

        docHtml.AdicionarEstilo("body { font-family: Arial; }");
        docPdf.AdicionarMarcaDagua("CONFIDENCIAL");

        var documentos = new List<Documento> { docTexto, docHtml, docPdf };

        var processador = new ProcessadorDocumentos();
        processador.ProcessarLote(documentos);

        // Extra: demonstração dos métodos específicos
        Console.WriteLine($"Palavras no DocumentoTexto: {docTexto.ContarPalavras()}");
    }
}