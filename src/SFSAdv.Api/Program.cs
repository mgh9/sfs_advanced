using FluentValidation;
using MediatR;
using SFSAdv.Api.Infrastructure.Filters;
using SFSAdv.Application;
using SFSAdv.Application.Behaviors;
using SFSAdv.Application.Mapping;
using SFSAdv.Infrastructure;
using SFSAdv.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
});

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<ApplicationMappingProfile>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CustomValidationBehaviors<,>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.EnableAnnotations();
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(typeof(ApplicationMappingProfile));

var app = builder.Build();

// Ensure the database is created and migrated to the latest version
DatabaseInitializer.Initialize(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
