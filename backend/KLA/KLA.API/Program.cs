using KLA.API.Extensions;
using KLA.Conversion.Interfaces;
using KLA.Models.Request;
using KLA.Models.Resposne;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

var app = builder.Build();

app.MapPost("/ConvertNumber", (IConvert converter,
    ConvertNumberRequest request) =>
{
    ConverNumberResponse res = new();

    try
    {
        res = converter.ConvertNumberToWords(request.Number);
    }
    catch (Exception ex)
    {
        return Results.Problem(statusCode: (int)HttpStatusCode.InternalServerError,
                                    detail: ex.Message);
    }

    return Results.Ok(res);

});

app.AddApplicationExtentions();

app.Run();

public partial class Program { }