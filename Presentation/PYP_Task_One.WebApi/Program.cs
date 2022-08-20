using FluentValidation.AspNetCore;
using PYP_Task_One.Aplication;
using PYP_Task_One.Aplication.Features.Queries.ExcelData;
using PYP_Task_One.Infrastructure;
using PYP_Task_One.Persistence;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddAplicationServices();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
}).AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<SendReportQueryHandler>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
