﻿namespace ShoppingCart.API.Model
{
    public class ShoppingCartItem
    {
        public string MovieId { get; set; } = null!;

        public string MovieTitle { get; set; } = null!;

        public decimal Price { get; set; }
    }
}