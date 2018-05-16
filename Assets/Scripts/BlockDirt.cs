using UnityEngine;

public class BlockDirt : BlockBase
{
	public override BreakableTool BreakableTool => BreakableTool.Shovel;
	public override Hardness Hardness => Hardness.Softer;
	public override float MiningTime => 2;

	public override void OnTick(Vector3Int location)
	{
		// 周囲8ブロックで，上3mから下1mの間に草ブロックが存在すれば，伝搬する
		if (CheckGrass(location + new Vector3Int(-1, 0, -1)) ||
			CheckGrass(location + new Vector3Int(-1, 0,  0)) ||
			CheckGrass(location + new Vector3Int(-1, 0,  1)) ||
			CheckGrass(location + new Vector3Int( 0, 0,  1)) ||
			CheckGrass(location + new Vector3Int( 1, 0,  1)) ||
			CheckGrass(location + new Vector3Int( 1, 0,  0)) ||
			CheckGrass(location + new Vector3Int( 1, 0, -1)) ||
			CheckGrass(location + new Vector3Int( 0, 0, -1)))
			Chunk.SetBlock("unicraft:grass", location);
	}

	private bool CheckGrass(Vector3Int v)
	{
		for (int i = v.y - 1; i <= v.y + 3; i++)
			if (Chunk[new Vector3Int(v.x, i, v.z)].BlockId == "unicraft:grass")
				return true;
		return false;
	}
}