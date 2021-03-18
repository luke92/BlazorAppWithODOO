using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODOOIntegration.BlazorWeb.Shared.ODOO.Models
{
    public class AccountMoveOdoo
    {
        public string access_token { get; set; }
        public string access_url { get; set; }
        public string display_name { get; set; }
        public string activity_state { get; set; }
        public string activity_summary { get; set; }
        public decimal amount_residual { get; set; }
        public decimal amount_tax { get; set; }
        public decimal amount_total { get; set; }
        public decimal amount_untaxed { get; set; }
        public DateTime create_date { get; set; }
        public DateTime date { get; set; }
        public long id { get; set; }
        public string type_name { get; set; }
        public string invoice_origin { get; set; }
        /// <summary>
        /// entry -> Payment | out_invoice -> Invoice
        /// </summary>
        public string move_type { get; set; }
    }
}
