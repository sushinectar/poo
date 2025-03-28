public class Guerreiro : Personagem
{
    public Guerreiro(string nome) : base(nome)
    {
        Vida = 150;  // Define a vida padrão do guerreiro
        Dano = 20;   // Define o dano padrão do guerreiro
    }

    public override void Atacar()
    {
        Console.WriteLine($"{Nome} (Guerreiro) ataca com sua espada e causa {Dano} de dano!");
    }
}