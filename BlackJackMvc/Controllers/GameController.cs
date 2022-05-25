using BlackJackMvc.Models;
using BlackJackMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlackJackMvc.Controllers
{
    public class GameController : Controller
    {
        private static GameViewModel gameViewModel;
        public IActionResult Start(string nameInput, int betInput)
        {


            gameViewModel = new GameViewModel
            {
                Player = new Player(nameInput)
                {

                    
                },

                Dealer = new Player("The Dealer"),
                Deck = new Deck()
            };
            gameViewModel.Player.BetAmount = betInput;
            gameViewModel.Player.Wallet -=gameViewModel.Player.BetAmount;

            gameViewModel.Deck.CreateDeck();
            gameViewModel.Deck.ShuffleDeck(500);
            DealNewGame();
            return View("Start", gameViewModel);

        }

        private static void DealNewGame()
        {
            if (gameViewModel.Deck.Cards.Count < 10)
            {
                gameViewModel.Deck.CreateDeck();
                gameViewModel.Deck.ShuffleDeck(500);
            }

            gameViewModel.Deck.DealCards(1, gameViewModel.Player);
            gameViewModel.Deck.DealCards(1, gameViewModel.Dealer, true);
            gameViewModel.Deck.DealCards(1, gameViewModel.Player);
            gameViewModel.Deck.DealCards(1, gameViewModel.Dealer, true);
            gameViewModel.Player.CalculateScore();
            gameViewModel.PlayerDone = false;
            gameViewModel.Result = "";
            
        }

        public IActionResult Hit()
        {
            gameViewModel.Deck.DealCards(1, gameViewModel.Player);
            gameViewModel.Player.CalculateScore();
            return View("Start", gameViewModel);
        }

        public IActionResult Stand()
        {
            gameViewModel.PlayerDone = true;

            gameViewModel.Dealer.CalculateScore();
            //Making the dealer hit
            while (gameViewModel.Dealer.Score < 16)
            {
                gameViewModel.Deck.DealCards(1, gameViewModel.Dealer);
                gameViewModel.Dealer.CalculateScore();
            }
            
            

            //Seeing who won
            if (gameViewModel.Player.Score == gameViewModel.Dealer.Score)
            {
                gameViewModel.Result = "Tie!";
                gameViewModel.Player.Wallet += gameViewModel.Player.BetAmount;
            }
            else if (gameViewModel.Dealer.Score > 21 && gameViewModel.Player.Score > 21)
            {
                gameViewModel.Result = "Tie!";
                gameViewModel.Player.Wallet += gameViewModel.Player.BetAmount;
            }
            if (gameViewModel.Player.Score > gameViewModel.Dealer.Score || gameViewModel.Dealer.Score > 21)
            {
                if (gameViewModel.Player.Score <= 21)
                {
                    gameViewModel.Result = $"{gameViewModel.Player.Name} Wins!";
                    gameViewModel.Player.Wallet += gameViewModel.Player.BetAmount*2;
                }
            }
            if (gameViewModel.Dealer.Score > gameViewModel.Player.Score || gameViewModel.Player.Score > 21)
            {
                if (gameViewModel.Dealer.Score <= 21)
                {
                    gameViewModel.Result = $"{gameViewModel.Dealer.Name} Wins!";
                }
            }


            return View("Start", gameViewModel);
        }

        public IActionResult Continue(int betInput)
        {

            gameViewModel.Player.BetAmount = betInput;
            gameViewModel.Player.Wallet -= gameViewModel.Player.BetAmount;
            gameViewModel.Player.Hand.Clear();
            gameViewModel.Dealer.Hand.Clear();
            DealNewGame();
            return View("Start", gameViewModel);
            
        }
        

    }
}
