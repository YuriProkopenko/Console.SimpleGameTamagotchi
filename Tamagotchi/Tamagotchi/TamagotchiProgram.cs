using System;
using System.Text;
using System.Threading;

namespace Tamagotchi
{
    class TamagotchiProgram
    {
        static string ChangePositiveConditionEvent(string _petCondition)
        {
            Random rnd = new Random();
            int randomCond = rnd.Next(0,10);
            if (_petCondition == "(o_o)" && randomCond <= 5)
                return "(T_T)";
            if (_petCondition == "(o_o)" && randomCond >= 5)
                return "(-O-)";
            if (_petCondition == "(T_T)")
                return "(-^-)";
            if (_petCondition == "(-O-)")
                return "(-^-)";
            if (_petCondition == "(-^-)")
                return "(x_x)";
            else
                return "(o_o)";
        }
        static string ChangeNegativeConditionEvent(string _petCondition)
        {
                return "(^U^)";
        }
        static void Main(string[] args)
        {
            TamagotchiPet Game = new TamagotchiPet();
            Game.ChangeNegativeCondition += ChangeNegativeConditionEvent;
            Game.ChangePositiveCondition += ChangePositiveConditionEvent;
            int playerChoice = 0;
            int petDeadChance = 0;
            while (true)
            {
                StringBuilder sb = new StringBuilder(Game.GetTheImage());
                sb.Insert(0, "     ");
                for (int i = 1; i < 14; i++)
                {
                    Console.Clear();
                    Console.Write("\n\n\n\n{0}\n\n\n\n\n\n\n",sb);
                    sb.Insert(0, ' ');
                    Game.Menu();
                    Thread.Sleep(300);
                }
                if (Game.Condition == "(o_o)")
                {
                    Game.Condition = Game.NegativeEventPool(Game.Condition);
                }
                if (Game.Condition == "(^U^)")
                {
                    Game.Condition = Game.NegativeEventPool(Game.Condition);
                }
                sb = new StringBuilder(Game.GetTheImage());
                sb.Insert(0, "                ");
                for (int i = 1; i < 13; i++)
                {
                    Console.Clear();
                    Console.Write("\n\n\n\n{0}\n\n\n\n\n\n\n", sb);
                    sb.Remove(0, 1);
                    Game.Menu();
                    Thread.Sleep(300);
                }
                while (true)
                {
                    try
                    {
                        playerChoice = Convert.ToInt32(Console.ReadLine());
                        if (playerChoice == 1 || playerChoice == 2 || playerChoice == 3 || playerChoice == 4)
                            break;
                    }
                    catch 
                    {
                    }
                }
                if (Game.Condition == "(T_T)" && playerChoice != 3)
                {
                    Game.Condition = Game.NegativeEventPool(Game.Condition);
                    continue;
                }
                if (Game.Condition == "(-O-)" && playerChoice != 1)
                {
                    Game.Condition = Game.NegativeEventPool(Game.Condition);
                    continue;
                }
                if (Game.Condition == "(T_T)" && playerChoice == 3)
                {
                    Game.Condition = Game.PositiveEventPool(Game.Condition);
                    continue;
                }
                if (Game.Condition == "(-O-)" && playerChoice == 1)
                {
                    Game.Condition = Game.PositiveEventPool(Game.Condition);
                    continue;
                }
                if (Game.Condition == "(-^-)" && playerChoice != 2)
                {
                    petDeadChance++;
                    if (petDeadChance == 3)
                    {
                        Game.Condition = Game.NegativeEventPool(Game.Condition);
                        sb = new StringBuilder(Game.GetTheImage());
                        sb.Insert(0, "     ");
                        Console.Clear();
                        Console.Write("\n\n\n\n{0}\n\n\n\n\n\n\n", sb);
                        break;
                    }
                    continue;
                }
                if (Game.Condition == "(-^-)" && playerChoice == 2)
                {
                    petDeadChance = 0;
                    Game.Condition = Game.PositiveEventPool(Game.Condition);
                    continue;
                }
            }
        }
    }
}