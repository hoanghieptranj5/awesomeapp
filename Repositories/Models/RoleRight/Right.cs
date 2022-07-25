using Amazon.DynamoDBv2.DataModel;

namespace Repositories.Models.RoleRight;

[DynamoDBTable("right")]
public class Right
{
    [DynamoDBHashKey("rightId")] public string RightId { get; set; }

    [DynamoDBProperty("description")] public string Description { get; set; }
    
    [DynamoDBProperty("createdAt")] public DateTime CreatedAt { get; set; }
    
    [DynamoDBProperty("createdBy")] public string CreatedBy { get; set; }
}