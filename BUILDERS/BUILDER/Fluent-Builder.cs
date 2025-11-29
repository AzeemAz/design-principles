namespace BUILDER
{
  public class Person
    {
        public string Name;
        public string Position;

        public class Builder : PersonJobBuilder<Builder>
        {
        }

        public static Builder New => new Builder();
        public override string ToString()
        {
            return $"{Name} works as {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();
        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<SELF>
        : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF) this;
        }
    }
    public class PersonJobBuilder<SELF>
        : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAs(string position)
        {
            person.Position = position;
            return (SELF) this;
        }
    }

    public class Fluent_Builder
    {
        //public static void Main(string[] args)
        //{
        //    var person = Person.New
        //        .Called("John")
        //        .WorksAs("Developer").Build();

        //    Console.WriteLine(person);
        //}
    }
}
