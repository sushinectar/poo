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
