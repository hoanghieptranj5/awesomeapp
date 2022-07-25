namespace AwesomeApp.Controllers.Models;

public class CreateRoleModel
{
    public string Description { get; set; }

    public string Hierarchy { get; set; }

    public List<string> Rights { get; set; }
    public string TranslationKey { get; set; }
}