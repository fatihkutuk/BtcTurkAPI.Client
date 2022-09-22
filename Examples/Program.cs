



using BtcTurkApi.Client.Helpers;
using BtcTurkApi.Client.Managers.ApiManager;
using BtcTurkApi.Client.Models;

namespace Examples
{
    public class Program
    {

        private static void Main()
        {
            ApiManager apiManager;

            apiManager = new ApiManager("YOUR_PUBLIC_KEY", "YOUR_PRIVATE_KEY", "https://api.btcturk.com");


            var balances = apiManager.GetBalances();//GetBalances -> reutns the balances and here it ill return your all balances
            foreach (var item in balances.Result.Data)
            {
                Console.WriteLine($"{item.AssetName} {item.Balance}");
            }

            //-------------------------------------------------------------------------//

            var ohcl = apiManager.GetDailyOhlc("LINKTRY", 30);//GetDailyOhlc -> returns DailyOhcl and here it ill return linktry ohlc for last 30 day
            foreach (var item in ohcl.Result.Data)
            {
                Console.WriteLine($"{item.Volume} {item.Open} {item.Close}");
            }

            //-------------------------------------------------------------------------//

            var order = apiManager.CreateOrder(new OrderInput //CreateOrder -> it ill created a transaction and here it ill limit buy BTCTRY for 306657 TRY and 0.00055 quantity
            {
                NewOrderClientId = "",
                OrderMethod = OrderMethod.Limit,
                OrderType = OrderType.Buy,
                PairSymbol = "BTCTRY",
                Price = 306657,
                Quantity = 0.00055m,
                StopPrice = 306657
            });
            Console.WriteLine(order.Result.Data.Amount);
            Console.WriteLine(order.Result.Message);

            //-------------------------------------------------------------------------//

            var orderList = apiManager.GetOpenOrders("BTCTRY"); // GetOpenOrders -> it ill return open order transaction (if no given pair symbol it ill get orders for all pairs) here it ill return your openc BTCTRY orders
            Console.WriteLine(orderList.Result.Data.Bids[0].Id);

            //-------------------------------------------------------------------------//

            var cancelOrder = apiManager.CancelOrder(orderList.Result.Data.Bids[0].Id); // CancelOrder -> it ill delete an open order by order id and here it ill delete first order in orderlist
            Console.WriteLine(cancelOrder.Result.ToString());

            //-------------------------------------------------------------------------//

            var userTrades = apiManager.GetUserTrades(new string[] { "buy", "sell" }, new string[] { "link", "try" }, DateTime.Now.AddYears(-2).ToUnixTime(), DateTime.Now.ToUnixTime()); // GeyUserTrades-> it returns your trransactions and here it ill return link transactions las 2 year
            Console.WriteLine(userTrades.Result.Data[0].Price);

            //-------------------------------------------------------------------------//

            var lastTrades = apiManager.GetLastTrades("linktry", 1000); // GetLastTrades -> it ill your last trades by symbol and quantity and here it ill return your last 1000 linktry transactions
            Console.WriteLine(lastTrades.Result.Data[0].Price);

            //-------------------------------------------------------------------------//

            var cryptoTransactions = apiManager.GetUserCryptoTransactions(new string[] { "deposit", "withdrawal" }, new string[] { "xrp", "trx" }, DateTime.Now.AddYears(-2).ToUnixTime(), DateTime.Now.ToUnixTime()); //GetUserCryptoTransactions -> it returns your crypto transaction and here it ill return xrp and trx transaction for alst 2 year
            Console.WriteLine(cryptoTransactions.Result.Data[0].Fee);

            //-------------------------------------------------------------------------//

            var fiatTransactions = apiManager.GetUserFiatTransactions(new string[] { "deposit", "withdrawal" }, new string[] { "try" }, DateTime.Now.AddYears(-2).ToUnixTime(), DateTime.Now.ToUnixTime()); //GetUserCryptoTransactions -> it returns your fiat transaction and here it ill return try transaction for alst 2 year
            Console.WriteLine(fiatTransactions.Result.Data[0].Fee);

            //-------------------------------------------------------------------------//

            var orderbook = apiManager.GetOrderBook("BTCTRY", 100); // GetOrderBook -> it returns last orders by symbol and quantitiy and here it ill return lst 100 order for btctry
            Console.WriteLine(orderbook.Result.Data.Bids[0][0]);

            //-------------------------------------------------------------------------//

            var ticker = apiManager.GetTicker("BTCTRY"); // GetTicker -> it returns tickers (if u dont give a parameters it ill returnt all tickers ) and here it ill return btctry ticker
            Console.WriteLine(ticker.Result.Data[0].High);
        }

    }
}

