using Amazon.DynamoDBv2.DataModel;

namespace TinhTienDienApp.Repositories.Models.RoleRight;

[DynamoDBTable("user")]
public class User
{
    [DynamoDBHashKey("userId")] public string UserId { get; set; }

    [DynamoDBProperty("roles")] public List<CountryRole> Roles { get; set; }

    [DynamoDBProperty("forcePasswordChange")]
    public bool ForcePasswordChange { get; set; }

    [DynamoDBProperty("userType")] public string UserType { get; set; }

    [DynamoDBProperty("status")] public string Status { get; set; }
    
    [DynamoDBProperty("createdAt")] public DateTime CreatedAt { get; set; }
    
    [DynamoDBProperty("createdBy")] public string CreatedBy { get; set; }
}