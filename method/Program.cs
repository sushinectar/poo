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
// Notificação Push
public class NotificacaoPush : Notificacao
{
    public NotificacaoPush(string destinatario, string mensagem)
        : base(destinatario, mensagem) {}

    public override void Enviar()
    {
        Console.WriteLine($"🔔 Enviando Push para {Destinatario}...");
        Console.WriteLine(FormatarMensagem());
    }

    public override string FormatarMensagem()
    {
        return $"[Push Notification]\n{Mensagem}";
    }
}

// Classe de estatísticas
public static class EstatisticasEnvio
{
    private static int totalEnviadas = 0;

    public static void RegistrarEnvio()
    {
        totalEnviadas++;
    }

    public static void MostrarTotal()
    {
        Console.WriteLine($"\n📊 Total de notificações enviadas: {totalEnviadas}");
    }
}

// Programa principal
public class Program
{
    public static void Main()
    {
        var notificacoes = new List<Notificacao>
        {
            new NotificacaoEmail("luciano@email.com", "Seu pedido foi enviado."),
            new NotificacaoSMS("+5511999999999", "Seu código de verificação é 123456."),
            new NotificacaoPush("user123", "Você tem uma nova mensagem.")
        };

        foreach (var notificacao in notificacoes)
        {
            notificacao.Enviar();
            EstatisticasEnvio.RegistrarEnvio();
            Console.WriteLine();
        }

        EstatisticasEnvio.MostrarTotal();
    }
}
