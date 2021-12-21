using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IGameActions
    {

        /// <summary>
        /// Get games with the most viewers
        /// </summary>
        /// <param name="first">Amount of games. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <returns><see cref="HelixPaginatedResponse{TResponseObject}"/> with games</returns>
        Task<HelixPaginatedResponse<HelixGame>> GetTopGames(int first = 20, string after = null, string before = null);


        /// <summary>
        /// Get games from game ids
        /// </summary>
        /// <param name="gameIds">Array of game ids. Limit: 100</param>
        /// <returns><see cref="HelixResponse{TResponseObject}"/> with games</returns>
        Task<HelixResponse<HelixGame>> GetGamesFromIds(string[] gameIds);

        /// <summary>
        /// Get games from game names
        /// </summary>
        /// <param name="gameNames">Array of game names. Limit: 100</param>
        /// <returns><see cref="HelixResponse{TResponseObject}"/> with games</returns>
        Task<HelixResponse<HelixGame>> GetGamesFromNames(string[] gameNames);

    }
}
