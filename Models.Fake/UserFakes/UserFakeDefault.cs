using FizzWare.NBuilder;

namespace Models.Fake.UserFakes
{
    public class UserFakeDefault : ModelFake<User>
    {
        protected override ISingleObjectBuilder<User> SetBuilder()
            => base.SetBuilder()
                    .With(user => user.IsActive, true)
                    .With(user => user.Name, Faker.Person.FullName);
    }
}