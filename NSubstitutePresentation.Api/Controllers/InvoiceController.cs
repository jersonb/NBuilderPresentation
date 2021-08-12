using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;

namespace NSubstitutePresentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var simpleInstance = new Invoice();

            var nbuilder = Builder<Invoice>.CreateNew().Build();

            return JsonConvert.SerializeObject((simpleInstance, nbuilder));
        }
    }
}