using BlackJackMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackMvc.ViewModels
{
    public class GameViewModel
    {
        //Adding properties
        public Player Player { get; set; }
        public Player Dealer { get; set; }
        public Deck Deck { get; set; }
        public bool PlayerDone { get; set; }
        public string Result { get; set; }


    }
}
