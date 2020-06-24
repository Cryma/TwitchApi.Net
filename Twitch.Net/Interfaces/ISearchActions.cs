using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface ISearchActions
    {

        Task<HelixPaginatedResponse<HelixCategory>> SearchCategories(string query, int first = 20, string after = null);

    }
}
