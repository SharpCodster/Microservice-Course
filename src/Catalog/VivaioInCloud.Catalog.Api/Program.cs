using Ardalis.Specification.EntityFrameworkCore;
using Ardalis.Specification;
using FluentValidation;
using System.Threading;
using VivaioInCloud.Catalog.Entities.Validators;
using VivaioInCloud.Catalog.Infrastructure;
using VivaioInCloud.Catalog.Infrastructure.Repositories;
using VivaioInCloud.Catalog.Services;
using VivaioInCloud.Common;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Contexts;
using VivaioInCloud.Common.Middleware;
using VivaioInCloud.Common.Repositories;
using VivaioInCloud.Common.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

// ESSENTIAL SERVICES ////////////////////////////////////////////////////////////////////////
builder.Services.AddDatabase<ApplicationDbContext>(SolutionConstants.DatabasesName.CATALOG, builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwagger("Catalog Microservice");
builder.Services.AddAutoMapperWithConfig();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISpecificationEvaluator, SpecificationEvaluator>(p => new SpecificationEvaluator(false));
builder.Services.AddSingleton(typeof(IRequestContextProvider), typeof(RequestContextProvider));
builder.Services.AddTransient<CorrelationIdMiddleware>();

// EXTENDED SERVICES /////////////////////////////////////////////////////////////////////////


// MICROSERVICE SERVICES /////////////////////////////////////////////////////////////////////
builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork<ApplicationDbContext>));
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(CatalogRepository<>));
builder.Services.AddValidatorsFromAssemblyContaining<CatalogItemDtoWriteValidator>();
builder.Services.AddServices(builder.Configuration);

// JOBS ////////////////////////////////////////////////////////////////////////////////////


// END //////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();

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
