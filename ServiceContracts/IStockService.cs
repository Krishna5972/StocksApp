using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IStockService
    {
        /// <summary>
        /// 
        ///Inserts a new buy order into the database table called 'BuyOrders'
        /// </summary>
        /// <param name="buyOrderRequest"></param>
        /// <returns>Returns a BuyOrderResponse</returns>
        Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest);

        /// <summary>
        /// Returns the existing list of buy orders retrieved from the database table called 
        /// "BuyOrders"
        /// </summary>
        /// <returns>List of BuyOrderResponse </returns>
        Task<BuyOrderResponse> GetBuyOrders();

        /// <summary>
        /// Inserts a new sell order into the database table called 'sellOrders'
        /// </summary>
        /// <param name="sellOrderRequest"></param>
        /// <returns>Returns a SellOrderResponse after inserting</returns>
        Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest);


        /// <summary>
        /// Returns the existing list of sell orders retrieved from the database table called 
        /// "SellOrders"
        /// </summary>
        /// <returns>Returns a list of SellOrderResponse</returns>
        Task<SellOrderResponse> GetSellOrders();


    }
}
