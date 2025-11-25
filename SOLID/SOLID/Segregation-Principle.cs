namespace SOLID
{
    public class Document
    {

    }

    public interface IMachine
    {
        void Print(Document d);
        void Fax(Document d);
        void Scan(Document d);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            // Print implementation
        }
        public void Fax(Document d)
        {
            // Fax implementation
        }
        public void Scan(Document d)
        {
            // Scan implementation
        }
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }
    public class PhotoCopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            // Print implementation
        }
        public void Scan(Document d)
        {
            // Scan implementation
        }
    }
    public interface IMultiFunctionDevice : IPrinter, IScanner
    {
    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private readonly IPrinter _printer;
        private readonly IScanner _scanner;
        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            _printer = printer;
            _scanner = scanner;
        }
        public void Print(Document d)
        {
            _printer.Print(d);
        }
        public void Scan(Document d)
        {
            _scanner.Scan(d);
        }
    }
    public class Segregation_Principle
    {
    }
}
