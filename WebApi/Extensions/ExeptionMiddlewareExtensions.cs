﻿using Entities.ErrorModels;
using Entities.Exeptions;
using Microsoft.AspNetCore.Diagnostics;
using Services.Contracts;
using System.Net;
using System.Runtime.CompilerServices;

namespace WebApi.Extensions
{
    public static class ExeptionMiddlewareExtensions
    {
        public static void ConfigureExeptionHandler(this WebApplication app, ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context=>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _=>StatusCodes.Status500InternalServerError
                        };
                        logger.LogError($"Something went wrong:{contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                        }.ToString());
                    }
                });
            });

        }
    }
}
