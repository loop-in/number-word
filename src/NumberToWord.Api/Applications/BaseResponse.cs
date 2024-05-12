namespace NumberToWord.Api.Applications;

public class BaseResponse<T>
{
    public T? Data { get; set; }

    public string? Error { get; set; }

    public bool Success { get; set; }
}
