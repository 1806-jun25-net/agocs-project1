
namespace PizzaLibrary.Interfaces
{
    interface IInventory : IPizza
    {
        void DisplayInventory();
        bool InventoryEmpty();
    }
}
