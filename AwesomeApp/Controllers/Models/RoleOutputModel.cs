using Repositories.Models.RoleRight;

namespace AwesomeApp.Controllers.Models;

public class RoleOutputModel : Role
{
    public string Country { get; set; }
}