using System.Collections.Generic;
using System.Linq;
using Bogus;
using FizzWare.NBuilder;

namespace Models.Fake
{
    public class ModelFakeBase<T> where T : class
    {
        protected Faker Faker => new Faker("pt_BR");
        public RandomGenerator Random => new RandomGenerator();

        protected virtual ISingleObjectBuilder<T> SetBuilder()
            => Builder<T>.CreateNew();

        public T GetObject()
           => SetBuilder().Build();

        protected virtual IListBuilder<T> SetListBuild(int size)
            => Builder<T>.CreateListOfSize(size)
                             .All();

        public List<T> GetListObject(int size = 10)
            => SetListBuild(size).Build()
                                 .ToList();
    }
}