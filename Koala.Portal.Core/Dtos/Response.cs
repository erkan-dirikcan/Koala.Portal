namespace Koala.Portal.Core.Dtos
{
    public class Response
    {
        public string Message { get; protected set; }
        public bool IsSuccess { get; protected set; }
        public int StatusCode { get; protected set; }

        public ErrorDto Errors { get; protected set; }

        public static Response Success(int statusCode, string message)
        {
            return new Response { StatusCode = statusCode, IsSuccess = true, Message = message };
        }

        public static Response Fail(int statusCode, string message, ErrorDto error)
        {
            return new Response { StatusCode = statusCode, IsSuccess = false, Message = message, Errors = error };
        }

        public static Response Fail(int statusCode, string message, string error, bool isShow)
        {
            return new Response { Errors = new ErrorDto(error, isShow), IsSuccess = false, Message = message, StatusCode = statusCode };
        }
    }
    public class Response<T> : Response 
    {
        public T Data { get; private set; }

        public static Response<T> SuccessData(int statusCode, string message, T data)
        {
            return new Response<T> { Data = data, Message = message, IsSuccess = true, StatusCode = statusCode };
        }

        public static Response<T> FailData(int statusCode, string message, string error, bool isShow)
        {
            return new Response<T> { Errors = new ErrorDto(error, isShow), IsSuccess = false, Message = message, StatusCode = statusCode };
        }

        public static Response<T> FailData(int statusCode, string message, List<string> error, bool isShow)
        {
            return new Response<T> { Errors = new ErrorDto(error, isShow), IsSuccess = false, Message = message, StatusCode = statusCode };
        }
    }
    public class ResponseList<T> 
    {
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsShow { get; set; }
        public string Message { get; protected set; }
        public bool IsSuccess { get; protected set; }

        public int StatusCode { get; protected set; }

        public ErrorDto Errors { get; protected set; }
        public T Data { get; set; }

        public static ResponseList<T> SuccessData(int statusCode, string message, T data, int RecordsTotal, int RecordsFiltered, int RecordsShow)
        {
            return new ResponseList<T> { Data = data, Message = message, IsSuccess = true, StatusCode = statusCode, RecordsTotal = RecordsTotal, RecordsFiltered = RecordsFiltered, RecordsShow = RecordsShow };
        }

        public static ResponseList<T> FailData(int statusCode, string message, string error, bool isShow)
        {
            return new ResponseList<T> { Errors = new ErrorDto(error, isShow), IsSuccess = false, Message = message, StatusCode = statusCode };
        }

        public static ResponseList<T> FailData(int statusCode, string message, List<string> error, bool isShow)
        {
            return new ResponseList<T> { Errors = new ErrorDto(error, isShow), IsSuccess = false, Message = message, StatusCode = statusCode };
        }
    }
}
