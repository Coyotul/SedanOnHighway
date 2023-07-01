using System;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawn1;
    [SerializeField] private Transform spawn2;
    [SerializeField] private Transform spawn3;
    [SerializeField] private Transform spawn4;
    [SerializeField] private GameObject car;
    [SerializeField] private Transform carFolder;
    private static bool isSpawning = true;

    private float initialSpawnInterval = 2f;
    private float minSpawnInterval = 0.5f;

    private void Start()
    {
        // Delete all cars in the specified folder
        foreach (Transform child in carFolder)
        {
            Destroy(child.gameObject);
        }

        SpawnCarsAsync();
    }

    private async void SpawnCarsAsync()
    {
        float spawnInterval = initialSpawnInterval;

        while (isSpawning && Application.isPlaying)
        {
            await Task.Delay(TimeSpan.FromSeconds(spawnInterval));

            if (!isSpawning) // Check again if spawning has been stopped before creating a car
                break;

            int randomSpawnIndex = Random.Range(0, 4);
            Transform spawnPoint;

            // Choose one of the spawn points randomly
            if (randomSpawnIndex == 0)
                spawnPoint = spawn1;
            else if (randomSpawnIndex == 1)
                spawnPoint = spawn2;
            else if (randomSpawnIndex == 2)
                spawnPoint = spawn3;
            else
                spawnPoint = spawn4;

            // Spawn the car at the chosen spawn point
            Instantiate(car, spawnPoint.position, spawnPoint.rotation);

            // Decrease the spawn interval based on the time elapsed in the game
            spawnInterval = Mathf.Clamp(initialSpawnInterval - PlayerController.GetTimer() * 0.1f, minSpawnInterval, initialSpawnInterval);
        }
    }

    public static void StopSpawning()
    {
        isSpawning = false;
    }
}
