using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Fake;
using Models.Fake.InvoiceFakes;
using Newtonsoft.Json;

namespace NSubstitutePresentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpGet("total-default")]
        public Invoice GetSingleTotalDefault()
        {
            return new InvoiceFakeTotalDefault().GetObject();
        }
        
        [HttpGet("default")]
        public Invoice GetSingleDefault()
        {
            return new InvoiceFakeDefault().GetObject();
        }

        [HttpGet("default/{size}")]
        public IEnumerable<Invoice> GetListDefault(int size)
        {
            return new InvoiceFakeTotalDefault().GetListObject(size);
        }

        [HttpGet("compare")]
        public IActionResult GetCompare()
        {
            var invoice = new Invoice();
            var json = JsonConvert.SerializeObject((new InvoiceFakeTotalDefault().GetObject(), invoice));
            return Ok(json);
        }
    }
}