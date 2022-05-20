using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackMvc.Models
{
    public class Deck
    {
        public int NumberOfCards { get; set; }
        public List<string> Suits { get; set; } = new List<string>();
        public List<Card> Cards { get; set; } = new List<Card>();

        //This method is not used in the Black Jack game, but it displays the amount of cards in the deck to the console
        public void ShowDeck()
        {
            foreach (var card in Cards)
            {
                Console.WriteLine(card.ShowCard());
            }
        }

        //This method adds the suits and assigns each card in the deck a suit
        public void CreateDeck()
        {
            Suits.Add("♥");
            Suits.Add("♦");
            Suits.Add("♠");
            Suits.Add("♣");

            NumberOfCards = 52;

            foreach (var suit in Suits)
            {
                for (int i = 1; i <= 13; i++)
                {
                    Card card1 = new Card();
                    card1.Suit = suit;
                    card1.Number = i;
                    card1.Value = i;
                    if (card1.Number > 9)
                        card1.Value = 10;
                    Cards.Add(card1);
                }
            }
        }

        //This method randomizes the order of the cards in the deck
        public void ShuffleDeck(int timesToShuffle)
        {
            var randomCard = new Random();


            for (int y = 0; y < timesToShuffle; y++)
            {


                for (int i = 0; i <= 51; i++)

                {
                    Card tempCard = new Card();
                    var cardNumber = randomCard.Next(0, 51);
                    tempCard = Cards[i];
                    Cards[i] = Cards[cardNumber];
                    Cards[cardNumber] = tempCard;
                }
            }

        }

        //This method takes in the amount of cards to give and to what player. Depending on what is put in as paramters in the program the method deals cards to a Player
        public void DealCards(int cardsPerHand, Player player, bool debug =false)
        {
            for (int i = 0; i < cardsPerHand; i++)
            {
                
                Card card1 = new Card();
                
                
                card1.Suit = Cards[0].Suit;
                card1.Number = Cards[0].Number;
                card1.Value = Cards[0].Value;
                
                
                player.Hand.Add(card1);
                Cards.Remove(Cards[0]);
            }
        }

    }
}
