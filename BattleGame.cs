using System;
using System.Threading;

class BattleGame
{
    private static Hero hero1, hero2;
    public void Start()
    {
        Random r;

        Console.WriteLine("Enter first Hero name: ");
        hero1 = new Hero(Console.ReadLine());

        Console.WriteLine("Enter second Hero name: ");
        hero2 = new Hero(Console.ReadLine());

        // Set game loop.
        while (hero1.isAlive && hero2.isAlive)
        {
            r = new Random();
            int turn = r.Next(1, 10);

            // This is to avoid draw game. If each hero take turn to hit each other, 
            // there can be a draw because both can die at the last attack.
            switch (turn)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    hero1.Attack(hero2);
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    hero2.Attack(hero1);
                    break;
                default:
                    break;
            }

            Thread.Sleep(500);
        }
    }
}