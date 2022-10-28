using Ardalis.Specification.EntityFrameworkCore;
using Ardalis.Specification;
using FluentValidation;
using System.Threading;
using VivaioInCloud.Identity.Entities.Validators;
using VivaioInCloud.Identity.Infrastructure;
using VivaioInCloud.Identity.Infrastructure.Repositories;
using VivaioInCloud.Identity.Services;
using VivaioInCloud.Common;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Contexts;
using VivaioInCloud.Common.Middleware;
using VivaioInCloud.Common.Repositories;
using VivaioInCloud.Common.ServiceExtensions;
using VivaioInCloud.Notificator;
using VivaioInCloud.Identity.Entities.Models;
using Microsoft.AspNetCore.Identity;
using VivaioInCloud.Identity.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

// ESSENTIAL SERVICES ////////////////////////////////////////////////////////////////////////
builder.Services.AddDatabase<ApplicationDbContext>(SolutionConstants.DatabasesName.IDENTITY, builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwagger("Identity Microservice");
builder.Services.AddPublicAndPrivateKeyAuth<ApplicationDbContext, ApplicationUser, ApplicationRole>(builder.Configuration);
builder.Services.AddAutoMapperWithConfig();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISpecificationEvaluator, SpecificationEvaluator>(p => new SpecificationEvaluator(false));
builder.Services.AddSingleton(typeof(IRequestContextProvider), typeof(RequestContextProvider));
builder.Services.AddTransient<CorrelationIdMiddleware>();

// EXTENDED SERVICES /////////////////////////////////////////////////////////////////////////
builder.Services.AddNotification(builder.Configuration);

// MICROSERVICE SERVICES /////////////////////////////////////////////////////////////////////
builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork<ApplicationDbContext>));
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(IdentityRepository<>));
builder.Services.AddValidatorsFromAssemblyContaining<ApplicationUserDtoValidator>();
builder.Services.AddServices(builder.Configuration);

// JOBS ////////////////////////////////////////////////////////////////////////////////////


// END //////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    var userManager = scopedProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scopedProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    var identityContext = scopedProvider.GetRequiredService<ApplicationDbContext>();
    await DbContextSeed.SeedAsync(identityContext, userManager, roleManager);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<CorrelationIdMiddleware>();

app.Run();
