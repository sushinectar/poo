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
// Implementação em nuvem (simulada)
public class ArmazenamentoNuvem : IArmazenamento, IRastreavel
{
    private Dictionary<string, byte[]> nuvem = new();
    private List<string> historico = new();

    public bool Salvar(string nome, byte[] dados)
    {
        nuvem[nome] = dados;
        RegistrarOperacao("Salvar", nome);
        return true;
    }

    public byte[] Carregar(string nome)
    {
        RegistrarOperacao("Carregar", nome);
        return nuvem.ContainsKey(nome) ? nuvem[nome] : null;
    }

    public bool Excluir(string nome)
    {
        if (nuvem.Remove(nome))
        {
            RegistrarOperacao("Excluir", nome);
            return true;
        }
        return false;
    }

    public List<string> ListarArquivos()
    {
        RegistrarOperacao("ListarArquivos", "-");
        return new List<string>(nuvem.Keys);
    }

    public void RegistrarOperacao(string operacao, string arquivo)
    {
        historico.Add($"{DateTime.Now}: {operacao} - {arquivo}");
    }

    public List<string> ObterHistoricoOperacoes()
    {
        return historico;
    }
}