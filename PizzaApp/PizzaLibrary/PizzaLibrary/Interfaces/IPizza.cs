
namespace PizzaLibrary.Interfaces
{
    interface IPizza : IOrder
    {

        void DisplayPizza();
        bool PizzaValid();

    }
}
