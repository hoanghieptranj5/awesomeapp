using TinhTienDienApp.Repositories.Models.RoleRight;

namespace TinhTienDienApp.Controllers.Models;

public class UserOutputModel
{
    public string UserId { get; set; }

    public List<CountryRole> Roles { get; set; }
    
    public bool ForcePasswordChange { get; set; }

    public string UserType { get; set; }

    public string Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string CreatedBy { get; set; }
}