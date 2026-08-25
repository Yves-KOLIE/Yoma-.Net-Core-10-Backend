namespace YOMA
{
  public class ApiResult
  {
    public ApiResult(string message, bool isError, object? data)
    {
      Message = message;
      IsError = isError;
      Data = data;
    }

    public string Message { get; set; }
    public bool IsError { get; set; }
    public object? Data { get; set; }
  }
}
