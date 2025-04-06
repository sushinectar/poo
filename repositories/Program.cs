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