using System.Collections.Generic;

namespace CardGame
{
    class Player
    {
        public string Name { get; set; }
        private readonly Queue<Card> _deck = new Queue<Card>();

        /// <summary>
        /// Constructeur par default ne recois pas de nom
        /// Cree un deck au joueur
        /// Initialize le nom a "Default"
        /// </summary>
        public Player()
        {
            Name = "Default";
            _deck = new Queue<Card>();
        }

        public Player(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Ajoute une liste de carte (meme une seul) au deck du joueur
        /// </summary>
        /// <param name="toInsert"> Liste de carte a ajouter </param>
        public void AddCard(List<Card> toInsert)
        {
            foreach (Card c in toInsert)
            {
                _deck.Enqueue(c);
            }
        }

        /// <summary>
        /// Ajoute plusieur carte individuelle au paquet
        /// </summary>
        /// <param name="toInsert"> Un nombre pas definie de carte </param>
        public void AddCard(params Card[] toInsert)
        {
            foreach (Card c in toInsert)
            {
                _deck.Enqueue(c);
            }
        }

        /// <summary>
        /// Sort une carte du paquet
        /// </summary>
        /// <returns> La premiere carte du paquet</returns>
        public Card DequeueCard()
        {
            Card tmp = _deck.Dequeue();
            return tmp;
        }

        /// <summary>
        /// Verifie si le joueur a perdu
        /// </summary>
        public bool Lose()
        {
            return _deck.Count == 0;
        }

        /// <summary>
        /// Override de ToString 
        /// Imprime Le nom du joueur le nombre de carte et toute les cartes de son deck
        /// N'imprime pas dans la fonction
        /// </summary>
        /// <returns> Un string</returns>
        public override string ToString()
        {
            string tmp = "Player name : " + Name + " Number of cards : " + _deck.Count + "\n";

            foreach (Card c in _deck)
            {
                tmp += "\t\t";
                tmp += c.ToString() + "\n";
            }
            //Console.WriteLine(tmp);
            return tmp;

        }

        /// <summary>
        /// Nombre de carte dans le deck d'un joueur
        /// </summary>
        public int GetCount()
        {
            return _deck.Count;
        }
    }
}
