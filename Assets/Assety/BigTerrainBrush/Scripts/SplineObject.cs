using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class SplineObject
{
	[SerializeField]
	public GameObject parent;

	[SerializeField]
	public List<GameObject> splinePoints;

	//public List<Vector3> splinePoints;
}
