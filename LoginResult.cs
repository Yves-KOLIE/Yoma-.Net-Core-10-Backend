namespace YOMA
{
  public class LoginResult
  {
    public bool userIsConnected { get; set; }
    public object? error { get; set; }
    public required string message { get; set; }
    public required int statusCode { get; set; }
    public bool isChangePassword { get; set; }
    public object? user { get; set; }
    public string? token { get; set; } = null;
  }
}