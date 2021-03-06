using System.Linq;
using FizzWare.NBuilder;
using Models.Fake.ItemFakes;
using Models.Fake.UserFakes;

namespace Models.Fake.InvoiceFakes
{
    public class InvoiceFakeDefault : ModelFake<Invoice>
    {
        protected override ISingleObjectBuilder<Invoice> SetBuilder()
            => base.SetBuilder()
                .With(invoice => invoice.Obsevations, Random.Phrase(Random.Next(2, 30)).Split(" ").ToList())
                .With(invoice => invoice.Items, new ItemFakeDefault().GetListObject(2))
                .With(invoice => invoice.User, new UserFakeDefault().GetObject())
                .With(invoice => invoice.InvoiceType, Random.Enumeration<InvoiceType>())
                .With(invoice => invoice.Description = invoice.InvoiceType.ToString())
                .With(invoice => invoice.Amount = invoice.Items.Sum(item => item.Value))
                .With(invoice => invoice.IsActive, true);
    }
}