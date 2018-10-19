using System;
using System.Collections;
using System.Collections.Generic;

namespace CardGame
{
    class CardStock : IEnumerable
    {
        private readonly List<Card> _cards = new List<Card>();

        public CardStock()
        {
            for (int j = 4; j < 30; j++)
            {
                EColor color;
                if (j % 2 == 0)
                    color = EColor.Black;
                else
                    color = EColor.Red;

                _cards.Add(new Card(color, j / 2));
            }
        }

        /// <summary>
        /// Function that mix up the cardStock ( swap between two cards randomly )
        /// </summary>
        public void MixUpTheCard()
        {
            Random r = new Random();
            for (int i = 0; i < 100; i++) // In order for the card to be really mixed the for is going to run 100 times
            {

                // Random the index
                int first = r.Next(0, 26);
                int second = r.Next(0, 26);

                // Swap
                Card tmp = _cards[first];
                _cards[first] = _cards[second];
                _cards[second] = tmp;
            }
        }

        /// <summary>
        /// Override of function ToString
        /// Concatenate all the Info of each card ( With the ToString function of the card )
        /// </summary>
        /// <returns>A String with all the info </returns>
        public override string ToString()
        {
            string tmp = "\n";
            for (int i = 0; i < 26; i++)
            {
                tmp = tmp + _cards[i].ToString() + "\n";
            }
            //Console.WriteLine(tmp);
            return tmp;
        }

        /// <summary>
        /// Distribute the card equitably between the player
        /// No matter how many player
        /// </summary>
        /// <param name="players"> Receive a list of players </param>
        public void Distribute(List<Player> players)
        {
            int count = 0;
            foreach (Player p in players)
            {
                for (int i = 0; i < 26 / players.Count; i++)
                {
                    p.AddCard(_cards[count]);
                    count++;
                }
            }
        }

        /// <summary>
        /// Sort the card using the the Icomparer implementation  
        /// </summary>
        public void SortTheCard()
        {
            _cards.Sort();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        /// <summary>
        /// Surcharge de l'indexer 
        /// Card2 = Cards(stock)["Nom de la carte"]
        /// retourne la premiere instance trouve
        /// Utilise CardStock.SearchCard
        /// </summary>
        /// <param name="myStr"> Nom  de la carte </param>
        /// <returns> Une copie de la carte </returns>
        public Card this[string myStr] => (SearchCard(myStr));

        /// <summary>
        /// Recherche une carte dans le paquet en fonction de son nom
        /// utilise Card.GetCardName() 
        /// </summary>
        /// <param name="name"> Nom de la carte </param>
        /// <returns> Une copie de la carte </returns>
        public Card SearchCard(string name)
        {
            foreach (Card t in _cards)
            {
                if (t.GetCardName() == name)
                {
                    return t;
                }
            }
            return null;
        }
         
        /// <summary>
        /// Ajoute une carte au paquet de carte
        /// </summary>
        /// <param name="c"> Recois un objet de type card </param>
        public void AddCard(Card c)
        {
            _cards.Add(c);
        }

        /// <summary>
        /// Ajoute une carte au paquet
        /// </summary>
        /// <param name="c"> La couleur de la carte </param>
        /// <param name="number"> Le numero de la carte </param>
        public void AddCard(EColor c, int number)
        {
            _cards.Add(new Card(c, number));
        }

        public void RemoveCard(Card c)
        {
            bool success = _cards.Remove(c);
            if (success != true)
            {
                Console.WriteLine("Error! Can't remove this card");
            }
        }

        public void RemoveCard(EColor c, int number)
        {
            Card ca = new Card(c, number);

            bool success = _cards.Remove(ca);
            if (success != true)
            {
                Console.WriteLine("Error! Can't remove this card");
            }

        }
    }
}
