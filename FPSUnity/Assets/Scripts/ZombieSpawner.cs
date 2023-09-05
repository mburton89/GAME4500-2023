using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    public GameObject zombiePrefab;
    public List<Transform> spawnPoints;
    int wave;

    private void Awake()
    {
        Instance = this;
        wave = 1;
    }

    public void CountZombies()
    {
        Zombie[] zombie = FindObjectsOfType<Zombie>();

        if (zombie.Length == 1)
        {
            SpawnWaveOfZombies();
        }
    }

    void SpawnWaveOfZombies()
    {
        wave++;

        for (int i = 0; i < wave; i++)
        {
            int randSpawnPointIndex = Random.Range(0, spawnPoints.Count - 1);

            Instantiate(zombiePrefab, spawnPoints[randSpawnPointIndex].position, Quaternion.identity, transform);
        }

        HUD.Instance.UpdateWaveUI(wave);
    }
}
