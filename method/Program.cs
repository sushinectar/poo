// Classe base
public abstract class Notificacao
{
    public string Destinatario { get; set; }
    public string Mensagem { get; set; }
    public DateTime DataEnvio { get; private set; }

    public Notificacao(string destinatario, string mensagem)
    {
        Destinatario = destinatario;
        Mensagem = mensagem;
        DataEnvio = DateTime.Now;
    }

    public virtual void Enviar()
    {
        Console.WriteLine("Enviando notificação...");
    }

    public virtual string FormatarMensagem()
    {
        return $"Para: {Destinatario}\nMensagem: {Mensagem}";
    }
}