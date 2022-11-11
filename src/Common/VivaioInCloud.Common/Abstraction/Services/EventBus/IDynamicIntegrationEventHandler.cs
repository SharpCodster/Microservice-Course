namespace VivaioInCloud.Common.Abstraction.Services.EventBus
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}
