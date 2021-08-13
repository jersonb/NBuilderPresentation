﻿using System.Linq;
using FizzWare.NBuilder;
using Models.Fake.ItemFakes;
using Models.Fake.UserFakes;

namespace Models.Fake.InvoiceFakes
{
    public class InvoiceFakeWithInvalidItems : ModelFakeBase<Invoice>
    {
        protected override ISingleObjectBuilder<Invoice> SetBuilder()
            => base.SetBuilder()
                .With(invoice => invoice.Description, Faker.Company.CatchPhrase())
                .With(invoice => invoice.Amount = invoice.Items.Sum(item => item.Value))
                .With(invoice => invoice.IsActive, true)
                .With(invoice => invoice.Obsevations, Faker.Lorem.Words().ToList())
                .With(invoice => invoice.Items, new ItemFakeInvalid().GetListObject(2))
                .With(invoice => invoice.User, new UserFakeDefault().GetObject());
    }
}