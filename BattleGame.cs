using System;
using System.Threading;

class BattleGame
{
    public void Execute()
    {
        Random r;

        Console.Write("Enter first Hero name: ");
        Hero hero1 = new Hero(Console.ReadLine());

        Console.Write("Enter second Hero name: ");
        Hero hero2 = new Hero(Console.ReadLine());

        // Set game loop.
        while (hero1.isAlive && hero2.isAlive)
        {
            r = new Random();
            int whoAttack = r.Next(2);

            // This is to avoid draw game. If each hero take turn to hit each other, 
            // there can be a draw because both can die at the last attack.
            switch (whoAttack)
            {
                case 0:
                    hero1.Attack(hero2);
                    break;
                case 1:
                    hero2.Attack(hero1);
                    break;
            }

            Thread.Sleep(500);
        }
        CheckEndGame(hero1, hero2);
    }

    private void CheckEndGame(Hero hero, Hero enemy)
    {
        if (hero.isAlive && enemy.isAlive == false)
        {
            Console.WriteLine($"{hero.Name} won. Life remaining: {hero.Health}");
        }
        else if (enemy.isAlive && hero.isAlive == false)
        {
            Console.WriteLine($"{enemy.Name} won. Life remaining: {enemy.Health}");


        }
        Console.WriteLine("Game Over!");
        Console.ReadKey();
        Environment.Exit(0);

    }
}