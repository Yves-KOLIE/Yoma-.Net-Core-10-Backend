  
namespace YOMA
{
  public class EmailValidation
  {
    public bool success { get; set; }
    public required string message { get; set; }
    public object? error { get; set; }
    public required int statusCode { get; set; }
    public object? connectedUser {get; set; }
  }
}