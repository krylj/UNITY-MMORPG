using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasePoint
{
	public Vector3 position;
	public Vector3 originalPosition;
	public int terrainIndex;
	public List<int> terrainIndexes = new List<int>();
	public List<Vector2> heightsIndexes = new List<Vector2>();
	public Vector2 heightsIndex;
	public Vector3 terrainSize;
	public float terrainRes;	
}

