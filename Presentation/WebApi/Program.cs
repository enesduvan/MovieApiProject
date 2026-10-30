using Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;
using Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;
using Application.Features.MediatorDesignPattern.Handlers.CastHandler;
using Application.Features.MediatorDesignPattern.Handlers.TagHandlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Persistence;
using Persistence.Identity;
using System.Reflection;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Persistence.MovieContext>();
builder.Services
.AddApplicationServer()
.AddIdentityServices()
.AddMediatRServices()
.AddSwaggerDocumentation();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
