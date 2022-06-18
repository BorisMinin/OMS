namespace OMS.API.Models.OrderDetailDto
{
    /// <summary>
    ///  todo: написать комментарий
    /// </summary>
    public class OrderDetailDtoCreate
    {
        // todo: написать комментарий
        public int OrderId { get; set; }
        // todo: написать комментарий
        public int ProductId { get; set; }
        // todo: написать комментарий
        public decimal UnitPrice { get; set; }
        // todo: написать комментарий
        public short Quantity { get; set; }
        // todo: написать комментарий
        public float Discount { get; set; }

        public virtual ICollection<OrderDetailDtoCreate> OrderDetailCreate { get; set; }
    }
}