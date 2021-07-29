using Strategy_Pattern_Using_different_shipping_providers.Business.Models;

namespace Strategy_Pattern_Using_different_shipping_providers.Business.Strategies.Shipping
{
    public interface IShippingStrategy
    {
        void Ship(Order order);//order contains how it will be shipped.each strategy has its implementation
    }
}
