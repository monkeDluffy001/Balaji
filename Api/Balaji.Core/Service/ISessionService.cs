﻿using Balaji.Common.Models;

namespace Balaji.Core.Service
{
    public interface ISessionService
    {
        public Task<dynamic> AddSessionAsync(Session session);
    }
}
