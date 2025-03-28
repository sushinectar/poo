public class Personagem
{
    public string Nome { get; set; }
    public int Vida { get; protected set; }
    public int Dano { get; protected set; }

    public Personagem(string nome)
    {
        Nome = nome;
    }

    public virtual void Atacar()
    {
        Console.WriteLine($"{Nome} ataca causando {Dano} de dano!");
    }
}