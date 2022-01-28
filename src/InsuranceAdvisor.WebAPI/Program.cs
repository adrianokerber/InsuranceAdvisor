using InsuranceAdvisor.Domain.Interfaces;
using InsuranceAdvisor.Domain.Interfaces.Rules;
using InsuranceAdvisor.Domain.Models.Rules.Chain;
using InsuranceAdvisor.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddScoped<IInsuranceAdvisorService, InsuranceAdvisorService>()
    .AddScoped<IRiskScoreService, RiskScoreService>()
    .AddScoped<IRiskRuleChain, RiskRuleChain>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
