using System;
using Xunit;
using PizzaLibrary.Classes;
using PizzaLibrary;

namespace PizzaUnitTester
{
    public class PizzaTester
    {
        private readonly MasterOrderList mol;

        [Theory]
        [InlineData(10)]
        [InlineData(0)]
        [InlineData(12)]
        [InlineData(1)]
        //MasterOrderList method
        public void NumberOfOrdersValidLessThan12(int orders)
        {

            var result = MasterOrderList.NumberOfOrdersValid(orders);
            Assert.True(result, $"{result} should be valid.");


        }
    }
}
