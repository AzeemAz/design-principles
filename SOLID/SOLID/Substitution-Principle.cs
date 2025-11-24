namespace SOLID
{
    public class Rectangle
    {
        public int Width;
        public int Height;
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }
    public class Substitution_Principle
    {
        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(2, 3);
            Console.WriteLine($"{rec} has area {Area(rec)}");
        }
    }
}
