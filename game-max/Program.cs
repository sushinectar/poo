class Program
{
    static void Main()
    {
        Guerreiro guerreiro = new Guerreiro("Arthas");
        Console.WriteLine($"Nome: {guerreiro.Nome}, Vida: {guerreiro.Vida}, Dano: {guerreiro.Dano}");
        guerreiro.Atacar();
    }
}