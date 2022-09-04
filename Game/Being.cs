namespace NA.Game.Entity;

public sealed class Player : Being
{
    public override string Name { get; set; }

    public override string Description { get; init; }

    public override float Damage { get; set; }

    public override float Defense { get; set; }

    public override int Level { get; set; }

    public float DamageMultiplier { get; set; }

    public List<Item> Inventory { get; set; }

    public Player(string name, string description, float health, float damage, float defense, int level, float damageMultiplier) :
        base(name, description, health, damage, defense, level)
    {
        DamageMultiplier = damageMultiplier;
        Inventory = new List<Item>();
    }

    public override void Attack(Being being)
    {
        foreach (Item item in Inventory)
            if (item is Weapon)
            {
                Weapon weapon = (Weapon) item;
                weapon.Durability = weapon.Durability - 5;
                being.Health = being.Health - weapon.Damage;
                return;
            }
             
        being.Health = being.Health - (Damage * DamageMultiplier);
    }

    public void PickUp()
    {
        Inventory.Add(new Weapon(name: "Long Sword", description: "A long sword, good for killing trolls", damage: 10, durability: 100));
    }
}

public sealed class Monster : Being
{
    public override string Name { get; set; }

    public override string Description { get; init; }

    public override float Damage { get; set; }

    public override float Defense { get; set; }

    public override int Level { get; set; }

    public Monster(string name, string description, float health, float damage, float defense, int level) :
        base(name, description, health, damage, defense, level)
    { }

    public override void Attack(Being being) => being.Health = being.Health - Damage;

}