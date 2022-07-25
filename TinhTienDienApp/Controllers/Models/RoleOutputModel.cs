using Repositories.Models.RoleRight;

namespace TinhTienDienApp.Controllers.Models;

public class RoleOutputModel : Role
{
    public string Country { get; set; }
}