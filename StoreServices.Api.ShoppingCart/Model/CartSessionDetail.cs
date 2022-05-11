﻿namespace StoreServices.Api.ShoppingCart.Model
{
    public class CartSessionDetail
    {
        public int CartSessionDetailId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ProductSelected { get; set; }
        public int CartSessionId { get; set; }
        public CartSession CartSession { get; set; }
    }
}
