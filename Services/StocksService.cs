using ServiceContracts;
using ServiceContracts.DTO;
using Entities;
using Services.Helpers;

namespace Services
{
    public class StocksService : IStockService
    {

        readonly List<BuyOrder> _buyOrders;
        readonly List<SellOrder> _sellOrders;

        public StocksService()
        {
            _buyOrders = new List<BuyOrder>();
            _sellOrders = new List<SellOrder>();
        }
        public Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {

            if(buyOrderRequest == null)
                throw new ArgumentNullException(nameof(buyOrderRequest));

            ValidationHelper.ModelValidation(buyOrderRequest);

            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();

            buyOrder.BuyOrderID = Guid.NewGuid();

            _buyOrders.Add(buyOrder);

            return Task.FromResult(buyOrder.ToBuyOrderResoponse());

        }

        public Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            if(sellOrderRequest == null)
                throw new ArgumentNullException(nameof(sellOrderRequest));

            ValidationHelper.ModelValidation(sellOrderRequest);

            SellOrder sellOrder = sellOrderRequest.ToSellOrder();

            sellOrder.SellOrderID = Guid.NewGuid();

            _sellOrders.Add(sellOrder);

            return Task.FromResult(sellOrder.ToSellOrderResoponse());
        }

        public Task<List<BuyOrderResponse>> GetBuyOrders()
        {
            
            return Task.FromResult(
                
                _buyOrders.OrderByDescending(x =>
                x.DateAndTimeOfOrder)
                .Select(x=>
                x.ToBuyOrderResoponse()
                    ).ToList()
                
                );

        }

        public Task<List<SellOrderResponse>> GetSellOrders()
        {
            return Task.FromResult(

                _sellOrders.OrderByDescending(x =>
                x.DateAndTimeOfOrder)
                .Select(x =>
                x.ToSellOrderResoponse()
                    ).ToList()

                );
        }

    }
}