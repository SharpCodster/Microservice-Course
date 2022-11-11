﻿using Microsoft.Extensions.Logging;
using VivaioInCloud.Catalog.Abstraction.Services;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Services;
using VivaioInCloud.Notificator.Abstraction;
using VivaioInCloud.Notificator.Models;
using VivaioInCloud.Notificator.Models.Enums;

namespace VivaioInCloud.Catalog.Services.Services
{
    public class UserPreferencesService : BaseUserOwnedService<UserPreferences>, IUserPreferencesService
    {
        protected readonly INotify _notify;

        public UserPreferencesService(
            INotify notify,
            IRequestContextProvider requestContextProvider,
            IAsyncRepository<UserPreferences> repository,
            IUnitOfWork unitOfWork,
            ILogger<UserPreferencesService> logger
            ) : base(requestContextProvider, repository, unitOfWork, logger)
        {
            _notify = notify;
        }

        protected override async Task AfterCreateAsync(UserPreferences entity)
        {
            UserPreferencesMessage message = new UserPreferencesMessage();
            message.Change = ChangeType.Created;
            message.UserId = entity.OwnerId;
            message.PreferenceTypeId = entity.ItemTypeId;
            await base.AfterCreateAsync(entity);
        }

        protected override async Task AfterDeleteAsync(UserPreferences entity)
        {
            UserPreferencesMessage message = new UserPreferencesMessage();
            message.Change = ChangeType.Delteted;
            message.UserId = entity.OwnerId;
            message.PreferenceTypeId = entity.ItemTypeId;
            await base.AfterDeleteAsync(entity);
        }
    }
}
