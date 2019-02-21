using System;

class Hero
{
    private readonly string name;
    private int health;
    private int damage;
    public bool isAlive { get; private set; }
    private const int superDamage = 4;
    

    public Hero(string Name)
    {
        this.name = Name;
        this.health = 30;
        isAlive = true;
    }

    public void Attack(Hero enemy)
    {

        Random r = new Random();
        this.damage = r.Next(0, 10);


        switch (this.damage)
        {
            case 1:
            case 2:
                this.damage = 0;
                break;
            case 9:
            case 10:
                this.damage = superDamage;
                break;
            default:
                this.damage = 1;
                break;
        }

        if (this.damage > 0)
        {
            Console.WriteLine($"{this.name} attack {enemy.name} with {this.damage} damage.");

            if (this.damage.Equals(superDamage))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"{enemy.name} get hit by Special Attack!");
                Console.ResetColor();
            }

            enemy.health = enemy.health - this.damage;

            if (enemy.health <= 0) // to avoid Health become negative
            {
                enemy.health = 0;
                enemy.isAlive = false;
            }

            // When there is a damage from the attack, only check end game
            CheckEndGame(enemy);
        }
        else
        {
            Console.WriteLine($"{this.name} attack {enemy.name} but {enemy.name} avoided.");
        }



        Console.WriteLine("----------------------------");
    }

    private void CheckEndGame(Hero enemy)
    {
        if (this.isAlive == true && enemy.isAlive == false)
        {
            Console.WriteLine($"{this.name} won. Health remaining: {this.health}");
            Console.WriteLine("Game Over!");
            Console.ReadKey();
            Environment.Exit(0);
        }
        else if (enemy.isAlive == true && this.isAlive == false)
        {
            Console.WriteLine($"{enemy.name} won. Health remaining: {enemy.health}");
            Console.WriteLine("Game Over!");
            Console.ReadKey();
            Environment.Exit(0);

        }
        else
        {
            Console.WriteLine($"{this.name} remaining health: {this.health}");
            Console.WriteLine($"{enemy.name} remaining  health: {enemy.health}");
        }

    }

}