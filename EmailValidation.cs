  
namespace YOMA
{
  public class EmailValidation
  {
    public bool Success { get; set; }
    public required string Message { get; set; }
    public object? Error { get; set; }
    public required int StatusCode { get; set; }
      public object? ConnectedUser {get; set; }
  }
}