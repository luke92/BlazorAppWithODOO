using ODOOIntegration.BlazorWeb.Shared.ODOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ODOOIntegration.BlazorWeb.Shared.ODOO.Services
{
    public class OdooService
    {
        private IConfiguration _configuration;

        public OdooService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<InvoiceModel>> GetInvoices()
        {
            try
            {
                var clientOdoo = await GetClient();
                
                var invoices = await clientOdoo.GetAll<List<InvoiceModel>>("account.move",new OdooRpc.CoreCLR.Client.Models.Parameters.OdooFieldParameters());
                
                return invoices;
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private async Task<OdooRpc.CoreCLR.Client.OdooRpcClient> GetClient()
        {
            var odoo = _configuration.GetSection("ODOOConfiguration");
            var host = odoo["host"];
            var database = odoo["database"];
            var isSSL = odoo["IsSSL"];
            var port = odoo["Port"];
            var username = odoo["Username"];
            var password = odoo["password"];

            var clientOdoo = new OdooRpc.CoreCLR.Client.OdooRpcClient(new OdooRpc.CoreCLR.Client.Models.OdooConnectionInfo
            {
                Host = host,
                Database = database,
                IsSSL = Boolean.Parse(isSSL),
                Port = int.Parse(port),
                Username = username,
                Password = password
            });

            await clientOdoo.Authenticate();

            return clientOdoo;

        }

        private async Task<OdooRpc.CoreCLR.Client.Models.OdooVersionInfo> GetVersion(OdooRpc.CoreCLR.Client.OdooRpcClient client)
        {
            return await client.GetOdooVersion();
        }
        
        private async Task OtherMethods(OdooRpc.CoreCLR.Client.OdooRpcClient clientOdoo)
        {
            var countCustomers = await clientOdoo.SearchCount(new OdooRpc.CoreCLR.Client.Models.Parameters.OdooSearchParameters("res.partner"));
            var countInvoices = await clientOdoo.SearchCount(new OdooRpc.CoreCLR.Client.Models.Parameters.OdooSearchParameters("account.move"));
            var countPayments = await clientOdoo.SearchCount(new OdooRpc.CoreCLR.Client.Models.Parameters.OdooSearchParameters("account.payment"));
            var countProducts = await clientOdoo.SearchCount(new OdooRpc.CoreCLR.Client.Models.Parameters.OdooSearchParameters("product.template"));
            var countTaxes = await clientOdoo.SearchCount(new OdooRpc.CoreCLR.Client.Models.Parameters.OdooSearchParameters("account.tax"));
            var tiposComprobante = await clientOdoo.SearchCount(new OdooRpc.CoreCLR.Client.Models.Parameters.OdooSearchParameters("l10n_latam.document.type"));
            var tiposContribuyente = await clientOdoo.SearchCount(new OdooRpc.CoreCLR.Client.Models.Parameters.OdooSearchParameters("l10n_ar.afip.responsibility.type"));
            var cuentasTesoreria = await clientOdoo.SearchCount(new OdooRpc.CoreCLR.Client.Models.Parameters.OdooSearchParameters("account.account"));
            var diariosContables = await clientOdoo.SearchCount(new OdooRpc.CoreCLR.Client.Models.Parameters.OdooSearchParameters("account.journal"));
        }
    }
}
