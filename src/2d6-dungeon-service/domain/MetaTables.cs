using System;

namespace c5m._2d6Dungeon.domain;

public class MetaTables
{
	public int Id { get; set; }
	public string Code { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public int Level { get; set; }
}

public class MetaTablesList
{
    public List<MetaTables> Value { get; set; } = new List<MetaTables>();
}

