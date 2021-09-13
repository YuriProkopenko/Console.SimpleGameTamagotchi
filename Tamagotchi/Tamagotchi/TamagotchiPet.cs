using System;

namespace Tamagotchi
{
    class TamagotchiPet
    {
        public string Condition { get; set; }
        protected string[] Conditions { get; } = { "(o_o)", "(^U^)", "(T_T)", "(-O-)", "(-^-)", "(x_x)" };
        public TamagotchiPet() 
        {
            Condition = Conditions[0];
            ConsoleInterface();
        }     
        protected void ConsoleInterface()
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            Console.BackgroundColor = colors[0];
            Console.ForegroundColor = colors[5];
            Console.WindowWidth = 27;
            Console.WindowHeight = 18;
            Console.Title = "TAMAGOTCHI";
        }
        public string GetTheImage()
        {
            return Condition;
        }
        public void Menu()
        {
            Console.WriteLine("\n1.Feed\n2.Cure\n3.Play with it\n4.Ignore" );
        }
        public string NegativeEventPool(string _petCondition)
        {
            return ChangePositiveCondition(_petCondition);
        }
        public string PositiveEventPool(string _petCondition)
        {
            return ChangeNegativeCondition(_petCondition);
        }

        public delegate string del(string _petCondition);
        public event del ChangePositiveCondition;
        public event del ChangeNegativeCondition;
    }
}