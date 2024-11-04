using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    public GameObject treePrefab;
    public Transform[] spawnPoints;
    public int maxTrees = 1;
    private List<GameObject> trees = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxTrees; i++)
        {
            SpawnTree();
        }
    }

    // makes trees in the spawn points
    public void SpawnTree() // spawn point tutorial from yt
    {
        // Check if there are spawn points available
        if (spawnPoints.Length == 0) return;

        // Select a random spawn point from the array
        Transform selectedPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the tree at the selected spawn point
        GameObject newTree = Instantiate(treePrefab, selectedPoint.position, Quaternion.identity);
        trees.Add(newTree);
    }

    public void TreeDestroyed(GameObject tree)
    {
        
        // Remove the destroyed tree from the list
        trees.Remove(tree);

        // Spawn a new tree
        SpawnTree();
    }
}
