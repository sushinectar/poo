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
// Implementação local
public class ArmazenamentoLocal : IArmazenamento
{
    private string diretorio = "arquivos";

    public ArmazenamentoLocal()
    {
        Directory.CreateDirectory(diretorio);
    }

    public bool Salvar(string nome, byte[] dados)
    {
        string caminho = Path.Combine(diretorio, nome);
        File.WriteAllBytes(caminho, dados);
        return true;
    }

    public byte[] Carregar(string nome)
    {
        string caminho = Path.Combine(diretorio, nome);
        return File.Exists(caminho) ? File.ReadAllBytes(caminho) : null;
    }

    public bool Excluir(string nome)
    {
        string caminho = Path.Combine(diretorio, nome);
        if (File.Exists(caminho))
        {
            File.Delete(caminho);
            return true;
        }
        return false;
    }

    public List<string> ListarArquivos()
    {
        var arquivos = Directory.GetFiles(diretorio);
        return new List<string>(Array.ConvertAll(arquivos, Path.GetFileName));
    }
}