using System;

namespace CardGame
{
    class Program
    {
        private static void Main()
        {
            #region Test

            CardStock c = new CardStock();
            c.MixUpTheCard();
            Card d = c["-1"];
            if (d != null) Console.WriteLine(d.ToString());
            Card f =new Card(EColor.Red,1);

            #endregion

            #region Game


            Console.WriteLine("Hello and welcome in the Game\nThis a the deck of each player\n\n");
            Game myGame = new Game();
            Console.WriteLine(myGame.ToString());

            int choice = 0;
            while (choice != 3)
            {
                Console.WriteLine("[1] Do only one step \n[2] Do all the step \n[3] Exit");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        myGame.StepInGame();
                        break;

                    case 2:

                        while (myGame.EndOfGame() != true)
                        {
                            myGame.StepInGame();
                            //Console.WriteLine(myGame.CheckWinner());
                        }

                        Console.WriteLine("The winner is {0}", myGame.CheckWinner());
                        break;

                    case 3:
                        break;

                    default:
                        Console.WriteLine("Not a valide input");
                        break;
                }
                #endregion

            }
        }
    }
}