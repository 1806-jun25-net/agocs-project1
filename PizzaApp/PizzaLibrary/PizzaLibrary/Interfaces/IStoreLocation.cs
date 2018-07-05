namespace PizzaLibrary.Classes
{
    public interface IStoreLocation
    {
        int Ham { get; set; }
        int Hotsauce { get; set; }
        string Location { get; set; }
        int Pepperoni { get; set; }
        int Sausage { get; set; }

        void DisplayInventory();
        bool EmptyInventory(StoreLocation s);
        string ToString();
    }
}