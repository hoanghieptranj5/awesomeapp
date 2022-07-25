using System.ComponentModel.DataAnnotations;

namespace TinhTienDienApp.Controllers.Models;

public class CreateRightModel
{
    [Required] public string RightId { get; set; }
    
    public string Description { get; set; }
    
    public string CreatedBy { get; set; }
}