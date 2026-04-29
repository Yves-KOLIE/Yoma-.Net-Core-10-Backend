namespace YOMA
{
  public class LoginResult
  {
    public bool UserIsConnected { get; set; }
    public object? Error { get; set; }
    public required string Message { get; set; }
    public required int StatusCode { get; set; }
    public bool IsChangePassword { get; set; }
    public object? ConnectedUserInfo {get; set; }
  }
}