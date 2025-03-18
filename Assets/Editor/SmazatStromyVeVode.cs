using UnityEngine;
using UnityEditor;

public class RemoveAllTrees : MonoBehaviour
{
    private static float waterLevel = 1166f;
    private static float buffer = 5f;

    [MenuItem("Tools/Remove All Trees Below Water Level")]
    static void RemoveAllTreesFromTerrains()
    {
        Terrain[] terrains = FindObjectsOfType<Terrain>();
        int removedCount = 0;

        foreach (Terrain terrain in terrains)
        {
            TerrainData terrainData = terrain.terrainData;
            if (terrainData == null) continue;

            TreeInstance[] trees = terrainData.treeInstances;
            System.Collections.Generic.List<TreeInstance> newTrees = new System.Collections.Generic.List<TreeInstance>();

            foreach (TreeInstance tree in trees)
            {
                Vector3 worldPos = Vector3.Scale(tree.position, terrainData.size) + terrain.transform.position;
                if (worldPos.y > waterLevel + buffer)
                {
                    newTrees.Add(tree);
                }
                else
                {
                    removedCount++;
                }
            }

            terrainData.treeInstances = newTrees.ToArray();
        }

        Debug.Log($"Odstranìno {removedCount} stromù pod hladinou vody ({waterLevel + buffer}m). ");
    }
}
