using System;

namespace CardGame
{
    enum EColor
    {
        Red, Black
    }
    class Card : IComparable
    {

        /// <summary>
        /// Constructeur de la classe Card
        /// Cree aussi un id unique a chaque carte
        /// </summary>
        /// <param name="color"> Couleur de la carte </param>
        /// <param name="number"> Numero de la carte </param>
        public Card(EColor color, int number)
        {
            Color = color;
            if (number < 2 || number > 14)
            {
                Console.WriteLine("Invalid value");
                Number = 2;
            }
            else
                Number = number;

            if (Color == EColor.Black)
            {
                Id = Number - 1;
            }
            else
            {
                Id = (Number - 1) + 13;
            }
        }

        private EColor Color { get; }

        private int Number { get; }

        public int GetCardNumber()
        {
            return Number;

        }

        private string CardName
        {
            get
            {
                switch (Number)
                {
                    case 11:
                        return "Jack";
                    case 12:
                        return "Queen";
                    case 13:
                        return "King";
                    case 14:
                        return "Ace";

                    default: // 2-10
                        return Number.ToString();
                }
            }
        }

        /// <summary>
        /// Retourne le nom de la carte en utilisant la property ( Obligatoire que la property soit private 
        /// pour l'exo ) 
        /// </summary>
        /// <returns> Nom de la carte </returns>
        public string GetCardName()
        {
            return CardName;
        }

        public int Id { get; } // Sert a trier les cartes les noir en premiere les rouge en deuxieme

        /// <summary>
        /// Override de la fonction ToString imprimes la couleur
        /// et le numero de la carte
        /// </summary>
        /// <returns> Retourne un string sans l'imprimer dans la fonction </returns>
        public override string ToString()
        {
            string tmp = "The card is a ";
            tmp = tmp + Color.ToString() + " " + CardName;
            return tmp;
        }

        /// <inheritdoc />
        /// <summary>
        /// 
        /// </summary>
        public int CompareTo(object card)
        {
            Card secondCard = card as Card;
            return Id.CompareTo(secondCard.Id);
        }

    }
}
