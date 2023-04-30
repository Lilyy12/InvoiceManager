using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InvoiceManager.Models;
using InvoiceManager.Storage;
using InvoiceManager.Validators;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManager.Controllers
{
    [ApiController]
    [Route("api/invoice")]
    public class InvoicesController : ControllerBase
    {
        private IInvoiceStorage _invoiceStorage;
        public InvoicesController(IInvoiceStorage invoiceStorage)
        {
            _invoiceStorage = invoiceStorage;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_invoiceStorage.GetInvoiceList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Invoice invoice)
        {
            var validationResult = InvoiceValidator.ValidateInvoice(invoice);

            if (validationResult != ValidationResult.Success)
            {
                return BadRequest(validationResult.ErrorMessage);
            }

            _invoiceStorage.PostInvoice(invoice);
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult Put([FromRoute] string id, [FromBody] Invoice invoice)
        {
            _invoiceStorage.PutInvoice(id, invoice);
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult Delete([FromRoute] string id)
        {
            _invoiceStorage.DeleteInvoice(id);
            return Ok();
        }

    }
}

