namespace BookStore.ShoppingCartAPI.Models.Dto
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }//Shopping cart always have one header
        public IEnumerable<CartDetailsDto>? CartDetails { get; set; }
    }
}
