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