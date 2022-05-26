using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJackMvc.Models
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand = new();
        public int Score { get; set; }
        public int Wallet { get; set; }
        public int BetAmount { get; set; }
        public bool HasWon { get; set; }
        

        public Player(string name)
        {
            this.Name = name;
        }

        //This method will display the cards in the hand of the player to the console
        public void ShowHand()
        {

            foreach (Card card in Hand)
            {
                Console.Write(card.ShowCard() + " ");
                
            }
            Console.WriteLine("");
            
        }

        public void ShowScore()
        {
            if (Score > 21)
            {
                Console.WriteLine("BUST!");
            }
            if (Score == 21)
            {
                Console.WriteLine("Black Jack!");
            }

            Console.WriteLine($"{Name} Score is {Score}");
        }

        //This method will update the Score property of the player based on the cards in their hand
        public void CalculateScore()
        {
            Score = 0;

            foreach (Card card in Hand.OrderByDescending(c=>c.Number).ThenBy(c=>c.Suit))
            {
                if (card.Number == 1)
                {
                    if (Score <= 10 && card == Hand.OrderByDescending(c => c.Number).ThenBy(c=>c.Suit).Last())
                        card.Value = 11;
                    else
                        card.Value = 1;
                }
                    


                Score += card.Value;
            }
            
           
        }
        
        

        //This method will add 1-- dollars to the users wallet and allow them to input a bet as long as it is 100 or less
        //public void StartingBet()
        //{

        //    bool success = false;

        //    while (success == false)
        //    {

        //        int num = 0;
        //        string input = Console.ReadLine();
        //        success = Int32.TryParse(input, out num);

        //        if (success == true)
        //        {
        //            BetAmount = Int32.Parse(input);

        //            if (BetAmount > Wallet)
        //            {
        //                Console.SetCursorPosition(0, 3);
        //                Console.WriteLine($"ERROR: You tried to bet {BetAmount} when your wallet has {Wallet}");
        //                success = false;

        //            }
        //            if (BetAmount <= Wallet && success == true)
        //                break;
        //            else
        //                success = false;
        //        }
        //        else
        //        {
        //            Console.SetCursorPosition(0, 3);
        //            Console.WriteLine("Enter a proper bet and press Enter                                                   ");
        //        }
                    
        //    }
        //    Wallet -= BetAmount;

               
            
        //}

        //This method will update the amount of money in the players wallet depending on if they won or not
        //public void UpdateWallet()
        //{
        //    if (HasWon == true)
        //    {
        //        Wallet += BetAmount * 2;
        //    }
            
        //}


        

    }
}
