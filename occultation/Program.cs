// Classe base
public class RegistroBase
{
    public virtual void Salvar()
    {
        Console.WriteLine("🔵 RegistroBase.Salvar() chamado");
    }
}

// Classe com sobrescrita (override)
public class RegistroSobrescrito : RegistroBase
{
    public override void Salvar()
    {
        Console.WriteLine("🟢 RegistroSobrescrito.Salvar() chamado (override)");
    }
}

// Classe com ocultação (new)
public class RegistroOculto : RegistroBase
{
    public new void Salvar()
    {
        Console.WriteLine("🟡 RegistroOculto.Salvar() chamado (new)");
    }
}

// Programa principal
public class Program
{
    public static void Main()
    {
        // Referência direta
        var sobrescritoDireto = new RegistroSobrescrito();
        var ocultoDireto = new RegistroOculto();

        // Referência como base
        RegistroBase sobrescritoComoBase = sobrescritoDireto;
        RegistroBase ocultoComoBase = ocultoDireto;

        Console.WriteLine("➡️ Chamando via referência direta:");
        sobrescritoDireto.Salvar(); // Chama sobrescrito
        ocultoDireto.Salvar();      // Chama oculto

        Console.WriteLine("\n➡️ Chamando via referência base:");
        sobrescritoComoBase.Salvar(); // Chama sobrescrito (override)
        ocultoComoBase.Salvar();      // Chama base (porque é new)
    }
}