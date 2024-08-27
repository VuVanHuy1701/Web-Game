using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An.Models
{
    public class Cart
    {
        public Game Game { get; set; }

        public int Quantity { get; set; }

        //contructor
        public Cart(Game game, int quantity)
        {
            Game = game;
            Quantity = quantity;
        }
    }
}