namespace PizzaLibrary.Classes
{
    public interface IPizza
    {
        bool hasHam { get; set; }
        bool hasHotsauce { get; set; }
        bool hasPepperoni { get; set; }
        bool hasSausage { get; set; }
        double price { get; set; }

        string CalculatePizzaCost(int numIngredients);
        Pizza ChangeTopping(Pizza p, StoreLocation s, string topping, bool remove);
        bool CheckStoreInventory(StoreLocation s);
        string ToString();
        bool ValidPizza(Pizza p);
    }
}