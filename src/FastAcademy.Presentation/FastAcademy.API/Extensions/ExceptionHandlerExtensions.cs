using System.Net;
using FastAcademy.Shared.Constants;
using FastAcademy.Shared.Exceptions;
using FastAcademy.Shared.Models;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace FastAcademy.API.Extensions;

public static class ExceptionHandlerExtensions
{
    public static void UseCoreExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(errApp =>
        {
            errApp.Run(async ctx =>
            {
                var feature = ctx.Features.Get<IExceptionHandlerFeature>();
                if (feature is null) return;
                await WriteResponseAsync(ctx, feature.Error);
            });
        });
    }
    
    private static async Task WriteResponseAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = exception switch
        {
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            DomainException => (int)HttpStatusCode.BadRequest,
            ValidationException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };
        await context.Response.WriteAsJsonAsync(
            new FastAcademyResponse
            {
                Errors = GetResponseErrors(exception)
            });
    }

    private static List<string> GetResponseErrors(Exception ex)
    {
        switch (ex)
        {
            case UnauthorizedAccessException:
                return [ErrorCodes.Server.Unauthorized];
            case ValidationException vEx:
                return vEx.Errors
                    .Select(failure => failure.ErrorMessage)
                    .ToList();
            default:
            {
                var errorCount = 5;
                var errors = new List<string> { ex.Message };
                var inner = ex.InnerException;
                while (inner is not null && errorCount-- > 0)
                {
                    errors.Add(inner.Message);
                    inner = inner.InnerException;
                }
                return errors.ToList();
            }
        }
    }
}