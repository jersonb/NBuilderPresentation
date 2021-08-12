using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Fake.InvoiceFakes;

namespace NSubstitutePresentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public Invoice Get()
        {
            return new InvoiceFakeDefault().GetObject();
        }
    }
}