using FizzWare.NBuilder;

namespace Models.Fake.ItemFakes
{
    public class ItemFakeInvalid : ModelFakeBase<Item>
    {
        protected override IListBuilder<Item> SetListBuild(int size)
        {
            return base.SetListBuild(size)
                        .All()
                        .Do(item =>
                        {
                            item.IsActive = true;
                            item.Value = 0;
                        });
        }
    }
}