
using PizzaLibrary.Interfaces;

namespace PizzaLibrary.Interface
{
    interface IStoreLocation : IPizza
    {
        void DisplayInventory();
        void DisplayLocation();
        bool LocationValid();
        bool InventoryValid();
        
    }
}
