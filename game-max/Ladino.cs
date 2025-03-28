public class Ladino : Personagem
{
    public Ladino(string nome) : base(nome)
    {
        Vida = 100;  // Vida menor que a do Guerreiro, mas ainda resistente
        Dano = 25;   // Dano maior, pois ladinos são ágeis e furtivos
    }

    public override void Atacar()
    {
        Console.WriteLine($"{Nome} (Ladino) ataca rapidamente com suas adagas, causando {Dano} de dano!");
    }
}