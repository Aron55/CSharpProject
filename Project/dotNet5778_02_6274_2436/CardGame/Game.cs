#define ShortGame
using System;
using System.Collections.Generic;


namespace CardGame
{
    class Game
    {
        private readonly List<Player> _player = new List<Player>();
        private readonly CardStock _stock = new CardStock();
        private int _moveCount;

        public Game()
        {
            _player.Add(new Player("Aron"));
            _player.Add(new Player("David"));

            _stock.MixUpTheCard();
            _stock.Distribute(_player);
            _moveCount = 0;

        }

        /// <summary>
        /// Check if there is a winner in the game
        /// </summary>
        /// <returns> Return the name of the winner </returns>
        public string CheckWinner()
        {
            if (_player[0].Lose())
                return _player[1].Name;
            if (_player[1].Lose())
                return _player[0].Name;
            return "No winner";
        }

        public bool EndOfGame()
        {
            if (_player[0].Lose())
                return true;
            if (_player[1].Lose())
                return true;
            else return false;
        }

        public override string ToString()
        {
            string tmp = _player[0].ToString() + "\n\n\n";
            tmp += _player[1].ToString();
            //Console.WriteLine(tmp);
            return tmp;

        }

        public void StepInGame()
        {
            _moveCount++;
            List<Card> tmp = new List<Card>();
            while (!_player[0].Lose() && !_player[1].Lose())
            {
                Card firstCard = _player[0].DequeueCard();
                Card secondCard = _player[1].DequeueCard();

                tmp.Add(firstCard);
                tmp.Add(secondCard);

#if (ShortGame)
                if (_moveCount > 30 && (firstCard.GetCardNumber() == secondCard.GetCardNumber()))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (_player[0].Lose() == false && _player[1].Lose() == false)
                        {
                            firstCard = _player[0].DequeueCard();
                            secondCard = _player[1].DequeueCard();

                            tmp.Add(firstCard);
                            tmp.Add(secondCard);

                        }

                    }
                }
                                
#endif
                if (firstCard.GetCardNumber() > secondCard.GetCardNumber())
                {
                    _player[0].AddCard(tmp);
                    break;
                }
                if (firstCard.GetCardNumber() < secondCard.GetCardNumber())
                {
                    _player[1].AddCard(tmp);
                    break;
                }
                //if (firstCard.Id % 14 == secondCard.Id % 14)
                //{
                //    int x=0;
                //}
            }

            Console.WriteLine(ToString());
        }
    }
}
