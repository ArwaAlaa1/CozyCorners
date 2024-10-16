﻿namespace CozyCorners.Core.Models.Order
{
	public class CartItem
	{
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }
}