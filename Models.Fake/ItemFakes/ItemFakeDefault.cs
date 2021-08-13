using FizzWare.NBuilder;

namespace Models.Fake.ItemFakes
{
    public class ItemFakeDefault : ModelFake<Item>
    {
        protected override IListBuilder<Item> SetListBuild(int size)
            => base.SetListBuild(size)
                    .All()
                    .Do(item =>
                    {
                        item.Name = Faker.Commerce.Product();
                        item.Value = Random.Decimal();
                        item.IsActive = true;
                    });
    }
}