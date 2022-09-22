using BtcTurkApi.Client.Managers.ApiManager;

namespace BtcTurkAPI.Client.Program
{
    public class Program
    {

        private static void Main()
        {
            ApiManager apiManager;

            apiManager = new ApiManager("YOUR_PUBLIC_KEY", "YOUR_PRIVATE_KEY", "https://api.btcturk.com");

        }
    }

}