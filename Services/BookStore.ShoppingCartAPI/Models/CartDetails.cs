﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BookStore.ShoppingCartAPI.Models.Dto;

namespace BookStore.ShoppingCartAPI.Models
{
    public class CartDetails
    {
        [Key]
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public CartHeader CartHeader { get; set; }
        public int BookId { get; set; }
        [NotMapped]
        public BookDto Book { get; set; }
        public int Count { get; set; }
    }
}
