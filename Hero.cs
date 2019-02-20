using System;

class Hero
{
    private string Name;
    private int Health;
    private int damage;
    public bool isAlive { get; private set; }
    private const int superDamage = 4;

    public Hero(string Name)
    {
        this.Name = Name;
        this.Health = 30;
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
            Console.WriteLine($"{this.Name} attack {enemy.Name} with {this.damage} damage.");

            if (this.damage == superDamage)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"{enemy.Name} get hit by Special Attack!");
                Console.ResetColor();
            }

            enemy.Health = enemy.Health - this.damage;

            if (enemy.Health <= 0) // to avoid Health become negative
            {
                enemy.Health = 0;
                enemy.isAlive = false;
            }

            // When there is a damage from the attack, only check end game
            CheckEndGame(enemy);
        }
        else
        {
            Console.WriteLine($"{this.Name} attack {enemy.Name} but {enemy.Name} avoided.");
        }



        Console.WriteLine("----------------------------");
    }

    private void CheckEndGame(Hero enemy)
    {
        if (this.isAlive == true && enemy.isAlive == false)
        {
            Console.WriteLine($"{this.Name} won. Health remaining: {this.Health}");
            Console.WriteLine("Game Over!");
            Console.ReadKey();
            Environment.Exit(0);
        }
        else if (enemy.isAlive == true && this.isAlive == false)
        {
            Console.WriteLine($"{enemy.Name} won. Health remaining: {enemy.Health}");
            Console.WriteLine("Game Over!");
            Console.ReadKey();
            Environment.Exit(0);

        }
        else
        {
            Console.WriteLine($"{this.Name} remaining health: {this.Health}");
            Console.WriteLine($"{enemy.Name} remaining  health: {enemy.Health}");
        }

    }

}