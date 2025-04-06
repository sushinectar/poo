// Interface com métodos CRUD
public interface IRepositorio<T>
{
    void Create(T entidade);
    T Read(int id);
    void Update(int id, T entidade);
    void Delete(int id);
    List<T> ListarTodos();
}
// Classe abstrata com implementação parcial
public abstract class RepositorioBase<T> : IRepositorio<T>
{
    protected List<T> dados = new List<T>();

    public virtual void Create(T entidade)
    {
        dados.Add(entidade);
        Console.WriteLine("🔧 Entidade adicionada.");
    }

    public virtual List<T> ListarTodos()
    {
        return dados;
    }

    public abstract void Validar(T entidade);
    public abstract T Read(int id);
    public abstract void Update(int id, T entidade);
    public abstract void Delete(int id);
}
// Classes modelo
public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
// Repositório de Cliente
public class RepositorioCliente : RepositorioBase<Cliente>
{
    public override void Validar(Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nome))
            Console.WriteLine("❗ Cliente inválido: nome vazio.");
    }

    public override Cliente Read(int id) => dados.FirstOrDefault(c => c.Id == id);

    public override void Update(int id, Cliente cliente)
    {
        var idx = dados.FindIndex(c => c.Id == id);
        if (idx != -1) dados[idx] = cliente;
    }

    public override void Delete(int id)
    {
        var cliente = Read(id);
        if (cliente != null) dados.Remove(cliente);
    }
}
// Repositório de Produto
public class RepositorioProduto : RepositorioBase<Produto>
{
    public override void Validar(Produto produto)
    {
        if (string.IsNullOrWhiteSpace(produto.Nome))
            Console.WriteLine("❗ Produto inválido: nome vazio.");
    }

    public override Produto Read(int id) => dados.FirstOrDefault(p => p.Id == id);

    public override void Update(int id, Produto produto)
    {
        var idx = dados.FindIndex(p => p.Id == id);
        if (idx != -1) dados[idx] = produto;
    }

    public override void Delete(int id)
    {
        var produto = Read(id);
        if (produto != null) dados.Remove(produto);
    }
}
// Classe que só implementa a interface (sem herdar classe abstrata)
public class RepositorioSimples<T> : IRepositorio<T>
{
    private List<T> dados = new List<T>();

    public void Create(T entidade) => dados.Add(entidade);
    public T Read(int id) => dados.ElementAtOrDefault(id);
    public void Update(int id, T entidade) => dados[id] = entidade;
    public void Delete(int id) => dados.RemoveAt(id);
    public List<T> ListarTodos() => dados;
}

// Programa principal
public class Program
{
    public static void Main()
    {
        Console.WriteLine("📁 Repositório de Cliente (usando classe abstrata + interface):");
        var repoClientes = new RepositorioCliente();
        repoClientes.Create(new Cliente { Id = 1, Nome = "Sushi" });
        repoClientes.Create(new Cliente { Id = 2, Nome = "" }); // inválido
        repoClientes.Validar(new Cliente { Id = 2, Nome = "" });

        Console.WriteLine("\n📦 Repositório Simples (só com interface):");
        var repoSimples = new RepositorioSimples<string>();
        repoSimples.Create("Arquivo A");
        repoSimples.Create("Arquivo B");

        foreach (var item in repoSimples.ListarTodos())
        {
            Console.WriteLine($"- {item}");
        }

        Console.WriteLine("\n✅ Diferença:");
        Console.WriteLine("- Classes que herdam da base têm lógica comum compartilhada e validação obrigatória.");
        Console.WriteLine("- Classes que só usam interface são mais livres e diretas, mas sem regras pré-definidas.");
    }
}
