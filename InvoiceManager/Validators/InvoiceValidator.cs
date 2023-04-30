using System;
using System.ComponentModel.DataAnnotations;
using InvoiceManager.Models;

namespace InvoiceManager.Validators
{
	public class InvoiceValidator
	{
		public static ValidationResult ValidateInvoice(Invoice invoice)
		{
			if (string.IsNullOrWhiteSpace(invoice.Id))
			{
                return new ValidationResult("Invoice ID is required.");
            }

            return ValidationResult.Success;
        }

        public static ValidationResult ValidateInvoiceItem(InvoiceItem invoiceItem)
        {
            if (string.IsNullOrWhiteSpace(invoiceItem.Id))
            {
                return new ValidationResult("Invoice Item ID is required.");
            }

            return ValidationResult.Success;
        }
    }
}

