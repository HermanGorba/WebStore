namespace WebStore.Models.Core
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public WebStoreUser? User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
