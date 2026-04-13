namespace YOMA
{
  public class ApiResult
  {
    public bool IsError;
    public string Message;
    public object? Data;

    public ApiResult(string message, bool isError = false, object? data = null)
    {
      this.Message = message;
      this.IsError = isError;
      this.Data = data;
    }
  }
}