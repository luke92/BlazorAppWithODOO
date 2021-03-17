using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ODOOIntegration.BlazorWeb.Shared;
using ODOOIntegration.BlazorWeb.Shared.ODOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODOOIntegration.BlazorWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public InvoiceController(IConfiguration configuration, ILogger<WeatherForecastController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<InvoiceModel>> Get()
        {
            var service = new ODOOIntegration.BlazorWeb.Shared.ODOO.Services.OdooService(_configuration);
            return await service.GetInvoices();
        }
    }
}
