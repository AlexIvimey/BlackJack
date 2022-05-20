using game.Models;
using System;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Deck deck1 = new Deck();
            Players p1 = new Players("Alain");
            
          
            Players dealer = new Players("Alex the Dealer");
            p1.Wallet = 100;
            

            //Game reruns if the user chooses to playe again
            bool playAgain = true;
            while (playAgain)
            {
                

                Console.WriteLine($"Welcome to Alex's Casino, {p1.Wallet}$ are currently in your Black Jack account. \nPress ENTER to start");
                Console.ReadLine();
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("Enter your starting bet and press ENTER");
                
                p1.StartingBet();
                Console.WriteLine("");

                deck1.CreateDeck();
                deck1.ShuffleDeck(500);

                deck1.DealCards(2, p1);
                deck1.DealCards(2, dealer);

                Console.SetCursorPosition(0, 6);
                p1.ShowHand();

                //These two methods calculate the black jack score of the user
                p1.CalculateScore();
                Console.SetCursorPosition(0, 7);
                p1.ShowScore();

                Console.WriteLine("");

                //If the user has less than 16 in their hand, give the option to hit
                while (p1.Score < 21)
                {
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("Type (hit) and press ENTER to add a card to your hand, if you would like to stay, type ENTER");                    


                    if (string.Compare(Console.ReadLine(), "hit", true)==0)
                    {
                        Console.WriteLine("");
                        deck1.DealCards(1, p1);
                        Console.SetCursorPosition(0, 6);
                        p1.ShowHand();
                        p1.CalculateScore();
                    }
                    else
                    {
                        p1.CalculateScore();
                        break;
                    }
                    
                    Console.SetCursorPosition(0, 7);
                    p1.ShowScore();
                    Console.WriteLine("");
                    
                }

                //Calculating dealers score from their first 2 cards
                Console.SetCursorPosition(0, 12);
                dealer.ShowHand();
                dealer.CalculateScore();
                Console.SetCursorPosition(0, 13);
                dealer.ShowScore();

                //Making the dealer hit automatically while their score in under 16
                while (dealer.Score < 16)
                {
                    deck1.DealCards(1, dealer);
                    Console.WriteLine($"{dealer.Name} hits");
                    Console.SetCursorPosition(0, 12);
                    dealer.ShowHand();
                    dealer.CalculateScore();
                    Console.SetCursorPosition(0, 16);
                    dealer.ShowScore();
                }

                Console.WriteLine("");
                //Calculating and displaying the game outcome
                if (p1.Score == dealer.Score)
                {
                    Console.WriteLine($"Tie! {p1.Name}'s money will now be returned");
                    p1.Wallet += p1.BetAmount;
                    p1.HasWon = false;
                }
                else if(dealer.Score > 21 && p1.Score > 21)
                {
                    Console.WriteLine($"Tie! {p1.Name}'s money will now be returned");
                    p1.Wallet += p1.BetAmount;
                    p1.HasWon = false;
                }
                if (p1.Score > dealer.Score || dealer.Score > 21)
                {
                    if (p1.Score <= 21)
                    {
                        Console.WriteLine($"{p1.Name} Wins!");
                        p1.HasWon = true;
                    }
                        
                }
                if (dealer.Score>p1.Score|| p1.Score > 21)
                {
                    if (dealer.Score <= 21)
                    {
                        
                        Console.WriteLine($"{dealer.Name} Wins! You Lose");
                        p1.HasWon = false;
                    }
                        
                }
                


                //adds or removes funds depending if the user has won
                p1.UpdateWallet();
                Console.WriteLine("");
                Console.WriteLine($"{p1.Name}'s new wallet balance is {p1.Wallet}");

                //If the player runs out of money they lose
                if (p1.Wallet == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Looks like someone ran out of money, YOU LOSE");
                    Console.WriteLine("Press ENTER to conclude your time at ALEX'S CASINO");
                    Console.ReadLine();
                    playAgain = false;
                }
                //This block of code asks the user if they want to play again or end the game 
                else
                {
                    Console.WriteLine("To continue press ENTER, if you are a broke loser and want to end the game, press ESC");
                    ConsoleKeyInfo kb = Console.ReadKey();
                    Console.WriteLine("");
                    if (kb.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("BYE BYE");
                        playAgain = false;
                    }
                }
                


                //clearing everything for the next game
                p1.BetAmount = 0;
                p1.Hand.Clear();
                dealer.Hand.Clear();
                Console.Clear();
            }


        }
    }
}
