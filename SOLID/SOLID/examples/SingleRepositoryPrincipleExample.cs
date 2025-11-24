namespace SOLID.examples
{
    public class CalculatesTotal
    {
        private readonly List<decimal> _items;
        public CalculatesTotal(List<decimal> items)
        {
            _items = items;
        }
        public decimal Total()
        {
            decimal total = 0;
            foreach (var item in _items)
            {
                total += item;
            }
            return total;
        }
    }

    public class AppliesDiscount
    {
        private readonly decimal _total;
        public AppliesDiscount(decimal total)
        {
            _total = total;
        }
        public decimal DiscountedTotal(decimal discountPercentage)
        {
            return _total - (_total * discountPercentage / 100);
        }
    }

    public class StoresItem
    {
        private readonly List<string> _items = new();
        public void AddItem(string item)
        {
            _items.Add(item);
            Console.WriteLine($"Item '{item}' added to the store.");
        }
    }

    public class GetAllItems
    {
        private readonly List<string> _items;
        public GetAllItems(List<string> items)
        {
            _items = items;
        }
        public List<string> RetrieveAll()
        {
            return _items;
        }
    }

    public class SingleRepositoryPrincipleExample
    {
        //static void Main(string[] args)
        //{
        //    StoresItem store = new StoresItem();
        //    store.AddItem("apple");
        //    store.AddItem("banana");
        //    store.AddItem("orange");

        //    var itemsList = new List<string> {"apple", "banana", "orange"};
        //    GetAllItems getAllItems = new GetAllItems(itemsList);

        //    var allItems = getAllItems.RetrieveAll();
        //    Console.WriteLine("All items in the store:");
        //    foreach (var item in allItems)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}
    }
}
