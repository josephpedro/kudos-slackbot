﻿namespace KudosSlackbot.Data.Gateway.Slack
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Dto.Slack.User;

    public interface ISlackUsersGateway
    {
        Task<UserDto> GetUserInfo(string userId, bool includeLocal = false);

        Task<IEnumerable<UserDto>> GetUsersList();
    }
}
