using System.Threading.Tasks;
using Umbraco_Azure_test.Models;

namespace Umbraco_Azure_test.Services
{
    public interface IExternalApiService
    {
        Task<JokeModel> GetJokeAsync();
    }
}
