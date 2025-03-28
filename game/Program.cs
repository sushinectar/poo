
Console.WriteLine("🏰 Bem-vindo ao Jogo de Personagens!");

// Criar os personagens
Warrior warrior = new Warrior("Arthur");
Mage mage = new Mage("Merlin");

// Mostrar status inicial
warrior.MostrarStatus();
mage.MostrarStatus();

Console.WriteLine("\n⚔️ A batalha começa!\n");

// Loop de batalha
while (warrior.HP > 0 && mage.HP > 0)
{
warrior.Attack(mage);
if (mage.HP <= 0) break;

mage.Attack(warrior);
if (warrior.HP <= 0) break;

// Mostrar status após os ataques
warrior.MostrarStatus();
mage.MostrarStatus();

Console.WriteLine("\n--- Próximo turno ---\n");
}

// Verificar quem venceu
if (warrior.HP > 0)
Console.WriteLine($"🏆 {warrior.Name} venceu a batalha!");
else
Console.WriteLine($"🏆 {mage.Name} venceu a batalha!");

