using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAxos_RubenRojas.Services
{
    public interface IServiceRequest
    {
        public Task<IList<T>> GetDataAsync<T>(string path) where T : class;
    }

    public class ServiceRequest : IServiceRequest
    {
        public async Task<IList<T>> GetDataAsync<T>(string path) where T : class
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<List<T>>(path);
            if (response != null)
            {
                return response;
            }
            else 
            {
                return new List<T>();
            }
        }
    }
}
