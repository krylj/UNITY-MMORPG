using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SculptPoint
{	
	public Vector3 position;
	public Vector3 originalPosition;
	public Vector3 deltaPosition;

	public List<Vector2> meshData = new List<Vector2>();		//x - MeshIndex, y - mesh vertex index position	
	public bool keepHighRes = true;
}
