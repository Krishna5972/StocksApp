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
using Entities;

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


        #region CreateSellOrder

        [Fact]
        public async void CreateSellOrder_Null()
        {

            //arrange



            SellOrderRequest? sellOrderRequest = null;

            //assert and act

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>

              await _stockService.CreateSellOrder(sellOrderRequest)
            );

        }

        [Fact]
        public async void CreateSellOrder_buyOrderQuantity()
        {

            //arrange

            SellOrderRequest sellOrderResquest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 0,
                Price = 247.8

            };



            //assert and act

            await Assert.ThrowsAsync<ArgumentException>(async () =>

              await _stockService.CreateSellOrder(sellOrderResquest)
            );

        }

        [Fact]
        public async void CreateSellOrder_sellOrderQuantityabove100000()
        {

            //arrange

            SellOrderRequest sellOrderResquest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 100001,
                Price = 247.8

            };



            //assert and act

            await Assert.ThrowsAsync<ArgumentException>(async () =>

              await _stockService.CreateSellOrder(sellOrderResquest)
            );

        }


        [Fact]
        public async void CreateSellOrder_sellOrderprice0()
        {

            //arrange

            SellOrderRequest sellOrderResquest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 0

            };



            //assert and act

            await Assert.ThrowsAsync<ArgumentException>(async () =>

              await _stockService.CreateSellOrder(sellOrderResquest)
            );

        }

        [Fact]
        public async void CreateSellOrder_sellOrderpriceabove10001()
        {

            //arrange

            SellOrderRequest sellOrderResquest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 10001

            };



            //assert and act

            await Assert.ThrowsAsync<ArgumentException>(async () =>

              await _stockService.CreateSellOrder(sellOrderResquest)
            );

        }

        [Fact]
        public async void CreatesellOrder_sellOrderStockSymbol_null()
        {

            //arrange

            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 100

            };

            sellOrderRequest.StockSymbol = null;

            //assert and act

            await Assert.ThrowsAsync<ArgumentException>(async () =>

              await _stockService.CreateSellOrder(sellOrderRequest)
            );

        }

        [Fact]
        public async void CreateSellOrder_sellOrderDate()
        {

            //arrange

            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("1999-03-19"),
                Quantity = 1000,
                Price = 100

            };



            //assert and act

            await Assert.ThrowsAsync<ArgumentException>(async () =>

              await _stockService.CreateSellOrder(sellOrderRequest)
            );

        }

        [Fact]
        public async void CreateSellOrder_validSellOrder()
        {

            //arrange

            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 100

            };



            //assert and act



            SellOrderResponse? response = await _stockService.CreateSellOrder(sellOrderRequest);

            Assert.NotNull(response);

            Assert.NotEqual(Guid.Empty, response.SellOrderID);
        }


        #endregion



        #region GetAllBuyOrders


        [Fact]
        public async void GetAllBuyOrders_default()
        {

            List<BuyOrderResponse> buyOrders = new List<BuyOrderResponse>();

            buyOrders = await _stockService.GetBuyOrders();

            Assert.Empty(buyOrders);
        }

        [Fact]
        public async void GetAllBuyOrders_valid()
        {

            //arange

            List<BuyOrderResponse> buyOrdersExpected = new List<BuyOrderResponse>();

            BuyOrderRequest buyOrderRequest1 = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 267.3

            };


            BuyOrderRequest buyOrderRequest2 = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 275

            };

            BuyOrderRequest buyOrderRequest3 = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 290

            };


            buyOrdersExpected.Add(await _stockService.CreateBuyOrder(buyOrderRequest1));
            buyOrdersExpected.Add(await _stockService.CreateBuyOrder(buyOrderRequest2));
            buyOrdersExpected.Add(await _stockService.CreateBuyOrder(buyOrderRequest3));



            List<BuyOrderResponse> buyOrdersActual = new List<BuyOrderResponse>();

            buyOrdersActual = await _stockService.GetBuyOrders();

            foreach (BuyOrderResponse response in buyOrdersExpected)
            {
                Assert.Contains(response, buyOrdersActual);
            }
        }

        #endregion


        #region GetAllSellOrders


        [Fact]
        public async void GetAllSellOrders_default()
        {

            List<SellOrderResponse> sellOrders = new List<SellOrderResponse>();

            sellOrders = await _stockService.GetSellOrders();

            Assert.Empty(sellOrders);
        }

        [Fact]
        public async void GetAllSellOrders_valid()
        {

            //arange

            List<SellOrderResponse> sellOrdersExpected= new List<SellOrderResponse>();

            SellOrderRequest sellOrderRequest1 = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 267.3

            };


            SellOrderRequest sellOrderRequest2 = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 275

            };

            SellOrderRequest sellOrderRequest3 = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corp",
                DateAndTimeOfOrder = Convert.ToDateTime("2023-03-19"),
                Quantity = 1000,
                Price = 290

            };


            sellOrdersExpected.Add(await _stockService.CreateSellOrder(sellOrderRequest1));
            sellOrdersExpected.Add(await _stockService.CreateSellOrder(sellOrderRequest2));
            sellOrdersExpected.Add(await _stockService.CreateSellOrder(sellOrderRequest3));



            List<SellOrderResponse> sellOrdersActual = new List<SellOrderResponse>();

            sellOrdersActual = await _stockService.GetSellOrders();

            foreach (SellOrderResponse response in sellOrdersActual)
            {
                Assert.Contains(response, sellOrdersActual);
            }
        }

        #endregion

    }
}


