using Amazon.DynamoDBv2.DataModel;

namespace TinhTienDienApp.Repositories.Models.RoleRight;

[DynamoDBTable("role")]
public class Role
{
    [DynamoDBHashKey("roleId")] public string RoleId { get; set; }

    [DynamoDBProperty("hierarchy")] public string Hierachy { get; set; }

    [DynamoDBProperty("translationKey")] public string TranslationKey { get; set; }

    [DynamoDBProperty("description")] public string Description { get; set; }

    [DynamoDBProperty("rights")] public List<string> Rights { get; set; }
    
    [DynamoDBProperty("createdAt")] public DateTime CreatedAt { get; set; }
    
    [DynamoDBProperty("createdBy")] public string CreatedBy { get; set; }
}