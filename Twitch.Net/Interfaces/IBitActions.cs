using System;
using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Enums;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IBitActions
    {

        Task<HelixResponse<HelixCheermote>> GetCheermotes(string userId = null);

        Task<HelixDateRangeResponseWithTotal<HelixBitsLeaderboardEntry>> GetBitsLeaderboard(string userId = null, int count = 10,
            HelixPeriodType period = HelixPeriodType.All, DateTime? startedAt = null);

    }
}
