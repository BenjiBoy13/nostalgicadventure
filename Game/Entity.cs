namespace NA.Game.Entity;

public abstract class Entity : Game
{
    public abstract string Name { get; set; }

    public abstract string Description { get; init; }

    protected Entity(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

public abstract class Being : Entity
{
    private float health;

    public virtual float Health { get => health; set { if (value < 0) health = 0; else health = value;  } }

    public abstract float Damage { get; set; }

    public abstract float Defense { get; set; }

    public abstract int Level { get; set; }

    protected Being(string name, string description, float health, float damage, float defense, int level) : base(name, description) 
    {
        Health = health;
        Damage = damage;
        Defense = defense;
        Level = level;
    }

    public abstract void Attack(Being entity);
}

public abstract class Item : Entity
{
    public Item(string name, string description) : base(name, description) { }
}