
using PizzaLibrary.Interfaces;

namespace PizzaLibrary.Interface
{
    interface ILocation : IPizza
    {
        void DisplayLocation();
        void LocationValid();
    }
}
