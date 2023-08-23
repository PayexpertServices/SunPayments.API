using Microsoft.AspNetCore.Diagnostics;
using SunPayments.API.DTOs;
using System.Net;
using System.Text;
using System.Text.Json;

namespace SunPayments.API.Exceptions
{
    public static class CustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {

                // .run metotu ile bir middleware başka bir middleware e geçmez.
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (errorFeature != null)
                    {
                        var ex = errorFeature.Error.Message.ToString();
                        byte[] encodedBytes = Encoding.UTF8.GetBytes(ex);
                        string decodedText = Encoding.UTF8.GetString(encodedBytes);
                        context.Response.ContentType="application/json";
                        context.Response.StatusCode =(int)HttpStatusCode.InternalServerError;

                        var response = new ExceptionDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = decodedText
                        };


                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}
