
public class Warrior : Character
{
  public Warrior(string name) : base(name, 100, 24) {}

  public override void Attack(Character enemy)
  {
    Console.WriteLine($"🗡️ {Name} dá um golpe de espada em {enemy.Name} causando {DMG} de dano!");
    enemy.HP -= DMG;
  }
}

public class Mage : Character
{
  public Mage(string name) : base(name, 86, 32) {}
  
  public override void Attack(Character enemy)
  {
    Console.WriteLine($"🗡️ {Name} dá um golpe de espada em {enemy.Name} causando {DMG} de dano!");
    enemy.HP -= DMG;
  }
}
