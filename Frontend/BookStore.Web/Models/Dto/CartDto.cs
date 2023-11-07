namespace BookStore.Web.Models.Dto
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }//Shopping cart always have one shopping cart header
        public IEnumerable<CartDetailsDto>? CartDetails { get; set; }
    }
}
