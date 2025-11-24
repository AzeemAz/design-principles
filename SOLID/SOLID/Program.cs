using System.Diagnostics;

public class Demo
{
    public class Journal
    {
        private readonly List<string> entries = new();
        public static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllBytes(filename, System.Text.Encoding.UTF8.GetBytes(j.ToString()));
            }
        }
        
    }

    //public static void Main(string[] args)
    //{
    //    var j = new Journal();
    //    j.AddEntry("I cried today.");
    //    j.AddEntry("I ate a bug.");
    //    Console.WriteLine(j);

    //    var p = new Persistence();
    //    var filename = "text.txt";
    //    p.SaveToFile(j, filename, true);
    //    Process.Start(filename);
    //}
}