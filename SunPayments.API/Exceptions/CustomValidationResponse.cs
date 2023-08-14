using Microsoft.AspNetCore.Mvc;
using SunPayments.API.DTOs;

namespace SunPayments.API.Exceptions
{
    public static class CustomValidationResponse
    {
        public static void UseCustomValidationResponse(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors=context.ModelState.Values.Where(x=>x.Errors.Count>0).SelectMany(x=>x.Errors).Select(x=>x.ErrorMessage);

                    ErrorDto errorDto = new ErrorDto(errors.ToList(), true);

                    var response = ExceptionResponseDto<NoContentResult>.Fail(errorDto, 400);

                    return new BadRequestObjectResult(response);
                };
            });
        }
    }
}
