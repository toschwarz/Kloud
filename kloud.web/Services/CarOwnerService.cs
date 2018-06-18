using kloud.web.Interfaces;
using kloud.web.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace kloud.web.Services
{
    public class CarOwnerService:ICarOwnerService
    {
        /// <summary>
        /// Application Settings
        /// </summary>
        public readonly AppSettings _appSettings;

        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Cars service constructor
        /// </summary>
        public CarOwnerService(AppSettings appsettings)
        {
            _appSettings = appsettings;
        }

        /// <summary>
        /// Retrieves the Json (as string) from the API via HttpClient
        /// </summary>
        /// <returns>Output from the API as string</returns>
        public async Task<string> CallAPI()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Core");

            // Get the URL for the API from appsettings
            string Url = _appSettings.APIurl;

            var stringTask = client.GetStringAsync(Url);

            var msg = await stringTask;
            return msg;
        }
    }
}
