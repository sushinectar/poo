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
