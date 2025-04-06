// Interface com métodos CRUD
public interface IRepositorio<T>
{
    void Create(T entidade);
    T Read(int id);
    void Update(int id, T entidade);
    void Delete(int id);
    List<T> ListarTodos();
}
