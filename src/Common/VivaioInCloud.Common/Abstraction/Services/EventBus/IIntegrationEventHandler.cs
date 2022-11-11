using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Common.Abstraction.Services.EventBus
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
    where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent integrationEvent);
    }

    public interface IIntegrationEventHandler
    {
    }
}
