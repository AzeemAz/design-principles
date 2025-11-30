public class Person
{
    public string Name, Position;
}
public abstract class FunctionalBuilder<TSubject, TSelf>
    where TSelf : FunctionalBuilder<TSubject, TSelf>
    where TSubject : new()
{
    private readonly List<Func<Person, Person>> actions
            = new List<Func<Person, Person>>();

    public PersonBuilder Called(string name)
    => Do(p => p.Name = name);
    public PersonBuilder Do(Action<Person> action)
        => AddAction(action);

    public Person Build()
    => actions.Aggregate(new Person(), (p, f) => f(p));
    private PersonBuilder AddAction(Action<Person> action)
    {
        actions.Add(p =>
        {
            action(p);
            return p;
        });
        return this;
    }
}

//public sealed class PersonBuilder
//{
//        private readonly List<Func<Person, Person>> actions
//            = new List<Func<Person, Person>>();

//        public PersonBuilder Called(string name)
//        => Do(p => p.Name = name);
//        public PersonBuilder Do(Action<Person> action)
//            => AddAction(action);

//        public Person Build()
//        => actions.Aggregate(new Person(), (p, f) => f(p));
//        private PersonBuilder AddAction(Action<Person> action)
//        {
//            actions.Add(p =>
//            {
//                action(p);
//                return p;
//            });
//            return this;
//        }
//}

public static class PersonBuilderExtenions
{
    public static PersonBuilder WorksAs
        (this PersonBuilder builder, string position)
        => builder.Do(p => p.Position = position);

}

public class Program
{
    public static void Main(string[] args)
    {
        var person = new PersonBuilder()
            .Called("Azeem")
            .WorksAs("Developer")
            .Build();
    }
}