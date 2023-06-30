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
        // Sterge toate mașinile din folderul specificat
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

            if (!isSpawning) // Verifică din nou dacă jocul a fost oprit înainte de a crea o mașină
                break;

            int randomSpawnIndex = Random.Range(0, 4);
            Transform spawnPoint;

            // Alege unul dintre punctele de spawn în mod aleatoriu
            if (randomSpawnIndex == 0)
                spawnPoint = spawn1;
            else if (randomSpawnIndex == 1)
                spawnPoint = spawn2;
            else if (randomSpawnIndex == 2)
                spawnPoint = spawn3;
            else
                spawnPoint = spawn4;

            // Spawnează mașina la punctul de spawn ales
            GameObject carSpawned = Instantiate(car, spawnPoint.position, spawnPoint.rotation);
            //carSpawned.transform.SetParent(carFolder);

            // Scade intervalul de spawn în funcție de timpul scurs în joc
            spawnInterval = Mathf.Clamp(initialSpawnInterval - PlayerController.GetTimer() * 0.1f, minSpawnInterval, initialSpawnInterval);
        }
    }

    public static void StopSpawning()
    {
        isSpawning = false;
    }
}
