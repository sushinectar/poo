// Interface IArmazenamento
public interface IArmazenamento
{
    bool Salvar(string nome, byte[] dados);
    byte[] Carregar(string nome);
    bool Excluir(string nome);
    List<string> ListarArquivos();
}