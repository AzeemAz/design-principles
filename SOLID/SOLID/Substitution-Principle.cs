namespace SOLID
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public Rectangle() { }
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
    public class Square : Rectangle
    {
        public override int Width
        {
            set
            {
                base.Width = value;
                base.Height = value; 
            }
        }

        public override int Height
        {
            set
            {
                base.Height = value;
                base.Width = value; 
            }
        }   
    }
    public class Substitution_Principle
    {
        static public int Area(Rectangle r) => r.Width * r.Height;
        //static void Main(string[] args)
        //{
        //    Rectangle rec = new Rectangle(2, 3);
        //    Console.WriteLine($"{rec} has area {Area(rec)}");

        //    Rectangle sq = new Square();
        //    sq.Width = 5;
        //    Console.WriteLine($"{sq} has area {Area(sq)}");
        //}
    }
}
