namespace Task5.DTO
{
    public class cartResponseDTO
    {
        public int CartItemId { get; set; }

        public int? CartId { get; set; }

        public int Quantity { get; set; }

        public productDTO Product { get; set; }

    }

    public class productDTO
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int? Price { get; set; }
    }


}
