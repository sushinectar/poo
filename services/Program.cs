// Interface de serviço de email
public interface IServicoEmail
{
    void Enviar(string destinatario, string assunto, string corpo);
}

// Interface de serviço de SMS
public interface IServicoSMS
{
    void Enviar(string numero, string mensagem);
}
// Classe que implementa ambas interfaces com implementação explícita
public class ServicoNotificacao : IServicoEmail, IServicoSMS
{
    // Implementação explícita de IServicoEmail
    void IServicoEmail.Enviar(string destinatario, string assunto, string corpo)
    {
        Console.WriteLine($"📧 Enviando e-mail para {destinatario}\nAssunto: {assunto}\nCorpo: {corpo}");
    }

    // Implementação explícita de IServicoSMS
    void IServicoSMS.Enviar(string numero, string mensagem)
    {
        Console.WriteLine($"📱 Enviando SMS para {numero}\nMensagem: {mensagem}");
    }
}

// Programa principal
public class Program
{
    public static void Main()
    {
        var notificacao = new ServicoNotificacao();

        // A chamada direta abaixo não compila, pois os métodos são explícitos:
        // notificacao.Enviar(...); ❌

        // Para chamar, é necessário fazer cast para a interface correta:
        IServicoEmail servicoEmail = notificacao;
        servicoEmail.Enviar("luciano@sushi.com", "Atualização", "Seu código está pronto!");

        IServicoSMS servicoSMS = notificacao;
        servicoSMS.Enviar("+5511999999999", "Mensagem rápida de texto!");

        Console.WriteLine("\n🧠 Observação:");
        Console.WriteLine("Como os métodos são implementados de forma explícita, só podem ser acessados via interface.");
    }
}
