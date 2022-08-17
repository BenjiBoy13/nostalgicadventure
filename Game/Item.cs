namespace NA.Game.Entity;

public sealed class Weapon : Item
{
    public override string Name { get; init; }

    public override string Description { get; init; }

    public float Damage { get; set; }

    public float Durability { get; set; }

    public Weapon(string name, string description, float damage, float durability) : base(name, description)
    {
        Damage = damage;
        Durability = durability;
    }
}
