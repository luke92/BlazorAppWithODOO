using ODOOIntegration.BlazorWeb.Shared.ODOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODOOIntegration.BlazorWeb.Shared.Models
{
    public class InvoiceModel
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalUntaxed { get; set; }

        public InvoiceModel() { }
        
    }
}
