using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ServiceContracts;
using Services;

namespace Tests 
{
    public class StockServiceTests
    {
        private readonly IStockService _stockService;

        public StockServiceTests()
        {
            _stockService = new StocksService();
        }
        
        #region CreateBuyorder
        [Fact]
        public async void CreateBuyOrder_Null() {

            //arrange

            

            BuyOrderRequest? buyOrderRequest = null;

            //assert and act

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>

              await _stockService.CreateBuyOrder(buyOrderRequest)
            );

        }

        [Fact]
        public async void CreateBuyOrder_buyOrderQuantity()
        {

            //arrange

            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 0,
                Price = 247.8

            };

            

            //assert and act

            await Assert.ThrowsAsync<ArgumentException>(async () =>

              await _stockService.CreateBuyOrder(buyOrderRequest)
            );

        }

        [Fact]
        public async void CreateBuyOrder_buyOrderQuantityabove100000()
        {

            //arrange

            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 100001,
                Price = 247.8

            };



            //assert and act

            await Assert.ThrowsAsync<ArgumentException>(async () =>

              await _stockService.CreateBuyOrder(buyOrderRequest)
            );

        }


        [Fact]
        public async void CreateBuyOrder_buyOrderprice0()
        {

            //arrange

            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 0

            };



            //assert and act

            await Assert.ThrowsAsync<ArgumentException>(async () =>

              await _stockService.CreateBuyOrder(buyOrderRequest)
            );

        }

        [Fact]
        public async void CreateBuyOrder_buyOrderpriceabove10001()
        {

            //arrange

            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 10001

            };



            //assert and act

            await Assert.ThrowsAsync<ArgumentException>(async () =>

              await _stockService.CreateBuyOrder(buyOrderRequest)
            );

        }

        [Fact]
        public async void CreateBuyOrder_buyOrderStockSymbol_null()
        {

            //arrange

            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 100

            };

            buyOrderRequest.StockSymbol = null;

            //assert and act

            await Assert.ThrowsAsync<ArgumentException>(async () =>

              await _stockService.CreateBuyOrder(buyOrderRequest)
            );

        }

        [Fact]
        public async void CreateBuyOrder_buyOrderDate()
        {

            //arrange

            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("1999-03-19"),
                Quantity = 1000,
                Price = 100

            };

            

            //assert and act

            await Assert.ThrowsAsync<ArgumentException>(async () =>

              await _stockService.CreateBuyOrder(buyOrderRequest)
            );

        }

        [Fact]
        public async void CreateBuyOrder_validBuyOrder()
        {

            //arrange

            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 100

            };



            //assert and act



            BuyOrderResponse? response = await _stockService.CreateBuyOrder(buyOrderRequest);

            Assert.NotNull(response);

            Assert.NotEqual(Guid.Empty, response.BuyOrderId);
            

        }
        #endregion


    }
}


