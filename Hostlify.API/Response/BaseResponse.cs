namespace Hostlify.API.Response;

public class BaseResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Body { get; set; }
}