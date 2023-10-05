using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private GameObject[] roadPrefabs; // Different road prefabs to choose from
    private float zSpawn = 0; // Z-coordinate where the next road will be spawned
    private float roadLength = 30; // Length of each road segment
    private int numberOfRoads = 5; // Number of road segments to keep in the scene
    [SerializeField] private Transform player; // Reference to the player's position in the scene
    List<GameObject> activeRoads = new List<GameObject>(); // List to keep track of active roads
    private float safeZoneValue = 35; // A safe zone ahead of the player

    void Start()
    {
        // Initialize the scene with a sequence of road segments
        for (int i = 0; i < numberOfRoads; i++)
        {
            if (i == 0)
            {
                // The first road segment is chosen explicitly (index 0)
                SpawnRoad(0);
            }
            else
            {
                // Randomly choose a road segment to spawn
                SpawnRoad(Random.Range(0, roadPrefabs.Length));
            }
        }
    }

    void Update()
    {
        // Check if it's time to spawn a new road segment
        if (player.position.z - safeZoneValue > zSpawn - (numberOfRoads * roadLength))
        {
            // Spawn a new road segment randomly
            SpawnRoad(Random.Range(0, roadPrefabs.Length));

            // Delete the oldest road segment that is no longer visible
            DeleteRoad();
        }
    }

    public void SpawnRoad(int roadIndex)
    {
        // Instantiate a new road segment at the specified position (forward along Z-axis)
        GameObject temp = Instantiate(roadPrefabs[roadIndex], transform.forward * zSpawn, transform.rotation);

        // Add the newly created road segment to the list of active roads
        activeRoads.Add(temp);

        // Move the spawn position ahead by the length of the road segment
        zSpawn += roadLength;
    }

    private void DeleteRoad()
    {
        // Remove and destroy the oldest road segment
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
}
