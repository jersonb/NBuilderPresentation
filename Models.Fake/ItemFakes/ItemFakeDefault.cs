using FizzWare.NBuilder;

namespace Models.Fake.ItemFakes
{
    public class ItemFakeDefault : ModelFake<Item>
    {
        protected override ISingleObjectBuilder<Item> SetBuilder()
            => base.SetBuilder()
                   .With(item => item.IsActive, true);

        protected override IListBuilder<Item> SetListBuild(int size)
            => base.SetListBuild(size)
                   .All()
                   .Do(item =>
                   {
                       item.Name = Random.Phrase(10);
                       item.Value = Random.Next(1m, 100m);
                   })
                   .With(item => item.IsActive, true);
    }
}