using AuthorizationService.JwtStatelessToken;
using Database;
using Microsoft.AspNetCore.Mvc;
using SharedLib.APIs;
using SharedLib.Interfaces;
using System.Net;
using UserManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IDBHelper>(x => new DBHelper(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddStatelessTokenAuthentication();

builder.Services.AddTransient<IUserManagementService, UserManagementService>();

builder.Services
    .AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.Configure<ApiBehaviorOptions>(o =>
{
    o.InvalidModelStateResponseFactory = actionContext =>
        new BadRequestObjectResult(ApiResponse.GetValidationErrorResponse(ApiResponseType.VALIDATION_ERROR, actionContext.ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage), null, null, null));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();

app.Use(async (context, next) =>
{
    try
    {
        await next(context);
    }
    catch (Exception ex)
    {
        while (ex.InnerException != null)
        {
            ex = ex.InnerException;
        }

        var data = new Models.ViewModels.Security.ExceptionDetails()
        {
            ExceptionMessage = ex.Message,
            StackTrack = ex.StackTrace,
            TraceId = Guid.NewGuid().ToString()
        };

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsJsonAsync(data);
    }
});

app.Run();