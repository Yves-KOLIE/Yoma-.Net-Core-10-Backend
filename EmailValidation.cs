  
namespace YOMA
{
  public class EmailValidation
  {
    public bool codeIsGenerated { get; set; }
    public bool codeIsValided { get; set; }
    public bool passwordIsReset { get; set; }
    public bool codeAlreadyIsSent { get; set; }
    public required string message { get; set; }
    public object? error { get; set; }
  }
}