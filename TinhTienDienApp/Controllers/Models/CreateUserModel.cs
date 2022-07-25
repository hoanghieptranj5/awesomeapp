namespace TinhTienDienApp.Controllers.Models;

public class CreateUserModel
{
    public string Status { get; set; }
    public string UserType { get; set; }
    public List<string> Countries { get; set; }
    public List<string> Roles { get; set; }
}