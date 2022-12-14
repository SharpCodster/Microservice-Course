using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using FluentValidation;
using VivaioInCloud.Common;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Abstraction.Services.EventBus;
using VivaioInCloud.Common.Contexts;
using VivaioInCloud.Common.Infrastructure;
using VivaioInCloud.Common.Middleware;
using VivaioInCloud.Common.Repositories;
using VivaioInCloud.Common.ServiceExtensions;
using VivaioInCloud.Notification.Entities.Validators;
using VivaioInCloud.Notification.Infrastructure;
using VivaioInCloud.Notification.Infrastructure.Configurations;
using VivaioInCloud.Notification.Infrastructure.Repositories;
using VivaioInCloud.Notification.Services;
using VivaioInCloud.Notification.Services.EventHandlers;
using VivaioInCloud.Notificator;
using VivaioInCloud.Notificator.Models;

var builder = WebApplication.CreateBuilder(args);

// ESSENTIAL SERVICES ////////////////////////////////////////////////////////////////////////
builder.Services.AddDatabase<ApplicationDbContext>(SolutionConstants.DatabasesName.NOTIFICATION, builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwagger("Notification Microservice");
builder.Services.AddPublicKeyAuth(builder.Configuration);
builder.Services.AddAutoMapperWithConfig();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISpecificationEvaluator, SpecificationEvaluator>(p => new SpecificationEvaluator(false));
builder.Services.AddSingleton(typeof(IRequestContextProvider), typeof(RequestContextProvider));
builder.Services.AddTransient<CorrelationIdMiddleware>();

// EXTENDED SERVICES /////////////////////////////////////////////////////////////////////////
builder.Services.AddNotification(builder.Configuration);

// MICROSERVICE SERVICES /////////////////////////////////////////////////////////////////////
builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork<ApplicationDbContext>));
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(NotificationRepository<>));
builder.Services.AddValidatorsFromAssemblyContaining<ContactDtoWriteValidator>();
builder.Services.AddServices(builder.Configuration);

// JOBS ////////////////////////////////////////////////////////////////////////////////////


// END //////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();

app.MigrateDbContext<ApplicationDbContext>((context, services) =>
{
    DbContextSeed.SeedAsync(context, services).Wait();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<CorrelationIdMiddleware>();



// Eventi
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<NewUserCreated, NewUserCreatedIntegrationEventHandler>();
//eventBus.Subscribe<ProductPriceChangedIntegrationEvent, ProductPriceChangedIntegrationEventHandler>();
//eventBus.Subscribe<OrderStartedIntegrationEvent, OrderStartedIntegrationEventHandler>();


app.Run();
