using System;
using InvoiceManager.Models;

namespace InvoiceManager.Storage
{
	public interface IInvoiceStorage
	{
        public List<Invoice> GetInvoiceList();
        public void PostInvoice(Invoice invoice);
        public void PutInvoice(string id, Invoice invoice);
        public void DeleteInvoice(string id);
    }
	public class InvoiceStorage : IInvoiceStorage
	{
		private List<Invoice> _invoices;
        public InvoiceStorage()
        {
            _invoices = new List<Invoice>();
        }

        public List<Invoice> GetInvoiceList()
        {
            return _invoices;
        }

        public void PostInvoice(Invoice invoice)
        {
            var list = new List<Invoice>();
            list.Add(invoice);
            _invoices = list;
        }

        public void PutInvoice(string id, Invoice updatedInvoice)
        {
            //retrieve an invoice that has id matching
            var existingInvoice = _invoices.Find(x=>x.Id == id);
            if (existingInvoice is null)
            {
                throw new Exception("No invoice found");
            }
            existingInvoice!.Id = updatedInvoice.Id;
            existingInvoice.Number = updatedInvoice.Number;
            existingInvoice.Date = updatedInvoice.Date;
            existingInvoice.DueDate = updatedInvoice.DueDate;
            existingInvoice.TotalAmount = updatedInvoice.TotalAmount;
            existingInvoice.Status = updatedInvoice.Status;
            existingInvoice.Note = updatedInvoice.Note;
        }

        public void DeleteInvoice(string id)
        {
            var existingInvoice = _invoices.Find(x => x.Id == id);
            _invoices.Remove(existingInvoice);
        }
    }
}

