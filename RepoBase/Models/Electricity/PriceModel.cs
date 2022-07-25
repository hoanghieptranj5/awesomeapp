using Amazon.DynamoDBv2.DataModel;

namespace RepoBase.Models.Electricity;

[DynamoDBTable("electricityPrice")]
public class PriceModel
{
    [DynamoDBHashKey("priceId")] public string PriceId { get; set; }

    [DynamoDBProperty("from")] public int From { get; set; }

    [DynamoDBProperty("to")] public int To { get; set; }

    [DynamoDBProperty("price")] public float Price { get; set; }
}