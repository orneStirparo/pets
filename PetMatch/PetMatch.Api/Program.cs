using Microsoft.Extensions.DependencyInjection;
using PetMatch.Api;
using PetMatch.Api.Common;
using PetMatch.Application;


var builder = WebApplication.CreateBuilder(args);
{
builder.Services.AddCors();
builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}
var app = builder.Build();
{
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run("http://localhost:4000");
}