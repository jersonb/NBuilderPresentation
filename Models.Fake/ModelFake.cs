using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;

namespace Models.Fake
{
    public class ModelFake<T> where T : class
    {
        protected RandomGenerator Random => new RandomGenerator();

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