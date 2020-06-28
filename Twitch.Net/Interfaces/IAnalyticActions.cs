using System;
using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Enums;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IAnalyticActions
    {

        Task<HelixResponse<HelixExtensionAnalytic>> GetExtensionAnalytic(string extensionId = null, int first = 20, string after = null,
            DateTime? startedAt = null, DateTime? endedAt = null);

        Task<HelixPaginatedResponse<HelixExtensionAnalytic>> GetExtensionAnalyticsWithType(HelixAnalyticType type, string extensionId = null,
            int first = 20, string after = null, DateTime? startedAt = null, DateTime? endedAt = null);

        Task<HelixResponse<HelixGameAnalytic>> GetGameAnalytic(string gameId = null, int first = 20, string after = null,
            DateTime? startedAt = null, DateTime? endedAt = null);

        Task<HelixPaginatedResponse<HelixGameAnalytic>> GetGameAnalyticsWithType(HelixAnalyticType type, string gameId = null,
            int first = 20, string after = null, DateTime? startedAt = null, DateTime? endedAt = null);

    }
}
