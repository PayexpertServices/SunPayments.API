using System.Text.Json.Serialization;

namespace SunPayments.API.DTOs
{
    public class ExceptionResponseDto<T> where T : class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }

        [JsonIgnore] // JsonIgnore gelen datanın serialize edilmemesi için kullanılır.
        public bool IsSuccessful { get; private set; }
        public ErrorDto Error { get; private set; }

        public static ExceptionResponseDto<T> Success(T data, int statusCode)
        {
            return new ExceptionResponseDto<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static ExceptionResponseDto<T> Success(int statusCode)
        {
            return new ExceptionResponseDto<T> { Data = default, StatusCode = statusCode, IsSuccessful = true };
        }

        public static ExceptionResponseDto<T> Fail(ErrorDto errorDto, int statusCode)
        {
            return new ExceptionResponseDto<T> { StatusCode = statusCode, Error = errorDto };
        }

        public static ExceptionResponseDto<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage,isShow);

            return new ExceptionResponseDto<T> { Error = errorDto, StatusCode = statusCode};


        }
    }
}
