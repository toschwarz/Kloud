using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace kloud.web.Interfaces
{
    public interface ICarOwnerService
    {
        /// <summary>
        /// Retrieves the Json (as string) from the API via HttpClient
        /// </summary>
        /// <returns>Output from the API as string</returns>
        Task<string> CallAPI();
    }
}
