using UnityEngine;
using System.Collections;

public class TerrainNeighbour : MonoBehaviour {

	Vector3[] directions = new Vector3[4]{new Vector3(-1, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(0, 0, -1)};
	public Terrain[] neighbors = new Terrain[4]{null, null, null, null};	//left, top, right, bottom

	void Start() 
	{
		//Terrain thisTerrain = this.GetComponent<Terrain>();
		this.GetComponent<Terrain>().SetNeighbors( neighbors[0], neighbors[1], neighbors[2], neighbors[3]);
	}

	public void SetNeighbours()
	{
		Terrain curTerrain = this.gameObject.GetComponent<Terrain>();					
		float size = curTerrain.terrainData.size.x;					
		Vector3 neighborPosition = Vector3.zero;

		for(int i = 0; i < directions.Length; i++)
		{
			neighborPosition = this.transform.position + (directions[i] * size);
			neighborPosition = new Vector3(neighborPosition.x, neighborPosition.y + 5000, neighborPosition.z);

			RaycastHit hit;

			if(Physics.Raycast(neighborPosition, Vector3.down, out hit))
			{
				Terrain tempTerrain = hit.transform.gameObject.GetComponent<Terrain>();

				neighbors[i] = tempTerrain;
			}
		}


		this.GetComponent<Terrain>().SetNeighbors( neighbors[0], neighbors[1], neighbors[2], neighbors[3]);

	}
}
