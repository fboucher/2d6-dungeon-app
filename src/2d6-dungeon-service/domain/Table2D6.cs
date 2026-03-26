
namespace c5m._2d6Dungeon.domain;

public class SimpleTable2D6
{
    public required string TableCode { get; set; }
    public required string[] Headers { get; set; }
    public required List<SimpleTable2D6Row> Rows { get; set; }
}

public class SimpleTable2D6Row 
{
    public required string Roll { get; set; }
    public required string Description { get; set; }

}
