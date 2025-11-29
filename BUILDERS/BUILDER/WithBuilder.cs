using System.Text;

namespace BUILDER
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        public const int indentSize = 2;

        public HtmlElement()
        {
        }

        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        public string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImpl(indent + 1));
            }
            sb.AppendLine($"{i}</{Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();
        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }
        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }
        public override string ToString()
        {
            return root.ToString();
        }
        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }
    }

    public class WithBuilder
    {
        //static void Main(string[] args)
        //{
        //    var hello = "hello";
        //    var sb = new HtmlBuilder("p");
        //    sb.AddChild("p", hello);
        //    Console.WriteLine(sb.ToString());
        //    var words = new[] { "hello", "world" };
        //    var ulb = new HtmlBuilder("ul");
        //    foreach (var word in words)
        //    {
        //        ulb.AddChild("li", word);
        //    }
        //    Console.WriteLine(ulb.ToString());
        //}
    }
}
