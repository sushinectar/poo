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
// Notificação por Email
public class NotificacaoEmail : Notificacao
{
    public NotificacaoEmail(string destinatario, string mensagem)
        : base(destinatario, mensagem) {}

    public override void Enviar()
    {
        Console.WriteLine($"📧 Enviando e-mail para {Destinatario}...");
        Console.WriteLine(FormatarMensagem());
    }

    public override string FormatarMensagem()
    {
        return $"Assunto: Notificação\nCorpo: {Mensagem}";
    }
}
// Notificação por SMS
public class NotificacaoSMS : Notificacao
{
    public NotificacaoSMS(string destinatario, string mensagem)
        : base(destinatario, mensagem) {}

    public override void Enviar()
    {
        Console.WriteLine($"📱 Enviando SMS para {Destinatario}...");
        Console.WriteLine(FormatarMensagem());
    }

    public override string FormatarMensagem()
    {
        return $"[SMS] {Mensagem}";
    }
}
