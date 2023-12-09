namespace Business.Dtos.Responses
{
    public class CreatedProductResponse
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
    }
}
