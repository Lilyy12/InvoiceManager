namespace InvoiceManager.Models
{
	public record Invoice
	{
		public string? Id { get; set; }
		public string? Number { get; set; }
		public DateTime? Date { get; set; }
        public DateTime? DueDate { get; set; }
		public decimal? TotalAmount { get; set; }
		public string? Status { get; set; }
		public string? Note { get; set; }
    }
}

