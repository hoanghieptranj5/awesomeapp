using Amazon.DynamoDBv2.DataModel;

namespace TinhTienDienApp.Repositories.Models.Hanzi;

[DynamoDBTable("hanzi")]
public class Hanzi
{
    [DynamoDBHashKey("hanziId")] public string HanziId { get; set; }

    [DynamoDBRangeKey("strokes")] public int Strokes { get; set; }

    [DynamoDBProperty("pinyin")] public string Pinyin { get; set; }

    [DynamoDBProperty("hanviet")] public string Hanviet { get; set; }

    [DynamoDBProperty("jyutping")] public string Jyutping { get; set; }

    [DynamoDBProperty("simplified")] public string Simplified { get; set; }

    [DynamoDBProperty("traditional")] public string Traditional { get; set; }
}