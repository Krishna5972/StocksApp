using ServiceContracts;
using ServiceContracts.DTO;
using Entities;
using Services.Helpers;

namespace Services
{
    public class StocksService : IStockService
    {

        readonly List<BuyOrder> _orders;

        public StocksService()
        {
            _orders = new List<BuyOrder>();
        }
        public Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {

            if(buyOrderRequest == null)
                throw new ArgumentNullException(nameof(buyOrderRequest));

            ValidationHelper.ModelValidation(buyOrderRequest);

            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();

            buyOrder.BuyOrderID = Guid.NewGuid();

            _orders.Add(buyOrder);

            return Task.FromResult(buyOrder.ToBuyOrderResoponse());

        }

        public Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            throw new NotImplementedException();
        }

        public Task<BuyOrderResponse> GetBuyOrders()
        {
            throw new NotImplementedException();
        }

        public Task<SellOrderResponse> GetSellOrders()
        {
            throw new NotImplementedException();
        }
    }
}