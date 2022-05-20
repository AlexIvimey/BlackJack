using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackMvc.Models
{
    public class Card
    {
        public string Suit { get; set; }
        public int Number { get; set; }
        public  int Value { get; set; }

        
        public string ApiSuit
        {
            
            get
            {

                if (Suit == "♠")
                {
                    return "S";

                }
                else if (Suit == "♣")
                {
                    return "C";

                }
                else if (Suit == "♦")
                {
                    return "D";

                }
                else if (Suit == "♥")
                {
                    return "H";

                }
                return Suit; 

            }
            
        }
        
        public string ApiNum
        {
            
          get 
          {
                if (Number == 10)
                {
                    return "0";

                }
                else if (Number == 1)
                {
                    return "A";

                }
                else if (Number == 11)
                {
                    return "J";

                }
                else if (Number == 12)
                {
                    return "Q";

                }
                else if (Number == 13)
                {
                    return "K";

                }
                return Number.ToString();
            }
            
        }

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
