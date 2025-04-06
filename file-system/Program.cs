// Interface IArmazenamento
public interface IArmazenamento
{
    bool Salvar(string nome, byte[] dados);
    byte[] Carregar(string nome);
    bool Excluir(string nome);
    List<string> ListarArquivos();
}

// Interface IRastreavel
public interface IRastreavel
{
    void RegistrarOperacao(string operacao, string arquivo);
    List<string> ObterHistoricoOperacoes();
}