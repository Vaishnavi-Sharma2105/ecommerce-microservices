namespace UserService.DTOs
{
    public class CreateOrderDto
    {
        public int userId { get; set; } 
        public decimal amount { get; set; }
    }
}
