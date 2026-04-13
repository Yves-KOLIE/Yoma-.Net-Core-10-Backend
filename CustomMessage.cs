namespace YOMA
{
  public class CustomMessage
  {
    public bool IsError;
    public string Message;
    public object? Data;

    public CustomMessage(string message, bool isError = false, object? data = null)
    {
      this.Message = message;
      this.IsError = isError;
      this.Data = data;
    }
  }
}