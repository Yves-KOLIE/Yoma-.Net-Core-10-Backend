namespace YOMA
{
  public class CustomMessage
  {
    public bool Error;
    public string Message;
    public object? Data;

    public CustomMessage(string message, bool error = false, object? data = null)
    {
      this.Message = message;
      this.Error = error;
      this.Data = data;
    }
  }
}