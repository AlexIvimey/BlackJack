using System;
using System.Collections.Generic;
using System.Text;

namespace game.Models
{
    public class Card
    {
        public string Suit { get; set; }
        
        public int Number { get; set; }

        public int Value { get; set; }

        //This method shows an individual card as a string
        public string ShowCard()
        {
            if(Number == 1)
            {
                return $"A{Suit}";
            }
            if(Number == 11)
            {
                return $"J{Suit}";
            }
            if(Number == 12)
            {
                return $"Q{Suit}";
            }
            if(Number == 13)
            {
                return $"K{Suit}";
            }

            return $"{Number}{Suit}";
        }
    }
}
