public class Character
{
  public string Name { get; set; }
  public int HP { get; set; }
  public int DMG { get; set; }

  public Character(string name, int hp, int dmg)
  {
    Name = name;
    HP = hp;
    DMG = dmg;
  }

  public virtual void Attack(Character enemy)
  {
    Console.WriteLine($"{Name} ataca {enemy.Name} causando {DMG} de dano!");
    enemy.HP -= DMG;
  }

  public void MostrarStatus()
  {
    Console.WriteLine($"🧍 {Name} - HP: {HP}");
  }
}
