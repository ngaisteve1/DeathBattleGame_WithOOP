using System;

class Hero
{
    public string Name { get; }
    public int Health { get; set; }

    public bool isAlive { get; private set; }

    public Hero(string Name)
    {
        this.Name = Name;
        Health = 10;
        isAlive = true;
    }

    public void Attack(Hero enemy)
    {
        Random r = new Random();
        int damage = r.Next(4);

        switch (damage)
        {
            case 0:
                Console.WriteLine($"{this.Name} attacks {enemy.Name} but {enemy.Name} avoided.");
                break;
            case 3:
                Utility.ConsoleWriteLine($"{this.Name} launched critical attacks {enemy.Name} with {damage} damage.", ConsoleColor.Red);
                break;
            default:
                Console.WriteLine($"{this.Name} attacks {enemy.Name} with {damage} damage.");
                break;
        }
        enemy.Health -= damage;
        Console.WriteLine($"{this.Name} remaining life: {this.Health}");
        Console.WriteLine($"{enemy.Name} remaining life: {enemy.Health}");

        if (enemy.Health <= 0) // to avoid Health become negative
        {
            enemy.Health = 0;
            enemy.isAlive = false;
        }

        Console.WriteLine("----------------------------");
    }
}