namespace InvoiceManager.Models
{
	public record InvoiceItem
	{
		public string? Id { get; set; }
		public string? InvoiceId { get; set; }
		public string? Description { get; set; }
		public int? Quantity { get; set; }
		public decimal? Price { get; set; }
		public decimal? Amount { get; set; }
    }
}

